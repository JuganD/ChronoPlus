using System;
using System.IO;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class LocationVariables
    {
        private const string CodeFileName = "jwt.cplus";
        public const string ConfigFileName = "config.conf";
        private const string FolderName = "ChronoPlus";
        public readonly string AppDataLocation;
        public readonly string AppDataChronoFolderLocation;
        public readonly string CodeLocation;
        public readonly string ConfigLocation;
        public LocationVariables()
        {
            this.AppDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.AppDataChronoFolderLocation = Path.Combine(this.AppDataLocation, FolderName);
            this.CodeLocation = Path.Combine(this.AppDataChronoFolderLocation, CodeFileName);
            this.ConfigLocation = Path.Combine(this.AppDataChronoFolderLocation, ConfigFileName);
        }
        protected static void AccessErrorMessage()
        {
            MessageBox.Show("Error: Access denied! Please run the application with administrator privileges.",
                "Fatal Error", MessageBoxButtons.OK);
        }
    }
}
