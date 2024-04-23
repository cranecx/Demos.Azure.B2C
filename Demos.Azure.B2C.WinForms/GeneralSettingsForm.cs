using Demos.Azure.B2C.WinForms.Services;
using Demos.Azure.B2C.WinForms.Settings;

namespace Demos.Azure.B2C.WinForms;

public partial class GeneralSettingsForm : Form
{
    public GeneralSettingsForm()
    {
        InitializeComponent();
    }

    private async void SaveButtonClick(object sender, EventArgs e)
    {
        var settings = new GeneralSettings
        {
            EnrichUserProfile = enrichUserProfileCheckBox.Checked,
            UserProfileEnrichementEndpoint = userProfileEnrichmentTextBox.Text
        };

        await RoamingService.Set("GeneralSettings", settings);
        MessageBox.Show("General settings saved successfully.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Close();
    }

    private void EnrichUserProfileCheckBoxCheckedChanged(object sender, EventArgs e)
    {
        userProfileEnrichmentTextBox.Enabled = enrichUserProfileCheckBox.Checked;
    }

    private async void GeneralSettingsFormLoad(object sender, EventArgs e)
    {
        var settings = await RoamingService.Get<GeneralSettings>("GeneralSettings");
        if (settings != null)
        {
            enrichUserProfileCheckBox.Checked = settings.EnrichUserProfile;
            userProfileEnrichmentTextBox.Text = settings.UserProfileEnrichementEndpoint;
            userProfileEnrichmentTextBox.Enabled = enrichUserProfileCheckBox.Checked;
        }
    }
}
