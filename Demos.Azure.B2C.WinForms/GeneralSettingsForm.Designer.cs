namespace Demos.Azure.B2C.WinForms;

partial class GeneralSettingsForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        saveButton = new Button();
        enrichUserProfileCheckBox = new CheckBox();
        userProfileEnrichmentLabel = new Label();
        userProfileEnrichmentTextBox = new TextBox();
        SuspendLayout();
        // 
        // saveButton
        // 
        saveButton.Location = new Point(202, 146);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(75, 23);
        saveButton.TabIndex = 0;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButtonClick;
        // 
        // enrichUserProfileCheckBox
        // 
        enrichUserProfileCheckBox.AutoSize = true;
        enrichUserProfileCheckBox.Location = new Point(12, 12);
        enrichUserProfileCheckBox.Name = "enrichUserProfileCheckBox";
        enrichUserProfileCheckBox.Size = new Size(121, 19);
        enrichUserProfileCheckBox.TabIndex = 1;
        enrichUserProfileCheckBox.Text = "Enrich user profile";
        enrichUserProfileCheckBox.UseVisualStyleBackColor = true;
        enrichUserProfileCheckBox.CheckedChanged += EnrichUserProfileCheckBoxCheckedChanged;
        // 
        // userProfileEnrichmentLabel
        // 
        userProfileEnrichmentLabel.AutoSize = true;
        userProfileEnrichmentLabel.Location = new Point(12, 46);
        userProfileEnrichmentLabel.Name = "userProfileEnrichmentLabel";
        userProfileEnrichmentLabel.Size = new Size(182, 15);
        userProfileEnrichmentLabel.TabIndex = 2;
        userProfileEnrichmentLabel.Text = "User profile enrichment endpoint";
        // 
        // userProfileEnrichmentTextBox
        // 
        userProfileEnrichmentTextBox.Location = new Point(12, 64);
        userProfileEnrichmentTextBox.Name = "userProfileEnrichmentTextBox";
        userProfileEnrichmentTextBox.Size = new Size(265, 23);
        userProfileEnrichmentTextBox.TabIndex = 3;
        // 
        // GeneralSettingsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(289, 181);
        Controls.Add(userProfileEnrichmentTextBox);
        Controls.Add(userProfileEnrichmentLabel);
        Controls.Add(enrichUserProfileCheckBox);
        Controls.Add(saveButton);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "GeneralSettingsForm";
        Text = "General Settings";
        Load += GeneralSettingsFormLoad;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button saveButton;
    private CheckBox enrichUserProfileCheckBox;
    private Label userProfileEnrichmentLabel;
    private TextBox userProfileEnrichmentTextBox;
}