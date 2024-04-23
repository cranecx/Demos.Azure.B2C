namespace Demos.Azure.B2C.WinForms;

partial class AuthenticationSettingsForm
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
        b2cNameLabel = new Label();
        textBox1 = new TextBox();
        appIdTextBox = new TextBox();
        appIdLabel = new Label();
        redirectUriTextBox = new TextBox();
        redirectUriLabel = new Label();
        signInPolicyTextBox = new TextBox();
        signInPolicyLabel = new Label();
        saveButton = new Button();
        apiScopesListBox = new ListBox();
        apiScopesLabel = new Label();
        addApiScopeButton = new Button();
        removeApiScopeButton = new Button();
        SuspendLayout();
        // 
        // b2cNameLabel
        // 
        b2cNameLabel.AutoSize = true;
        b2cNameLabel.Location = new Point(12, 10);
        b2cNameLabel.Name = "b2cNameLabel";
        b2cNameLabel.Size = new Size(63, 15);
        b2cNameLabel.TabIndex = 0;
        b2cNameLabel.Text = "B2C Name";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(12, 28);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(267, 23);
        textBox1.TabIndex = 1;
        // 
        // appIdTextBox
        // 
        appIdTextBox.Location = new Point(12, 78);
        appIdTextBox.Name = "appIdTextBox";
        appIdTextBox.Size = new Size(267, 23);
        appIdTextBox.TabIndex = 3;
        // 
        // appIdLabel
        // 
        appIdLabel.AutoSize = true;
        appIdLabel.Location = new Point(12, 60);
        appIdLabel.Name = "appIdLabel";
        appIdLabel.Size = new Size(81, 15);
        appIdLabel.TabIndex = 2;
        appIdLabel.Text = "Application Id";
        // 
        // redirectUriTextBox
        // 
        redirectUriTextBox.Location = new Point(12, 130);
        redirectUriTextBox.Name = "redirectUriTextBox";
        redirectUriTextBox.Size = new Size(267, 23);
        redirectUriTextBox.TabIndex = 5;
        // 
        // redirectUriLabel
        // 
        redirectUriLabel.AutoSize = true;
        redirectUriLabel.Location = new Point(12, 112);
        redirectUriLabel.Name = "redirectUriLabel";
        redirectUriLabel.Size = new Size(71, 15);
        redirectUriLabel.TabIndex = 4;
        redirectUriLabel.Text = "Redirect URI";
        // 
        // signInPolicyTextBox
        // 
        signInPolicyTextBox.Location = new Point(12, 185);
        signInPolicyTextBox.Name = "signInPolicyTextBox";
        signInPolicyTextBox.Size = new Size(267, 23);
        signInPolicyTextBox.TabIndex = 7;
        // 
        // signInPolicyLabel
        // 
        signInPolicyLabel.AutoSize = true;
        signInPolicyLabel.Location = new Point(12, 167);
        signInPolicyLabel.Name = "signInPolicyLabel";
        signInPolicyLabel.Size = new Size(78, 15);
        signInPolicyLabel.TabIndex = 6;
        signInPolicyLabel.Text = "Sign In Policy";
        // 
        // saveButton
        // 
        saveButton.Location = new Point(204, 381);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(75, 23);
        saveButton.TabIndex = 8;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButtonClick;
        // 
        // apiScopesListBox
        // 
        apiScopesListBox.FormattingEnabled = true;
        apiScopesListBox.ItemHeight = 15;
        apiScopesListBox.Location = new Point(12, 260);
        apiScopesListBox.Name = "apiScopesListBox";
        apiScopesListBox.Size = new Size(267, 94);
        apiScopesListBox.TabIndex = 9;
        // 
        // apiScopesLabel
        // 
        apiScopesLabel.AutoSize = true;
        apiScopesLabel.Location = new Point(12, 227);
        apiScopesLabel.Name = "apiScopesLabel";
        apiScopesLabel.Size = new Size(65, 15);
        apiScopesLabel.TabIndex = 10;
        apiScopesLabel.Text = "API Scopes";
        // 
        // addApiScopeButton
        // 
        addApiScopeButton.Location = new Point(96, 223);
        addApiScopeButton.Name = "addApiScopeButton";
        addApiScopeButton.Size = new Size(29, 23);
        addApiScopeButton.TabIndex = 11;
        addApiScopeButton.Text = "+";
        addApiScopeButton.UseVisualStyleBackColor = true;
        addApiScopeButton.Click += AddApiScopeButtonClick;
        // 
        // removeApiScopeButton
        // 
        removeApiScopeButton.Location = new Point(131, 223);
        removeApiScopeButton.Name = "removeApiScopeButton";
        removeApiScopeButton.Size = new Size(29, 23);
        removeApiScopeButton.TabIndex = 11;
        removeApiScopeButton.Text = "-";
        removeApiScopeButton.UseVisualStyleBackColor = true;
        removeApiScopeButton.Click += RemoveApiScopeButtonClick;
        // 
        // AuthenticationSettingsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(289, 411);
        Controls.Add(removeApiScopeButton);
        Controls.Add(addApiScopeButton);
        Controls.Add(apiScopesLabel);
        Controls.Add(apiScopesListBox);
        Controls.Add(saveButton);
        Controls.Add(signInPolicyTextBox);
        Controls.Add(signInPolicyLabel);
        Controls.Add(redirectUriTextBox);
        Controls.Add(redirectUriLabel);
        Controls.Add(appIdTextBox);
        Controls.Add(appIdLabel);
        Controls.Add(textBox1);
        Controls.Add(b2cNameLabel);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AuthenticationSettingsForm";
        Text = "Authentication Settings";
        Load += AuthenticationSettingsFormLoad;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label b2cNameLabel;
    private TextBox textBox1;
    private TextBox appIdTextBox;
    private Label appIdLabel;
    private TextBox redirectUriTextBox;
    private Label redirectUriLabel;
    private TextBox signInPolicyTextBox;
    private Label signInPolicyLabel;
    private Button saveButton;
    private ListBox apiScopesListBox;
    private Label apiScopesLabel;
    private Button addApiScopeButton;
    private Button removeApiScopeButton;
}