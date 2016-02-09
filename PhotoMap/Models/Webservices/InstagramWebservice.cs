using Newtonsoft.Json;
using PhotoMap.Models.Abstract;
using PhotoMap.Models.Entities;
using PhotoMap.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace PhotoMap.Models.Webservices
{
    /// <summary>
    /// Get functions that takes informations from different end-points of Instagram Api
    /// </summary>
    public class InstagramWebservice :InstagramWebServiceBase
    {
        
        public override List<User> GetUserImages(string code)
        {
            var rawJson = string.Empty;
            var apiRequest = "users/self/";
            rawJson = RawJson(apiRequest, code);

            //var User = JsonConvert.DeserializeObject<List<User>>(rawJson);

            List<User>images = new List<User>();
            return images;
            //throw new NotImplementedException();
            //var rawJson = string.Empty;
            //https://api.instagram.com/v1/users/self/?access_token=ACCESS-TOKEN
        }

        /// <summary>
        /// This function returns information about User that are using application
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override UserInfo GetUser(string code)
        {
            var rawJson = string.Empty;
            var apiRequest = "users/self/";
            rawJson = RawJson(apiRequest, code);
            UserInfo userInfo = new UserInfo();
            userInfo = JsonConvert.DeserializeObject<UserInfo>(rawJson) ;
            return userInfo;
        }

        /// <summary>
        /// Returns a list with
        /// </summary>
        /// <param name="code"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public override Tags GetTags(string code, string tag)
        {
            var rawJson = string.Empty;
            var apiRequest = string.Format("/tags/search?q={0}", tag);
            rawJson = RawJson(apiRequest, code);
           
            Tags tags = new Tags();
            tags = JsonConvert.DeserializeObject<Tags>(rawJson);
            return tags;
        }
        public override List<InstagramPost> GetRecentImagesByTag(string code, string tag)
        {
            var rawJson = string.Empty;
            var apiRequest = string.Format("tags/{0}/media/recent", tag);
            rawJson = RawJson(apiRequest, code);

            List<InstagramPost> instagramPosts = new List<InstagramPost>();
            instagramPosts = JsonConvert.DeserializeObject<List<InstagramPost>>(rawJson);
            return instagramPosts;
        }

        //Get pictures with specific tags
        //https://api.instagram.com/v1/tags/{tag-name}?access_token=ACCESS-TOKEN

    }
}