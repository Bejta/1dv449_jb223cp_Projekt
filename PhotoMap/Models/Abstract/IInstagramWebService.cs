using PhotoMap.Models.Entities;
using PhotoMap.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMap.Models.Abstract
{
    public interface IInstagramWebService 
    {
        List<User> GetUserImages(string code);
        List<Location> GetLocations(string code,Location location);
        UserInfo GetUser(string code);
        Tags GetTags(string code, string tag);
        List<InstagramPost> GetRecentImagesByTag(string code, string tag);
        List<InstagramPost> GetImagesByLocationID(string code, string locationId);

    }
}
