namespace CenterLib
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Api
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public static string IniReadValue(string Section, string Key, string filepath)
        {
            StringBuilder temp = new StringBuilder();
            int i = GetPrivateProfileString(Section, Key, "", temp, 0xff, filepath);
            return temp.ToString();
        }

        public static void IniWriteValue(string Section, string Key, string Value, string filepath)
        {
            WritePrivateProfileString(Section, Key, Value, filepath);
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}

