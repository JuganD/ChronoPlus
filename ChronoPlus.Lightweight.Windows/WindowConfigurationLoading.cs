using ChronoPlus.Lightweight.Windows.CoreManagers;
using MetroFramework.Controls;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        private void InitializeAllConfigValues()
        {
            foreach (var control in this.buttonsPanel.Controls)
            {
                if (control is MetroToggle)
                {
                    BindToggleFromConfig(control as MetroToggle);
                }
            }
        }
        private void SaveAllConfigValues()
        {
            configManager.SaveConfig();
        }
        private void AddToggleToConfig(MetroToggle toggle)
        {
            if (!ConfigManager.Config.ContainsKey(toggle.Name))
            {
                ConfigManager.Config.Add(toggle.Name, null);
            }
            ConfigManager.Config[toggle.Name] = toggle.Checked.ToString();
        }
        private void BindToggleFromConfig(MetroToggle toggle)
        {
            if (ConfigManager.Config.ContainsKey(toggle.Name))
            {
                string toggleValueString = ConfigManager.Config[toggle.Name];
                bool toggleValueBool;
                if (toggleValueString != null && bool.TryParse(toggleValueString, out toggleValueBool))
                {
                    toggle.Checked = toggleValueBool;
                }
            }
        }
    }
}
