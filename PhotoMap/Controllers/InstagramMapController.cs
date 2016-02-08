using PhotoMap.Models;
using PhotoMap.Models.Abstract;
using PhotoMap.Models.Entities;
using PhotoMap.Models.Webservices;
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
            return View();
        }

        public ActionResult Login()
        {
            //var code = Redirect("https://api.instagram.com/oauth/authorize/?client_id=cb9ed86412594d1eb2bf9b7f83a73131&redirect_uri=http://localhost&response_type=code");
            return View("Login");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            ViewBag.Message = "Your contact page.";
            
            ////var response_acctoken = client_id + "& redirect_uri=" + redirect_uri + "& response_type=token";
            //var token_uri = "https://api.instagram.com/oauth/access_token/";
            
            if (string.IsNullOrWhiteSpace(Request.QueryString["code"]))
            {
                var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
                var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
                var response_uri = string.Format("https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code",
                         client_id, 
                         redirect_uri);
                Response.Redirect(response_uri);
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var code = Request.QueryString["code"];

                        var webservice = new InstagramWebservice();
                        var model = webservice.GetUserImages(code);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
            

            return View("Index");
        }
    }
}