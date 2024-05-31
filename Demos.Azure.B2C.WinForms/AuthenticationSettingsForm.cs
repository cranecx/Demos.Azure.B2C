using Demos.Azure.B2C.WinForms.Authentication;
using Demos.Azure.B2C.WinForms.Services;
using System.Data;

namespace Demos.Azure.B2C.WinForms;

public partial class AuthenticationSettingsForm : Form
{
    public event EventHandler<AuthenticationSettings>? AuthenticationSettingsChanged;
    public AuthenticationSettingsForm()
    {
        InitializeComponent();
    }

    private async void SaveButtonClick(object sender, EventArgs e)
    {
        var settings = new AuthenticationSettings
        {
            B2CName = textBox1.Text,
            AppId = appIdTextBox.Text,
            RedirectUri = redirectUriTextBox.Text,
            PolicySignIn = signInPolicyTextBox.Text,
            ApiScopes = apiScopesListBox.Items.Cast<string>().ToList()
        };

        await RoamingService.Set("AuthenticationSettings", settings);
        MessageBox.Show("Authentication settings saved successfully.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        AuthenticationSettingsChanged?.Invoke(this, settings);
        Close();
    }

    private void AddApiScopeButtonClick(object sender, EventArgs e)
    {
        var apiScope = Microsoft.VisualBasic.Interaction.InputBox("Enter the API scope:", "Add API Scope");
        if (!string.IsNullOrWhiteSpace(apiScope) && !apiScopesListBox.Items.Contains(apiScope))
        {
            apiScopesListBox.Items.Add(apiScope);
        }
    }

    private void RemoveApiScopeButtonClick(object sender, EventArgs e)
    {
        if (apiScopesListBox.SelectedIndex != -1)
        {
            apiScopesListBox.Items.RemoveAt(apiScopesListBox.SelectedIndex);
        }
    }

    private async void AuthenticationSettingsFormLoad(object sender, EventArgs e)
    {
        var settings = await RoamingService.Get<AuthenticationSettings>("AuthenticationSettings");
        if (settings != null)
        {
            textBox1.Text = settings.B2CName;
            appIdTextBox.Text = settings.AppId;
            redirectUriTextBox.Text = settings.RedirectUri;
            signInPolicyTextBox.Text = settings.PolicySignIn;
            apiScopesListBox.Items.AddRange(settings.ApiScopes.ToArray());
        }
    }
}
