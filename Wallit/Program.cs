using System;
using System.Text.RegularExpressions;
using System.Timers;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallit.Downloader;

namespace Wallit
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingsManager.ReadSettings();
            var timer = new Timer();

            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Interval = SettingsManager.Interval;
            timer.Elapsed += timer_Elapsed;

            timer_Elapsed(timer, null);

            Console.ReadLine();
        }

        //object sender, ElapsedEventArgs e
        static async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var reddit = new Reddit();
            var wps = await reddit.GetAllWallpapers();
            var path = SettingsManager.SavedPath;
            var isNotSet = true;
            var counter = 0;
            var downloader = new ImageDownloader(path);

            while (isNotSet)
            {
                if (downloader.TrySaveImage(wps[counter].Uri) && Regex.IsMatch(wps[counter].Uri, "(.jpg|.jpeg|.png|.bmp)"))
                {
                    await downloader.SaveImageAsync(wps[counter].Uri);
                    Console.WriteLine("{0} downloaded at {1}", wps[counter].Uri, DateTime.Now);

                    var dm = new DesktopManager();
                    dm.SetWallpaper(path + wps[counter].Uri.TrimEnd('/').Split('/').Last());

                    isNotSet = false;
                }
                counter++;
            }
        }
    }
}
