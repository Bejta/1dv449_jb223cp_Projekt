using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Entities
{
    public class Images
    {
        [JsonProperty("low_resolution")]
        public LowResolution LowRes { get; set; }
        [JsonProperty("thumbnail")]
        public Thumbnail Thumb { get; set; }
        [JsonProperty("standard_resolution")]
        public StandardResolution StdRes { get; set; }
    }
}