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
            this.buttonsPanel = new MetroFramework.Controls.MetroPanel();
            this.autoSpinLabel = new MetroFramework.Controls.MetroLabel();
            this.autoSpinToggle = new MetroFramework.Controls.MetroToggle();
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
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
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.autoSpinLabel);
            this.buttonsPanel.Controls.Add(this.autoSpinToggle);
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
    }
}

