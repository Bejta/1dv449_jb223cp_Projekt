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
            //var code = Redirect("https://api.instagram.com/oauth/authorize/?client_id=cb9ed86412594d1eb2bf9b7f83a73131&redirect_uri=http://localhost&response_type=code");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            //ViewBag.Message = "Your contact page.";
            var client_id = ConfigurationManager.AppSettings["instagram.clientid"];
            var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"];
            var response_uri = "https://api.instagram.com/oauth/authorize/?client_id=" + client_id + "& redirect_uri=" + redirect_uri + "& response_type=code";
            //var response_acctoken = client_id + "& redirect_uri=" + redirect_uri + "& response_type=token";
            Response.Redirect(response_uri);
            try
            {
                if (ModelState.IsValid)
                {
                    var webservice = new InstagramWebservice();
                    var model = webservice.GetUserImages();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View("Index");
        }
    }
}