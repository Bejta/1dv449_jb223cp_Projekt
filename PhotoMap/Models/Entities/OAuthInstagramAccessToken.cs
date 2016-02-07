using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Entities
{
    public class OAuthInstagramAccessToken
    {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("user")]
            public User TokenUser { get; set; }
    }
}