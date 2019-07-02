using ChronoPlus.Lightweight.Windows.CoreManagers;
using MetroFramework.Controls;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        private ConfigManager configManager;
        public void BindAllToggles()
        {
            if (configManager == null)
            {
                configManager = new ConfigManager();
            }

            foreach (var toggle in this.buttonsPanel.Controls)
            {
                if (toggle is MetroToggle)
                {
                    (toggle as MetroToggle).CheckedChanged += Toggle_CheckedChanged;
                }
            }
        }

        private void Toggle_CheckedChanged(object sender, System.EventArgs e)
        {
            MetroToggle toggle = (MetroToggle)sender;
            AddToggleToConfig(toggle);
        }
    }
}
