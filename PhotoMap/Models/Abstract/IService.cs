using PhotoMap.Models.Entities;
using PhotoMap.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMap.Models.Abstract
{
    public interface IService
    {
        List<User> GetUserImages(string code);
        UserInfo GetUser(string code);
        Tags GetTags(string code, string tag);
        List<InstagramPost> GetRecentImagesByTag(string code, string tag);
        List<Location> GetLocations(string code, Location location);
        List<InstagramPost> GetImagesByLocationID(string code, string locationId);
    }
}
