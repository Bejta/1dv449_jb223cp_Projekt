using PhotoMap.Models;
using PhotoMap.Models.Abstract;
using PhotoMap.Models.Entities;
using PhotoMap.Models.Webservices;
using PhotoMap.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoMap.Controllers
{
    public class InstagramMapController : Controller
    {
        private IService _service;

        public InstagramMapController()
            : this(new Service())
        {
            //Empty
        }
        public InstagramMapController(IService service)
        {
            _service = service;
            
        }
        // GET: InstagramMap
        public ActionResult Index()
        {
            PhotoMapViewModel photoMap = new PhotoMapViewModel();

            return View(photoMap);
        }

        //public ActionResult Login()
        //{
        //    //var code = Redirect("https://api.instagram.com/oauth/authorize/?client_id=cb9ed86412594d1eb2bf9b7f83a73131&redirect_uri=http://localhost&response_type=code");
        //    return View("Login");
        //}

        [HttpPost]
        //[ValidateAntiForgeryToken][Bind(Include = "Tag")]
        public ActionResult Index(PhotoMapViewModel photoMap) { 
            // Checks if user is loged in (has "code" in url) and if not, redirects user to instagram login page.
            // This could be implemented in model instead....
            if (string.IsNullOrWhiteSpace(Request.QueryString["code"]))
            {
                var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
                var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
                var response_uri = string.Format("https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code&scope=public_content",
                         client_id, 
                         redirect_uri);
                //string a = response_uri;
                //Server.Transfer(response_uri);
                Response.Redirect(response_uri);
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var code = Request.QueryString["code"];
                        
                        if (photoMap.tag != null)
                        {
                           photoMap.posts = _service.GetRecentImagesByTag(code, photoMap.tag);
                        }
                        else
                        {
                            if (photoMap.latitude > 0.0 && photoMap.longitude > 0.0)
                            {
                                List<Location> locations = _service.GetLocations(code, photoMap.latitude, photoMap.longitude);
                                foreach (Location item in locations)
                                {
                                    photoMap.locations.Add(item);
                                }
                            }
                        }
      
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
            

            return View("Index", photoMap);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Location")]
        public ActionResult Location(PhotoMapViewModel photoMap)
        {
            // Checks if user is loged in (has "code" in url) and if not, redirects user to instagram login page.
            // This could be implemented in model instead....
            if (string.IsNullOrWhiteSpace(Request.QueryString["code"]))
            {
                var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
                var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
                var response_uri = string.Format("https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code&scope=public_content",
                         client_id,
                         redirect_uri);
                //string a = response_uri;
                //Server.Transfer(response_uri);
                Response.Redirect(response_uri);
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var code = Request.QueryString["code"];
                        if (photoMap.latitude > 0.0 && photoMap.longitude > 0.0)
                        {
                            List<Location> locations = _service.GetLocations(code, photoMap.latitude, photoMap.longitude);
                            foreach (Location item in locations)
                            {
                                photoMap.locations.Add(item);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }


            return View("Index", photoMap);
        }

    }
}