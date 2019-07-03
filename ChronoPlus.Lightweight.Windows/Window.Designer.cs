namespace ChronoPlus.Lightweight.Windows
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.tile = new MetroFramework.Controls.MetroTile();
            this.informationPanel = new MetroFramework.Controls.MetroPanel();
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.buttonsPanel = new MetroFramework.Controls.MetroPanel();
            this.jwtChangeButton = new MetroFramework.Controls.MetroButton();
            this.nextRollTime = new MetroFramework.Controls.MetroLabel();
            this.nextRoll = new MetroFramework.Controls.MetroLabel();
            this.autoSpinLabel = new MetroFramework.Controls.MetroLabel();
            this.autoSpinToggle = new MetroFramework.Controls.MetroToggle();
            this.jwtTextBox = new MetroFramework.Controls.MetroTextBox();
            this.jwtButtonExit = new MetroFramework.Controls.MetroButton();
            this.runOnStartupLabel = new MetroFramework.Controls.MetroLabel();
            this.runOnStartupToggle = new MetroFramework.Controls.MetroToggle();
            this.informationPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tile
            // 
            this.tile.ActiveControl = null;
            this.tile.BackColor = System.Drawing.Color.Lavender;
            this.tile.Dock = System.Windows.Forms.DockStyle.Top;
            this.tile.Enabled = false;
            this.tile.ForeColor = System.Drawing.Color.Lavender;
            this.tile.Location = new System.Drawing.Point(20, 60);
            this.tile.Name = "tile";
            this.tile.PaintTileCount = false;
            this.tile.Size = new System.Drawing.Size(760, 10);
            this.tile.TabIndex = 0;
            this.tile.Text = "tile";
            this.tile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tile.UseSelectable = true;
            // 
            // informationPanel
            // 
            this.informationPanel.Controls.Add(this.progressSpinner);
            this.informationPanel.HorizontalScrollbarBarColor = true;
            this.informationPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.informationPanel.HorizontalScrollbarSize = 10;
            this.informationPanel.Location = new System.Drawing.Point(23, 103);
            this.informationPanel.Name = "informationPanel";
            this.informationPanel.Size = new System.Drawing.Size(476, 306);
            this.informationPanel.Style = MetroFramework.MetroColorStyle.Blue;
            this.informationPanel.TabIndex = 2;
            this.informationPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.informationPanel.VerticalScrollbarBarColor = true;
            this.informationPanel.VerticalScrollbarHighlightOnWheel = false;
            this.informationPanel.VerticalScrollbarSize = 10;
            this.informationPanel.Visible = false;
            // 
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(114, 42);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(231, 208);
            this.progressSpinner.Speed = 2F;
            this.progressSpinner.TabIndex = 2;
            this.progressSpinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressSpinner.UseSelectable = true;
            this.progressSpinner.Visible = false;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.runOnStartupLabel);
            this.buttonsPanel.Controls.Add(this.runOnStartupToggle);
            this.buttonsPanel.Controls.Add(this.jwtChangeButton);
            this.buttonsPanel.Controls.Add(this.nextRollTime);
            this.buttonsPanel.Controls.Add(this.nextRoll);
            this.buttonsPanel.Controls.Add(this.autoSpinLabel);
            this.buttonsPanel.Controls.Add(this.autoSpinToggle);
            this.buttonsPanel.Controls.Add(this.jwtTextBox);
            this.buttonsPanel.Controls.Add(this.jwtButtonExit);
            this.buttonsPanel.HorizontalScrollbarBarColor = true;
            this.buttonsPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.buttonsPanel.HorizontalScrollbarSize = 10;
            this.buttonsPanel.Location = new System.Drawing.Point(505, 103);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(272, 306);
            this.buttonsPanel.Style = MetroFramework.MetroColorStyle.Blue;
            this.buttonsPanel.TabIndex = 3;
            this.buttonsPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonsPanel.VerticalScrollbarBarColor = true;
            this.buttonsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.buttonsPanel.VerticalScrollbarSize = 10;
            // 
            // jwtChangeButton
            // 
            this.jwtChangeButton.BackColor = System.Drawing.Color.PaleGreen;
            this.jwtChangeButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.jwtChangeButton.ForeColor = System.Drawing.Color.Black;
            this.jwtChangeButton.Highlight = true;
            this.jwtChangeButton.Location = new System.Drawing.Point(172, 71);
            this.jwtChangeButton.Name = "jwtChangeButton";
            this.jwtChangeButton.Size = new System.Drawing.Size(100, 26);
            this.jwtChangeButton.Style = MetroFramework.MetroColorStyle.Black;
            this.jwtChangeButton.TabIndex = 9;
            this.jwtChangeButton.Text = "Change";
            this.jwtChangeButton.UseCustomBackColor = true;
            this.jwtChangeButton.UseCustomForeColor = true;
            this.jwtChangeButton.UseSelectable = true;
            this.jwtChangeButton.UseStyleColors = true;
            // 
            // nextRollTime
            // 
            this.nextRollTime.AutoSize = true;
            this.nextRollTime.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.nextRollTime.Location = new System.Drawing.Point(166, 42);
            this.nextRollTime.Name = "nextRollTime";
            this.nextRollTime.Size = new System.Drawing.Size(106, 25);
            this.nextRollTime.TabIndex = 8;
            this.nextRollTime.Text = "00h:00m:00s";
            this.nextRollTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // nextRoll
            // 
            this.nextRoll.AutoSize = true;
            this.nextRoll.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.nextRoll.Location = new System.Drawing.Point(14, 42);
            this.nextRoll.Name = "nextRoll";
            this.nextRoll.Size = new System.Drawing.Size(95, 25);
            this.nextRoll.TabIndex = 7;
            this.nextRoll.Text = "Next roll in";
            this.nextRoll.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // autoSpinLabel
            // 
            this.autoSpinLabel.AutoSize = true;
            this.autoSpinLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.autoSpinLabel.Location = new System.Drawing.Point(14, 13);
            this.autoSpinLabel.Name = "autoSpinLabel";
            this.autoSpinLabel.Size = new System.Drawing.Size(84, 25);
            this.autoSpinLabel.TabIndex = 6;
            this.autoSpinLabel.Text = "Auto spin";
            this.autoSpinLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // autoSpinToggle
            // 
            this.autoSpinToggle.AutoSize = true;
            this.autoSpinToggle.Checked = true;
            this.autoSpinToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSpinToggle.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.autoSpinToggle.Location = new System.Drawing.Point(189, 19);
            this.autoSpinToggle.Name = "autoSpinToggle";
            this.autoSpinToggle.Size = new System.Drawing.Size(80, 17);
            this.autoSpinToggle.TabIndex = 5;
            this.autoSpinToggle.Text = "On";
            this.autoSpinToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.autoSpinToggle.UseSelectable = true;
            // 
            // jwtTextBox
            // 
            // 
            // 
            // 
            this.jwtTextBox.CustomButton.Image = null;
            this.jwtTextBox.CustomButton.Location = new System.Drawing.Point(131, 1);
            this.jwtTextBox.CustomButton.Name = "";
            this.jwtTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jwtTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.jwtTextBox.CustomButton.TabIndex = 1;
            this.jwtTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.jwtTextBox.CustomButton.UseSelectable = true;
            this.jwtTextBox.CustomButton.Visible = false;
            this.jwtTextBox.Lines = new string[0];
            this.jwtTextBox.Location = new System.Drawing.Point(20, 73);
            this.jwtTextBox.MaxLength = 32767;
            this.jwtTextBox.Name = "jwtTextBox";
            this.jwtTextBox.PasswordChar = '*';
            this.jwtTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jwtTextBox.SelectedText = "";
            this.jwtTextBox.SelectionLength = 0;
            this.jwtTextBox.SelectionStart = 0;
            this.jwtTextBox.ShortcutsEnabled = true;
            this.jwtTextBox.Size = new System.Drawing.Size(153, 23);
            this.jwtTextBox.TabIndex = 10;
            this.jwtTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.jwtTextBox.UseSelectable = true;
            this.jwtTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jwtTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // jwtButtonExit
            // 
            this.jwtButtonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.jwtButtonExit.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.jwtButtonExit.ForeColor = System.Drawing.Color.Black;
            this.jwtButtonExit.Highlight = true;
            this.jwtButtonExit.Location = new System.Drawing.Point(229, 71);
            this.jwtButtonExit.Name = "jwtButtonExit";
            this.jwtButtonExit.Size = new System.Drawing.Size(40, 26);
            this.jwtButtonExit.Style = MetroFramework.MetroColorStyle.Black;
            this.jwtButtonExit.TabIndex = 11;
            this.jwtButtonExit.Text = "X";
            this.jwtButtonExit.UseCustomBackColor = true;
            this.jwtButtonExit.UseCustomForeColor = true;
            this.jwtButtonExit.UseSelectable = true;
            this.jwtButtonExit.UseStyleColors = true;
            // 
            // runOnStartupLabel
            // 
            this.runOnStartupLabel.AutoSize = true;
            this.runOnStartupLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.runOnStartupLabel.Location = new System.Drawing.Point(14, 271);
            this.runOnStartupLabel.Name = "runOnStartupLabel";
            this.runOnStartupLabel.Size = new System.Drawing.Size(125, 25);
            this.runOnStartupLabel.TabIndex = 13;
            this.runOnStartupLabel.Text = "Run on startup";
            this.runOnStartupLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // runOnStartupToggle
            // 
            this.runOnStartupToggle.AutoSize = true;
            this.runOnStartupToggle.Checked = true;
            this.runOnStartupToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runOnStartupToggle.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.runOnStartupToggle.Location = new System.Drawing.Point(189, 277);
            this.runOnStartupToggle.Name = "runOnStartupToggle";
            this.runOnStartupToggle.Size = new System.Drawing.Size(80, 17);
            this.runOnStartupToggle.TabIndex = 12;
            this.runOnStartupToggle.Text = "On";
            this.runOnStartupToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.runOnStartupToggle.UseSelectable = true;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.informationPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.tile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chrono+";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.informationPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile tile;
        private MetroFramework.Controls.MetroPanel informationPanel;
        private MetroFramework.Controls.MetroPanel buttonsPanel;
        private MetroFramework.Controls.MetroLabel autoSpinLabel;
        private MetroFramework.Controls.MetroToggle autoSpinToggle;
        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        private MetroFramework.Controls.MetroLabel nextRollTime;
        private MetroFramework.Controls.MetroLabel nextRoll;
        private MetroFramework.Controls.MetroButton jwtChangeButton;
        private MetroFramework.Controls.MetroTextBox jwtTextBox;
        private MetroFramework.Controls.MetroButton jwtButtonExit;
        private MetroFramework.Controls.MetroLabel runOnStartupLabel;
        private MetroFramework.Controls.MetroToggle runOnStartupToggle;
    }
}

