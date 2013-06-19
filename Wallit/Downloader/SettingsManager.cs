using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Wallit.Downloader
{
    public static class SettingsManager
    {
        public static double Interval { get; set; }
        public static string SavedPath { get; set; }

        public static void ReadSettings()
        {
            var stream = File.OpenRead(Environment.CurrentDirectory + "\\settings.ini");
            string unparse;

            using (var reader = new StreamReader(stream))
            {
                unparse = reader.ReadToEnd();
            }

            var o = JObject.Parse(unparse);
            Interval = (double)o.GetValue("interval");
            SavedPath = (string)o.GetValue("PathToSave");
        }
    }
}
