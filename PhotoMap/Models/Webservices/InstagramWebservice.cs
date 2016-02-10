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
        /// Returns a list with tags from given base tag
        /// </summary>
        /// <param name="code"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public override Tags GetTags(string code, string tag)
        {
            var rawJson = string.Empty;
            var apiRequest = string.Format("/tags/search?q={0}", tag);
            rawJson = RawJsonQuery(apiRequest, code);
           
            Tags tags = new Tags();
            tags = JsonConvert.DeserializeObject<Tags>(rawJson);
            return tags;
        }
        /// <summary>
        /// Returns Instagram posts from given tag
        /// </summary>
        /// <param name="code"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public override List<InstagramPost> GetRecentImagesByTag(string code, string tag)
        {
            var rawJson = string.Empty;
            
            var apiRequest = string.Format("tags/{0}/media/recent", tag);
            rawJson = RawJson(apiRequest, code);

            List<InstagramPost> instagramPosts = new List<InstagramPost>();
            instagramPosts = JsonConvert.DeserializeObject<Post>(rawJson).Data;
            //instagramPosts = JsonConvert.DeserializeObject<List<InstagramPost>>(rawJson);
            return instagramPosts;
        }

        /// <summary>
        /// Returns locations in radius of 1000 meters from given location
        /// </summary>
        /// <param name="code"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public override List<InstagramPost> GetLocations(string code, string lat, string ltd)
        {
            var rawJson = string.Empty;
            var apiRequest = string.Format("media/search?lat={0}&lng={1}", lat,ltd);
            rawJson = RawJsonQuery(apiRequest, code);

            //List<Location> locations = new List<Location>();
            List<InstagramPost> instagramPosts = new List<InstagramPost>();
            instagramPosts = JsonConvert.DeserializeObject<Post>(rawJson).Data;
            return instagramPosts;
            //locations = JsonConvert.DeserializeObject<List<Location>>(rawJson);
            //return locations;
        }
        /// <summary>
        /// Returns Instagram posts from given location
        /// </summary>
        /// <param name="code"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public override List<InstagramPost> GetImagesByLocationID(string code, string locationId)
        {
            var rawJson = string.Empty;
            var apiRequest = string.Format("locations/{0}/media/recent", locationId);
            rawJson = RawJson(apiRequest, code);

            List<InstagramPost> instagramPosts = new List<InstagramPost>();
            instagramPosts = JsonConvert.DeserializeObject<List<InstagramPost>>(rawJson);
            return instagramPosts;
        }
    }
}