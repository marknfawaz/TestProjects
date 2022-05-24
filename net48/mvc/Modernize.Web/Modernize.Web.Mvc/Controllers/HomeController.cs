using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Modernize.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            StringBuilder str = new StringBuilder();
            //Gets physical path of the application root directory
            str.AppendLine(Server.MapPath("~"));

            //Current directory of executable running the app
            str.AppendLine(Directory.GetCurrentDirectory());

            ViewBag.Message = str.ToString();

            return View();
        }

        public ActionResult Contact()
        {
            var username = Registry.CurrentUser.Name;

            var installedNetVersions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\.NETFramework").GetSubKeyNames().Where(n => Regex.Match(n, @"v[1-9](\.\d+)+").Success);
            ViewBag.Message = string.Join(Environment.NewLine, installedNetVersions);

            return View();
        }
    }
}