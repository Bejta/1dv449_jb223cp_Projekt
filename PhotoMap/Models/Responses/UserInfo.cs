using Newtonsoft.Json;
using PhotoMap.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Responses
{
    public class UserInfo
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        [JsonProperty("data")]
        public User User { get; set; }

    }
}