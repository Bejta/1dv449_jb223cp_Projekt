using Newtonsoft.Json;
using PhotoMap.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PhotoMap.Models.Abstract
{
    public abstract class InstagramWebServiceBase : IInstagramWebService
    {
        // With this string starts every URL except Authentication URL
        internal static readonly string BaseUrl = "https://api.instagram.com/v1/";
        // This is URL for authentication
        //internal static readonly string oAuthUrl= "https://api.instagram.com/oauth/authorize/?client_id=CLIENT-ID&redirect_uri=REDIRECT-URI&response_type=code

        public abstract List<User> GetUserImages();

        public string RawJson(string apiRequest)
        {
            var rawJson = string.Empty;
           // var code = GetAuthCode();
            var accessToken = GetAccessToken();
            var url = BaseUrl + apiRequest + "?" + accessToken;
            var request = (HttpWebRequest)WebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }
            return rawJson;
        }
        private string GetAuthCode()
        {
            var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
            var oAuthConsumerSecret = ConfigurationManager.AppSettings["instagram.clientsecret"];
            var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
            var oAuthUrl = "https://api.instagram.com/oauth/authorize/?" + client_id + "& redirect_uri=" + redirect_uri + "&response_type=token";

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

            var authResponse = request.GetResponse();
            
            string code = "zz";
            return code;
        }

        private object GetAccessToken()
        {

            string url = "https://api.instagram.com/oauth/access_token";
            WebRequest myReq = WebRequest.Create(url);

            WebResponse wr = myReq.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader readertest = new StreamReader(receiveStream, Encoding.UTF8);
            string content1 = readertest.ReadToEnd();




            // Get settings from Web.config.
            var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
            var oAuthConsumerSecret = ConfigurationManager.AppSettings["instagram.clientsecret"];
            var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
            var oAuthUrlBase = "https://api.instagram.com/oauth/access_token";
            var oAuthUrl = "https://api.instagram.com/oauth/authorize/?" + client_id + "& redirect_uri=" + redirect_uri + "&response_type=token";
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
                var access = reader.ReadToEnd();
                accessToken = JsonConvert.DeserializeObject<OAuthInstagramAccessToken>(reader.ReadToEnd());
            }


            return accessToken;
        }
        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}