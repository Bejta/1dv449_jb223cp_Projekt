using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        public OAuthInstagramAccessToken GetAccessToken()
        {

            // Get settings from Web.config.
            var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
            var oAuthConsumerSecret = ConfigurationManager.AppSettings["instagram.clientsecret"];
            var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
            var oAuthUrl = ConfigurationManager.AppSettings["OAuthUrl"];

            // Create OAuth request.
            var authorizationHeader = string.Format("Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    Uri.EscapeDataString(client_id) + ":" + Uri.EscapeDataString((oAuthConsumerSecret)))
            ));

            var request = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            request.Headers.Add("Authorization", authorizationHeader);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes("grant_type=client_credentials");
                stream.Write(content, 0, content.Length);
            }

            request.Headers.Add("Accept-Encoding", "gzip");

            // Request for an access token.
            OAuthInstagramAccessToken accessToken;
            using (var authResponse = request.GetResponse())
            using (var reader = new StreamReader(authResponse.GetResponseStream()))
            {
                accessToken = JsonConvert.DeserializeObject<OAuthInstagramAccessToken>(reader.ReadToEnd());
            }


            return accessToken;

        //https://instagram.com/oauth/authorize/?client_id=cb9ed86412594d1eb2bf9b7f83a73131&amp;redirect_uri=HTTP://localhost&amp;response_type=token
        //return accessToken;
        }
    }
}