using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallit.Downloader
{
    public class DesktopManager
    {
        [DllImport("user32.dll")]
        private static extern int SystemParametersInfo(uint uAction, int uParam, string lpvParam, int fuWinIni);
        private const uint SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        public void SetWallpaper(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE);

            var registry = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            registry.SetValue("WallpaperStyle", 10);
            registry.SetValue("TileWallpaper", 0);
            registry.Close();
        }
    }
}
