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

        public ImageDownloader()
        {
            _client = new HttpClient();
        }

        public async Task DownloadImage(string uri, string saveToPath)
        {
            var stream = await _client.GetStreamAsync(uri);

            using (var fileStream = File.Create(saveToPath))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
