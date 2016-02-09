using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Entities
{
    public class Tag
    {
        [JsonProperty("media_count")]
        public int MediaCount { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}