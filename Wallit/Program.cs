using System;
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
            var timer = new Timer();

            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Interval = 900000;
            timer.Elapsed += timer_Elapsed;

            //timer_Elapsed();

            Console.ReadLine();
        }

        //object sender, ElapsedEventArgs e
        static async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var reddit = new Reddit();
            var wps = await reddit.GetAllWallpapers();

            var downloader = new ImageDownloader(@"F:\");
            await downloader.SaveImage(wps[0].Uri);

            Console.WriteLine("Image downloaded");
        }
    }
}
