using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Entities
{
    public class User
    {
        [JsonProperty("bio")]
        public string Bio { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
    }
}