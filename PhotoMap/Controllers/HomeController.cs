using PhotoMap.Models;
using PhotoMap.Models.Abstract;
using PhotoMap.Models.Entities;
using PhotoMap.Models.Webservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoMap.Controllers
{
    public class HomeController : Controller
    {
        private IService _service;

        public HomeController()
            : this(new Service())
        {
            //Empty
        }
        public HomeController(IService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            //Redirect("https://api.instagram.com/oauth/authorize/?client_id=cb9ed86412594d1eb2bf9b7f83a73131&redirect_uri=http://localhost&response_type=code");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            //ViewBag.Message = "Your contact page.";
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