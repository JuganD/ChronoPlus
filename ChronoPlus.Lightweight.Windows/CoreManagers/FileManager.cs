using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public class FileManager
    {
        private const string CodeFileName = "jwt.cplus";
        private const string FolderName = "ChronoPlus";
        public readonly string AppDataLocation;
        public readonly string AppDataFolderLocation;
        public readonly string CodeLocation;
        public bool IsJwtPresent => File.Exists(this.CodeLocation);

        public FileManager()
        {
            this.AppDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.AppDataFolderLocation = Path.Combine(this.AppDataLocation, FolderName);
            this.CodeLocation = Path.Combine(this.AppDataFolderLocation, CodeFileName);
            EnsureFolderIsPresent();
        }

        public bool SaveJWT(string jwt)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.CodeLocation, false))
                {
                    sw.Write(jwt);
                    sw.Close();
                }

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                AccessErrorMessage();
                Window.Kill();
            }
            catch (IOException)
            {
            }
            return false;
        }

        public string ReadJwt()
        {
            try
            {
                if (IsJwtPresent)
                {
                    string line;
                    using (StreamReader sr = new StreamReader(this.CodeLocation))
                    {
                        line = sr.ReadLine();
                        sr.Close();
                    }

                    if (!string.IsNullOrEmpty(line))
                    {
                        return line;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                AccessErrorMessage();
                Window.Kill();
            }
            catch (IOException)
            {
            }
            return null;
        }
        private void EnsureFolderIsPresent()
        {
            if (!Directory.Exists(this.AppDataFolderLocation))
            {
                try
                {
                    Directory.CreateDirectory(this.AppDataFolderLocation);
                }
                catch (UnauthorizedAccessException)
                {
                    AccessErrorMessage();
                    Window.Kill();
                }
            }
        }

        private static void AccessErrorMessage()
        {
            MessageBox.Show("Error: Access denied! Please run the application with administrator privileges.",
                "Fatal Error", MessageBoxButtons.OK);
        }
    }
}
