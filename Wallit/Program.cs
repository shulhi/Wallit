using System;
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
            var downloader = new ImageDownloader();
            downloader.DownloadImage("http://i.imgur.com/Y0qNmtp.jpg", @"F:\reddit.jpg");

            Console.ReadLine();
        }
    }
}
