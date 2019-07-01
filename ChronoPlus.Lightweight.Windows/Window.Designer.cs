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
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.SuspendLayout();
            // 
            // tile
            // 
            this.tile.ActiveControl = null;
            this.tile.BackColor = System.Drawing.Color.Lavender;
            this.tile.Dock = System.Windows.Forms.DockStyle.Top;
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
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(268, 134);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(231, 208);
            this.progressSpinner.Speed = 2F;
            this.progressSpinner.TabIndex = 1;
            this.progressSpinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressSpinner.UseSelectable = true;
            this.progressSpinner.Visible = false;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressSpinner);
            this.Controls.Add(this.tile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chrono+";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile tile;
        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
    }
}

