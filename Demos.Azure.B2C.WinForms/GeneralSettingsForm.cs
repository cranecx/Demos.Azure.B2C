using Demos.Azure.B2C.WinForms.Services;
using Demos.Azure.B2C.WinForms.Settings;

namespace Demos.Azure.B2C.WinForms;

public partial class GeneralSettingsForm : Form
{
    public event EventHandler<GeneralSettings>? GeneralSettingsChanged;
    public GeneralSettingsForm()
    {
        InitializeComponent();
    }

    private async void SaveButtonClick(object sender, EventArgs e)
    {
        var settings = new GeneralSettings
        {
            EnrichUserProfile = enrichUserProfileCheckBox.Checked,
            UserProfileEnrichementScope = userProfileEnrichmentScopeTextBox.Text,
            UserProfileEnrichementEndpoint = userProfileEnrichmentEndpointTextBox.Text
        };

        await RoamingService.Set("GeneralSettings", settings);
        MessageBox.Show("General settings saved successfully.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        GeneralSettingsChanged?.Invoke(this, settings);
        Close();
    }

    private void EnrichUserProfileCheckBoxCheckedChanged(object sender, EventArgs e)
    {
        userProfileEnrichmentEndpointTextBox.Enabled = enrichUserProfileCheckBox.Checked;
        userProfileEnrichmentScopeTextBox.Enabled = enrichUserProfileCheckBox.Checked;
    }

    private async void GeneralSettingsFormLoad(object sender, EventArgs e)
    {
        var settings = await RoamingService.Get<GeneralSettings>("GeneralSettings");
        if (settings != null)
        {
            enrichUserProfileCheckBox.Checked = settings.EnrichUserProfile;
            userProfileEnrichmentEndpointTextBox.Text = settings.UserProfileEnrichementEndpoint;
            userProfileEnrichmentEndpointTextBox.Enabled = enrichUserProfileCheckBox.Checked;
            userProfileEnrichmentScopeTextBox.Text = settings.UserProfileEnrichementScope;
            userProfileEnrichmentScopeTextBox.Enabled = enrichUserProfileCheckBox.Checked;
        }
    }
}
