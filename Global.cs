using System;

namespace AutocadInitialization
{
    public class Global
    {
        public static double selectedCadVersion { get; set; } = 24.2;
        public static string localDbPath { get; set; }
        public static Version CurrentVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
    }
}
