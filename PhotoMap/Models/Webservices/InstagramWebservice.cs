using Newtonsoft.Json;
using PhotoMap.Models.Abstract;
using PhotoMap.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace PhotoMap.Models.Webservices
{
    public class InstagramWebservice :InstagramWebServiceBase
    {
        //public User LookupUser(string screenName)
        //{
        //    var rawJson = string.Empty;

        //    #region JSON from api.twitter.com

        //    // Get access token.
        //    var oAuthInstagramWrapper = new OAuthInstagramWrapper();
        //    var accessToken = oAuthInstagramWrapper.GetAccessToken();

        //    // Authorized call to Instagram's API (protected resources).
        //    var requestUriString = String.Format("https://api.twitter.com/1.1/users/lookup.json?screen_name={0}", screenName);
        //    var request = (HttpWebRequest)WebRequest.Create(requestUriString);
        //    request.Headers.Add("Authorization", String.Format("{0} {1}", accessToken.Type, accessToken.Token));
        //    request.Method = "GET";
        //    using (var response = request.GetResponse())
        //    using (var reader = new StreamReader(response.GetResponseStream()))
        //    {
        //        rawJson = reader.ReadToEnd();
        //    }
        //}
        public override List<User> GetUserImages()
        {

            var rawJson = string.Empty;
            var apiRequest = "users/self/";
            rawJson = RawJson(apiRequest);
            List<User>images = new List<User>();
            return images;
            //throw new NotImplementedException();
            //var rawJson = string.Empty;
            //https://api.instagram.com/v1/users/self/?access_token=ACCESS-TOKEN
        }

        //Get pictures with specific tags
        //https://api.instagram.com/v1/tags/{tag-name}?access_token=ACCESS-TOKEN
        
    }
}