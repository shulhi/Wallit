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
        private HttpClient _client;

        public List<Wallpaper> Wallpapers;

        public Reddit()
        {
            _client = new HttpClient();
        }

        public async Task<List<Wallpaper>>  GetAllWallpapers()
        {
            Wallpapers = new List<Wallpaper>();

            var json = await DownloadJson("http://www.reddit.com/r/wallpaper.json");
            var o = JObject.Parse(json);

            //var wps = o["data"]["children"].Select(m => (string) m.SelectToken("data.url")).ToList();
            //Console.WriteLine(wps.Count);

            Wallpapers = (from p in o["data"]["children"]
                      select new Wallpaper {Title = (string)p.SelectToken("data.title"), Uri = (string)p.SelectToken("data.url")}).ToList();

            return Wallpapers;
        }

        private async Task<string> DownloadJson(string uri)
        {
            return await _client.GetStringAsync(uri);
        }
    }
}
