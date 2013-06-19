using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wallit.Downloader
{
    public class ImageDownloader
    {
        private HttpClient _client;
        public string SavedImagePath { get; set; }

        public ImageDownloader(string savedImagePath)
        {
            _client = new HttpClient();
            SavedImagePath = savedImagePath;
        }

        public async Task SaveImageAsync(string uri)
        {
            var stream = await _client.GetStreamAsync(uri);
            var image = uri.TrimEnd('/').Split('/').Last();

            using (var fileStream = File.Create(SavedImagePath + "\\" + image))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public bool TrySaveImage(string uri)
        {
            var splode = uri.TrimEnd('/').Split('/');

            if (File.Exists(SavedImagePath + "\\" + splode.Last()))
            {
                return false;
            }

            return true;
        }
    }
}
