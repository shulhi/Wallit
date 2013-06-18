using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wallit.Models;

namespace Wallit.Downloader
{
    public class Reddit
    {
        private readonly HttpClient _client;

        public Reddit()
        {
            _client = new HttpClient();
        }

        public async Task<List<Wallpaper>> GetAllWallpapers()
        {
            var wps = new List<Wallpaper>();

            var json = await DownloadJson("http://www.reddit.com/r/wallpaper+wallpapers/new/.json");
            var o = JObject.Parse(json);

            //var wps = o["data"]["children"].Select(m => (string) m.SelectToken("data.url")).ToList();

            wps = (from p in o["data"]["children"]
                      select new Wallpaper {Title = (string)p.SelectToken("data.title"), Uri = (string)p.SelectToken("data.url")}).ToList();

            return wps;
        }

        private async Task<string> DownloadJson(string uri)
        {
            return await _client.GetStringAsync(uri);
        }
    }
}
