using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PhotoMap.Models.Webservices
{
    public class OAuthInstagramAccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("token_type")]
        public string Type { get; set; }
    }
    public class OAuthInstagramWrapper
    {
        public OAuthInstagramAccessToken GetAccessToken(){

        // Get settings from Web.config.
        var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
        var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
        var oAuthUrl = ConfigurationManager.AppSettings["OAuthUrl"];

        return accessToken;
    }
    }
}