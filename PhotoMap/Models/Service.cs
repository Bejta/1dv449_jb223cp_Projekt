using PhotoMap.Models.Abstract;
using PhotoMap.Models.Entities;
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
            // Empty
        }

        public Service( IInstagramWebService instagramWebService)
        {
            _instagramWebService = instagramWebService;
        }

        public List<User> GetUserImages()
        {
            return _instagramWebService.GetUserImages();
        }

    }
}