using Newtonsoft.Json;
using PhotoMap.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Responses
{
    public class UserToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
    }
}