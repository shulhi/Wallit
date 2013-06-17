using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallit.Models
{
    public class Wallpaper
    {
        [JsonProperty("url")]
        public string Uri { get; set; }
        public string Title { get; set; }
    }
}
