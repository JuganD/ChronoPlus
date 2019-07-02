using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class FileManager : LocationVariables
    {
        public bool IsJwtPresent => File.Exists(this.CodeLocation);

        public FileManager()
        {
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
        protected void EnsureFolderIsPresent()
        {
            if (!Directory.Exists(this.AppDataChronoFolderLocation))
            {
                try
                {
                    Directory.CreateDirectory(this.AppDataChronoFolderLocation);
                }
                catch (UnauthorizedAccessException)
                {
                    AccessErrorMessage();
                    Window.Kill();
                }
            }
        }
    }
}
