using System;
using System.IO;

namespace AutocadInitialization.Class
{
    public class IO
    {
        public static string UserDataFolder()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return checkDir(Path.Combine(dir, "DTool"));
        }

        private static string checkDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }

}
