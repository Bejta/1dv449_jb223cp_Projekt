using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoMap
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{code}",
                defaults: new { controller = "InstagramMap", action = "Index", code = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Default1",
               url: "{controller}/{action}/{code}",
               defaults: new { controller = "InstagramMap", action = "Location", code = UrlParameter.Optional }
           );

            
        }
    }
}
