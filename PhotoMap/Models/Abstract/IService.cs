using PhotoMap.Models.Entities;
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
    }
}
