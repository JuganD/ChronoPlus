using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class ConfigManager : LocationVariables
    {
        public static Dictionary<string, string> Config = new Dictionary<string, string>();

        public ConfigManager()
        {
            
        }

        public bool? GetConfigValue(string key)
        {
            if (Config.ContainsKey(key))
            {
                string configValueString = Config[key];
                bool configValueBool;
                if (configValueString != null && bool.TryParse(configValueString, out configValueBool))
                {
                    return configValueBool;
                }
            }
            return null;
        }

        public void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigLocation))
                {
                    Config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ConfigLocation));
                }
            }
            catch (UnauthorizedAccessException)
            {
                AccessErrorMessage();
            }
            catch (IOException)
            {
            }
        }

        public void SaveConfig()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Config);
                File.WriteAllText(ConfigLocation, json);
            }
            catch (UnauthorizedAccessException)
            {
                AccessErrorMessage();
            }
            catch (IOException)
            {
            }
        }
    }
}
