using BuildableMvc.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using BuildableMvc.Attributes;

namespace BuildableMvc.Controllers
{
    public class HomeController : Controller
    {
        SqlDbAccess sqlDbAccess = new SqlDbAccess();
        public ActionResult Index()
        {
            return View();
        }

        [CustomAttribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            Server.HtmlEncode("this is a random string");

            HttpContextBase httpContext = HttpContext;
            
            return View();
        }

        [Authorize]
        public ActionResult ContactInternal()
        {
            ViewBag.Message = "Your internal contact page.";

            var objects = new List<string> { "item 1", "item 2" };
            var selectList = new SelectList(objects);
            FormCollection formCollection;

            return View();

        }
    }
}