using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData.Extensions;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common;
using Owin;
using WebApiWithReferences.Models;
using WebApiWithReferences.Repositories;
using WebApiWithReferences.Services;
using WebApiContrib.IoC.Ninject;

[assembly: OwinStartup(typeof(WebApiWithReferences.Startup))]

namespace WebApiWithReferences
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration
            {
                DependencyResolver = new NinjectResolver(CreateKernel())
            };

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.AddODataQueryFilter();

            app.UseWebApi(config);
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IHouseRepository>().ToConstant(new HouseRepository());
            kernel.Bind<IHouseMapper>().To<HouseMapper>().InRequestScope();

            return kernel;
        }
    }
}
