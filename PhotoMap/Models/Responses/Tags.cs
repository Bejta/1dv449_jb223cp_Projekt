using Newtonsoft.Json;
using PhotoMap.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Responses
{
    public class Tags
    {
        [JsonProperty("data")]
        public List<Tag> Data { get; set; }
    }
}