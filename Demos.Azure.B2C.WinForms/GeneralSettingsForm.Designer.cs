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
        userProfileEnrichmentEndpointLabel = new Label();
        userProfileEnrichmentEndpointTextBox = new TextBox();
        userProfileEnrichmentScopeTextBox = new TextBox();
        userProfileEnrichmentScopeLabel = new Label();
        SuspendLayout();
        // 
        // saveButton
        // 
        saveButton.Location = new Point(202, 194);
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
        // userProfileEnrichmentEndpointLabel
        // 
        userProfileEnrichmentEndpointLabel.AutoSize = true;
        userProfileEnrichmentEndpointLabel.Location = new Point(12, 86);
        userProfileEnrichmentEndpointLabel.Name = "userProfileEnrichmentEndpointLabel";
        userProfileEnrichmentEndpointLabel.Size = new Size(182, 15);
        userProfileEnrichmentEndpointLabel.TabIndex = 2;
        userProfileEnrichmentEndpointLabel.Text = "User profile enrichment endpoint";
        // 
        // userProfileEnrichmentEndpointTextBox
        // 
        userProfileEnrichmentEndpointTextBox.Location = new Point(12, 104);
        userProfileEnrichmentEndpointTextBox.Name = "userProfileEnrichmentEndpointTextBox";
        userProfileEnrichmentEndpointTextBox.Size = new Size(265, 23);
        userProfileEnrichmentEndpointTextBox.TabIndex = 3;
        // 
        // userProfileEnrichmentScopeTextBox
        // 
        userProfileEnrichmentScopeTextBox.Location = new Point(12, 60);
        userProfileEnrichmentScopeTextBox.Name = "userProfileEnrichmentScopeTextBox";
        userProfileEnrichmentScopeTextBox.Size = new Size(265, 23);
        userProfileEnrichmentScopeTextBox.TabIndex = 5;
        // 
        // userProfileEnrichmentScopeLabel
        // 
        userProfileEnrichmentScopeLabel.AutoSize = true;
        userProfileEnrichmentScopeLabel.Location = new Point(12, 42);
        userProfileEnrichmentScopeLabel.Name = "userProfileEnrichmentScopeLabel";
        userProfileEnrichmentScopeLabel.Size = new Size(165, 15);
        userProfileEnrichmentScopeLabel.TabIndex = 4;
        userProfileEnrichmentScopeLabel.Text = "User profile enrichment scope";
        // 
        // GeneralSettingsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(289, 229);
        Controls.Add(userProfileEnrichmentScopeTextBox);
        Controls.Add(userProfileEnrichmentScopeLabel);
        Controls.Add(userProfileEnrichmentEndpointTextBox);
        Controls.Add(userProfileEnrichmentEndpointLabel);
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
    private Label userProfileEnrichmentEndpointLabel;
    private TextBox userProfileEnrichmentEndpointTextBox;
    private TextBox userProfileEnrichmentScopeTextBox;
    private Label userProfileEnrichmentScopeLabel;
}