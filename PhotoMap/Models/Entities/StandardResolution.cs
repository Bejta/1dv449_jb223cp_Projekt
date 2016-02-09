using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Entities
{
    public class StandardResolution
    {
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("width")]
        public string width { get; set; }
        [JsonProperty("height")]
        public string height { get; set; }
    }
}