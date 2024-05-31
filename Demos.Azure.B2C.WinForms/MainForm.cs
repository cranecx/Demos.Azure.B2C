using Demos.Azure.B2C.WebAPI.Client;
using Demos.Azure.B2C.WinForms.Authentication;
using Demos.Azure.B2C.WinForms.Services;
using Demos.Azure.B2C.WinForms.Settings;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Desktop;
using Microsoft.IdentityModel.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Windows.Forms;

namespace Demos.Azure.B2C.WinForms;

public partial class MainForm : Form
{
    private GeneralSettingsForm GeneralSettingsForm { get; } = new();
    private GeneralSettings? GeneralSettings { get; set; }
    private AuthenticationSettingsForm AuthenticationSettingsForm { get; } = new();
    private AuthenticationSettings? AuthenticationSettings { get; set; }
    private IPublicClientApplication? PublicClientApplication { get; set; }
    private IAccount? Account { get; set; }

    public MainForm()
    {
        InitializeComponent();

        AuthenticationSettingsForm.AuthenticationSettingsChanged += HandleAuthenticationSettingsChanged;
        GeneralSettingsForm.GeneralSettingsChanged += HandleGeneralSettingsChanged;
    }

    private async void MainFormLoad(object sender, EventArgs e)
    {
        GeneralSettings = await RoamingService.Get<GeneralSettings>("GeneralSettings");
        AuthenticationSettings = await RoamingService.Get<AuthenticationSettings>("AuthenticationSettings");

        resourceListComboBox.Enabled = false;
        acquireTokenButton.Enabled = false;

        InitializeSettings();
    }

    private void HandleGeneralSettingsChanged(object? sender, GeneralSettings e)
    {
        GeneralSettings = e;
    }

    private void HandleAuthenticationSettingsChanged(object? sender, AuthenticationSettings e)
    {
        AuthenticationSettings = e;
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        if (AuthenticationSettings != null)
        {
            PublicClientApplication = PublicClientApplicationBuilder.Create(AuthenticationSettings.AppId)
                            .WithB2CAuthority(AuthenticationSettings.AuthoritySignUpSignIn)
                            .WithRedirectUri(AuthenticationSettings.RedirectUri)
                            .WithWindowsEmbeddedBrowserSupport()
                            .Build();

            resourceListComboBox.Items.Clear();
            foreach (var resource in AuthenticationSettings.ApiScopes)
            {
                resourceListComboBox.Items.Add(resource);
            }
        } 
    }

    private void AuthenticationSettingsToolStripMenuItemClick(object sender, EventArgs e)
    {
        AuthenticationSettingsForm.ShowDialog();
    }

    private void GeneralSettngsToolStripMenuItemClick(object sender, EventArgs e)
    {
        GeneralSettingsForm.ShowDialog();
    }

    private void ClearLogButtonClick(object sender, EventArgs e)
    {
        logTextBox.Clear();
    }

    private async void SignInButtonClick(object sender, EventArgs e)
    {
        try
        {
            if (PublicClientApplication == null)
            {
                PrintToLog("Configuration incomplete. Please configure the authentication settings.");
                var authenticationSettingsForm = new AuthenticationSettingsForm();
                authenticationSettingsForm.ShowDialog();

                return;
            }

            PrintToLog("Initiating sign-in flow.");
            var authResult = await PublicClientApplication
                .AcquireTokenInteractive([])
                .WithParentActivityOrWindow(Handle)
                .ExecuteAsync();

            Account = authResult.Account;

            PrintToLog("Sign-in successful.");

            var idToken = authResult.IdToken;

            PrintIdTokenDetails(idToken);

            if (GeneralSettings != null && GeneralSettings.EnrichUserProfile
                && !string.IsNullOrWhiteSpace(GeneralSettings.UserProfileEnrichementEndpoint)
                && !string.IsNullOrWhiteSpace(GeneralSettings.UserProfileEnrichementScope))
            {
                // Llamar al API para obtener los detalles del usuario
                var token = await AcquireToken(GeneralSettings.UserProfileEnrichementScope);
                var apiClient = new B2CAPIClient(GeneralSettings.UserProfileEnrichementEndpoint, token);
                var user = await apiClient.GetUserDetailsAsync();

                if (user != null)
                {
                    PrintToLog("User details retrieved from API:");
                    PrintToLog($"Display Name: {user.GivenName} {user.Surname}");
                    PrintToLog($"Identities: {string.Join(", ", user.Identities.Select(i => $"{i.SignInType}: {i.Value}"))}");
                    // Mostrar otros detalles del usuario según sea necesario
                }
                else
                {
                    PrintToLog("Failed to retrieve user details from API.");
                }
            }

            resourceListComboBox.Enabled = true;
        }
        catch (MsalException ex)
        {
            PrintToLog($"Error: {ex.Message} " + ex.StackTrace);
        }
    }

    private void ResourceListComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
        acquireTokenButton.Enabled = true;
    }


    private async void AcquireTokenButtonClick(object sender, EventArgs e)
    {
        var selectedResourceIndex = resourceListComboBox.SelectedIndex;
        var selectedResource = AuthenticationSettings!.ApiScopes[selectedResourceIndex];
        var token = await AcquireToken(selectedResource);

        PrintAccessTokenDetails(selectedResource, token);
    }

    private async Task<string> AcquireToken(string scope)
    {
        if (PublicClientApplication != null && Account != null)
        {
            var authResult = await PublicClientApplication
                .AcquireTokenSilent([scope], Account)
                .ExecuteAsync();

            return authResult.AccessToken;
        }
        else
        {
            throw new InvalidOperationException("Please, sign in first.");
        }
    }

    private void PrintIdTokenDetails(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(accessToken);
        PrintToLog($"Acquired ID Token: {accessToken}");

        foreach (var claim in token.Claims)
        {
            PrintToLog($"{claim.Type}:{claim.Value}");
        }
    }

    private void PrintAccessTokenDetails(string scope, string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(accessToken);
        PrintToLog($"Acquired access token for {scope}: {accessToken}");

        foreach (var claim in token.Claims)
        {
            PrintToLog($"{claim.Type}:{claim.Value}");
        }
    }

    private void PrintToLog(string text)
    {
        logTextBox.AppendText(text);
        logTextBox.AppendText(Environment.NewLine);
    }

}
