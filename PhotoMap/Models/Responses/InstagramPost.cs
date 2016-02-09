using Newtonsoft.Json;
using PhotoMap.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Responses
{
    public class InstagramPost
    {
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set;}
        [JsonProperty("images")]
        public Images Images { get; set; }

    }
}