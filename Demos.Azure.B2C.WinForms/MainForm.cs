using Demos.Azure.B2C.WebAPI.Client;
using Demos.Azure.B2C.WinForms.Authentication;
using Demos.Azure.B2C.WinForms.Services;
using Demos.Azure.B2C.WinForms.Settings;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Desktop;
using System.IdentityModel.Tokens.Jwt;
using System.Windows.Forms;

namespace Demos.Azure.B2C.WinForms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void AuthenticationSettingsToolStripMenuItemClick(object sender, EventArgs e)
    {
        var authenticationSettingsForm = new AuthenticationSettingsForm();
        authenticationSettingsForm.ShowDialog();
    }

    private void GeneralSettngsToolStripMenuItemClick(object sender, EventArgs e)
    {
        var generalSettingsForm = new GeneralSettingsForm();
        generalSettingsForm.ShowDialog();
    }


    private void ClearLogButtonClick(object sender, EventArgs e)
    {
        logTextBox.Clear();
    }

    private async void SignInButtonClick(object sender, EventArgs e)
    {
        var authenticationSettings = await RoamingService.Get<AuthenticationSettings>("AuthenticationSettings");
        if (authenticationSettings == null || string.IsNullOrWhiteSpace(authenticationSettings.AppId) ||
            string.IsNullOrWhiteSpace(authenticationSettings.RedirectUri) || string.IsNullOrWhiteSpace(authenticationSettings.PolicySignIn))
        {
            PrintToLog("Authentication configuration incomplete. Please configure the authentication settings.");
            var authenticationSettingsForm = new AuthenticationSettingsForm();
            authenticationSettingsForm.ShowDialog();
            return;
        }

        var aadClient = PublicClientApplicationBuilder.Create(authenticationSettings.AppId)
            .WithB2CAuthority(authenticationSettings.AuthoritySignUpSignIn)
            .WithRedirectUri(authenticationSettings.RedirectUri)
            .WithWindowsEmbeddedBrowserSupport()
            .Build();

        try
        {
            PrintToLog("Initiating sign-in flow.");
            var authResult = await aadClient
                .AcquireTokenInteractive(authenticationSettings.ApiScopes)
                .WithParentActivityOrWindow(this.Handle)
                .ExecuteAsync();

            PrintToLog("Sign-in successful.");

            await PrintTokenDetails(authResult.AccessToken ?? authResult.IdToken);

            // Obtener la configuración general
            var generalSettings = await RoamingService.Get<GeneralSettings>("GeneralSettings");

            if (generalSettings != null && generalSettings.EnrichUserProfile && !string.IsNullOrWhiteSpace(generalSettings.UserProfileEnrichementEndpoint))
            {
                // Llamar al API para obtener los detalles del usuario
                var apiClient = new B2CAPIClient(generalSettings.UserProfileEnrichementEndpoint);
                var user = await apiClient.GetUserDetailsAsync(authResult.UniqueId);

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
        }
        catch (MsalException ex)
        {
            PrintToLog($"Error: {ex.Message} " + ex.StackTrace);
        }
    }

    private Task PrintTokenDetails(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(accessToken);
        PrintToLog($"Acquired Token: {accessToken}");

        foreach (var claim in token.Claims)
        {
            PrintToLog($"{claim.Type}:{claim.Value}");
        }

        return Task.CompletedTask;
    }

    private void PrintToLog(string text)
    {
        logTextBox.AppendText(text);
        logTextBox.AppendText(Environment.NewLine);
    }
}
