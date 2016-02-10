using PhotoMap.Models.Abstract;
using PhotoMap.Models.Entities;
using PhotoMap.Models.Responses;
using PhotoMap.Models.Webservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoMap.Models
{
    public class Service : IService
    { 
        private readonly IInstagramWebService _instagramWebService;
        //Constructors
        public Service(): this(new InstagramWebservice())
        {
            // Empty...
        }

        public Service( IInstagramWebService instagramWebService)
        {
            _instagramWebService = instagramWebService;
        }

        public List<User> GetUserImages(string code)
        {
            return _instagramWebService.GetUserImages(code);
        }

        public UserInfo GetUser(string code)
        {
            return _instagramWebService.GetUser(code);
        }

        public Tags GetTags(string code, string tag)
        {
            return _instagramWebService.GetTags(code, tag);
        }

        public List<InstagramPost> GetRecentImagesByTag(string code, string tag)
        {
            return _instagramWebService.GetRecentImagesByTag(code, tag);
        }
        public List<InstagramPost> GetLocations(string code, string lat, string ltd)
        {
            return _instagramWebService.GetLocations(code, lat, ltd);
        }
        public List<InstagramPost> GetImagesByLocationID(string code, string locationId)
        {
            return _instagramWebService.GetImagesByLocationID(code, locationId);
        }
    }
}