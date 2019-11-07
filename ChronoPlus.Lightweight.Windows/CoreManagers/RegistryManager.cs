using Microsoft.Win32;
using System.Linq;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class RegistryManager
    {
        private const string RegistryKeyLocation = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string ApplicationName = "ChronoPlus";
        private string ApplicationPath;
        public RegistryManager()
        {
            ApplicationPath = System.Reflection.Assembly.GetEntryAssembly().Location;
        }
        public bool IsAppRunOnStartup()
        {
            bool result = false;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyLocation, true))
            {
                result = key.GetValueNames().Contains(ApplicationName);
            }
            return result;
        }
        public void AddProgramToStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyLocation, true))
            {
                if (!key.GetValueNames().Contains(ApplicationName) || key.GetValue(ApplicationName).ToString() != ApplicationPath)
                    key.SetValue(ApplicationName, ApplicationPath);
            }
        }
        public void RemoveProgramFromStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyLocation, true))
            {
                if (key != null && key.GetValue(ApplicationName) != null)
                {
                    key.DeleteValue(ApplicationName);
                }
            }
        }
    }
}
