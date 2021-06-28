using SampleMvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        private void ModelFunctions()
        {
            var product = new Product();
            var properties = new string[] { "prop1", "prop2" };
            var excludeProperties = new string[] { "prop1", "prop2" };
            var valueProviderCollection = new ValueProviderCollection();

            TryUpdateModel(product);

            TryValidateModel(product);
            TryValidateModel(product, "prefix");

            TryUpdateModel<Product>(product);
            TryUpdateModel<Product>(product, valueProviderCollection); //Valueprovider?
            TryUpdateModel<Product>(product, "prefix");
            TryUpdateModel<Product>(product, properties);
            TryUpdateModel<Product>(product, "prefix", valueProviderCollection); //Valueprovider
            TryUpdateModel<Product>(product, "prefix", properties);
            TryUpdateModel<Product>(product, properties, valueProviderCollection);
            TryUpdateModel<Product>(product, "prefix", properties, valueProviderCollection);
            TryUpdateModel<Product>(product, "prefix", properties, excludeProperties);
            TryUpdateModel<Product>(product, "prefix", properties, excludeProperties, valueProviderCollection);
        }
    }
}