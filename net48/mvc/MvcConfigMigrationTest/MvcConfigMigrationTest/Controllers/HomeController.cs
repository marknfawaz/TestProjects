using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MvcConfigMigrationTest.Controllers
{
    public class HomeController : Controller
    {
        private string constConnectionString = "FirstConnectionString";
        private string constAppSetting = "ClientValidationEnabled";
		
        public ActionResult Index()
        {
            var conn = ConfigurationManager.ConnectionStrings["FirstConnectionString"];
            var conn2 = ConfigurationManager.ConnectionStrings["SecondConnectionString"].ConnectionString;
            var conn3 = ConfigurationManager.ConnectionStrings[constConnectionString].ConnectionString;

            var webConn1 = WebConfigurationManager.ConnectionStrings["FirstConnectionString"];
            var webConn2 = WebConfigurationManager.ConnectionStrings["SecondConnectionString"].ConnectionString;
            var webConn3 = WebConfigurationManager.ConnectionStrings[constConnectionString].ConnectionString;

            var appSetting = ConfigurationManager.AppSettings["ClientValidationEnabled"];
            var appSetting2 = WebConfigurationManager.AppSettings["ClientValidationEnabled"];
            var appSetting3 = WebConfigurationManager.AppSettings[constAppSetting];

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}