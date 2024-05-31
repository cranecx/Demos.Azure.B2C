namespace Demos.Azure.B2C.WinForms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        logTextBox = new TextBox();
        signInButton = new Button();
        clearLogButton = new Button();
        mainMenuStrip = new MenuStrip();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        generalSettngsToolStripMenuItem = new ToolStripMenuItem();
        authenticationSettingsToolStripMenuItem = new ToolStripMenuItem();
        resourceListComboBox = new ComboBox();
        resourceListLabel = new Label();
        acquireTokenButton = new Button();
        mainMenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // logTextBox
        // 
        logTextBox.Location = new Point(12, 114);
        logTextBox.Multiline = true;
        logTextBox.Name = "logTextBox";
        logTextBox.ReadOnly = true;
        logTextBox.Size = new Size(1076, 542);
        logTextBox.TabIndex = 0;
        // 
        // signInButton
        // 
        signInButton.Location = new Point(12, 28);
        signInButton.Name = "signInButton";
        signInButton.Size = new Size(75, 23);
        signInButton.TabIndex = 1;
        signInButton.Text = "Sign In";
        signInButton.UseVisualStyleBackColor = true;
        signInButton.Click += SignInButtonClick;
        // 
        // clearLogButton
        // 
        clearLogButton.Location = new Point(93, 28);
        clearLogButton.Name = "clearLogButton";
        clearLogButton.Size = new Size(75, 23);
        clearLogButton.TabIndex = 2;
        clearLogButton.Text = "Clear log";
        clearLogButton.UseVisualStyleBackColor = true;
        clearLogButton.Click += ClearLogButtonClick;
        // 
        // mainMenuStrip
        // 
        mainMenuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
        mainMenuStrip.Location = new Point(0, 0);
        mainMenuStrip.Name = "mainMenuStrip";
        mainMenuStrip.Size = new Size(1100, 24);
        mainMenuStrip.TabIndex = 3;
        mainMenuStrip.Text = "menuStrip1";
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generalSettngsToolStripMenuItem, authenticationSettingsToolStripMenuItem });
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(61, 20);
        settingsToolStripMenuItem.Text = "Settings";
        // 
        // generalSettngsToolStripMenuItem
        // 
        generalSettngsToolStripMenuItem.Name = "generalSettngsToolStripMenuItem";
        generalSettngsToolStripMenuItem.Size = new Size(198, 22);
        generalSettngsToolStripMenuItem.Text = "General Settngs";
        generalSettngsToolStripMenuItem.Click += GeneralSettngsToolStripMenuItemClick;
        // 
        // authenticationSettingsToolStripMenuItem
        // 
        authenticationSettingsToolStripMenuItem.Name = "authenticationSettingsToolStripMenuItem";
        authenticationSettingsToolStripMenuItem.Size = new Size(198, 22);
        authenticationSettingsToolStripMenuItem.Text = "Authentication Settings";
        authenticationSettingsToolStripMenuItem.Click += AuthenticationSettingsToolStripMenuItemClick;
        // 
        // resourceListComboBox
        // 
        resourceListComboBox.FormattingEnabled = true;
        resourceListComboBox.Location = new Point(12, 85);
        resourceListComboBox.Name = "resourceListComboBox";
        resourceListComboBox.Size = new Size(156, 23);
        resourceListComboBox.TabIndex = 4;
        resourceListComboBox.SelectedIndexChanged += ResourceListComboBoxSelectedIndexChanged;
        // 
        // resourceListLabel
        // 
        resourceListLabel.AutoSize = true;
        resourceListLabel.Location = new Point(12, 67);
        resourceListLabel.Name = "resourceListLabel";
        resourceListLabel.Size = new Size(55, 15);
        resourceListLabel.TabIndex = 5;
        resourceListLabel.Text = "Resource";
        // 
        // acquireTokenButton
        // 
        acquireTokenButton.Location = new Point(174, 85);
        acquireTokenButton.Name = "acquireTokenButton";
        acquireTokenButton.Size = new Size(107, 23);
        acquireTokenButton.TabIndex = 6;
        acquireTokenButton.Text = "Acquire Token";
        acquireTokenButton.UseVisualStyleBackColor = true;
        acquireTokenButton.Click += AcquireTokenButtonClick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 667);
        Controls.Add(acquireTokenButton);
        Controls.Add(resourceListLabel);
        Controls.Add(resourceListComboBox);
        Controls.Add(clearLogButton);
        Controls.Add(signInButton);
        Controls.Add(logTextBox);
        Controls.Add(mainMenuStrip);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        Text = "Demo Azure AD B2C - Windows Forms";
        Load += MainFormLoad;
        mainMenuStrip.ResumeLayout(false);
        mainMenuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox logTextBox;
    private Button signInButton;
    private Button clearLogButton;
    private MenuStrip mainMenuStrip;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripMenuItem authenticationSettingsToolStripMenuItem;
    private ToolStripMenuItem generalSettngsToolStripMenuItem;
    private ComboBox resourceListComboBox;
    private Label resourceListLabel;
    private Button acquireTokenButton;
}
