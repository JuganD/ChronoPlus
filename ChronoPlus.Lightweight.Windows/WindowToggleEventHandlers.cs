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
                    Toggle_CheckedChanged(toggle, null);
                }
            }
        }

        private void Toggle_CheckedChanged(object sender, System.EventArgs e)
        {
            MetroToggle toggle = (MetroToggle)sender;
            AddToggleToConfig(toggle);

            CustomToggleCheckedProperties(toggle);
        }
        private void CustomToggleCheckedProperties(MetroToggle toggle)
        {
            if (toggle == this.runOnStartupToggle)
            {
                RegistryManager registryManager = new RegistryManager();
                if (toggle.Checked)
                {
                    registryManager.AddProgramToStartup();
                }
                else
                {
                    registryManager.RemoveProgramFromStartup();
                }
            }
        }
    }
}
