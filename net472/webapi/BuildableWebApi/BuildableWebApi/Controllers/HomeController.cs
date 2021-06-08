using System.Configuration;
using System.Runtime.Caching;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BuildableWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var cache = new MemoryCache("MemoryCache");
            GetConfigurationValues();
            return View();
        }

        private void GetConfigurationValues()
        {
            string constConnectionString = "FirstConnectionString";
            string constAppSetting = "ClientValidationEnabled";

            var conn = ConfigurationManager.ConnectionStrings["FirstConnectionString"];
            var conn2 = ConfigurationManager.ConnectionStrings["SecondConnectionString"].ConnectionString;
            var conn3 = ConfigurationManager.ConnectionStrings[constConnectionString].ConnectionString;

            var webConn1 = WebConfigurationManager.ConnectionStrings["FirstConnectionString"];
            var webConn2 = WebConfigurationManager.ConnectionStrings["SecondConnectionString"].ConnectionString;
            var webConn3 = WebConfigurationManager.ConnectionStrings[constConnectionString].ConnectionString;

            var appSetting = ConfigurationManager.AppSettings["ClientValidationEnabled"];
            var appSetting3 = WebConfigurationManager.AppSettings[constAppSetting];

        }
    }
}
