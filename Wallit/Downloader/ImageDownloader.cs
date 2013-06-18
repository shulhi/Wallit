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

        public async Task SaveImage(string uri)
        {
            var stream = await _client.GetStreamAsync(uri);
            
            using (var fileStream = File.Create(SavedImagePath))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
