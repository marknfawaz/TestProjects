using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace WebApiConfigTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

             // CTA: Test porting of WebRequestHandler
            WebRequestHandler handler = new WebRequestHandler();

            return View();
        }
    }
}
