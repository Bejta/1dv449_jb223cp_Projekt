using PhotoMap.Models.Entities;
using PhotoMap.Models.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoMap.ViewModels
{
    public class PhotoMapViewModel
    {
        public UserInfo user { get; set; }
        public List<InstagramPost> posts { get; set; }
        public List<Location> locations { get; set; }
        public List<Tag> tags { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }

        [DisplayName("Tag")]
        [Required]
        [StringLength(20)]
        public string tag { get; set; }
        //public string 
    }
}
