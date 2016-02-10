using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Responses
{
    public class Post
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        [JsonProperty("data")]
        public List<InstagramPost> Data { get; set; }
    }
}