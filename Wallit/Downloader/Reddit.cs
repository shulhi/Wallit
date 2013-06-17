using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wallit.Downloader
{
    public class Reddit
    {
        private HttpClient _client;

        public Reddit()
        {
            _client = new HttpClient();
        }

        public async Task<string> DownloadJson(string uri)
        {
            return await _client.GetStringAsync(uri);
        }
    }
}
