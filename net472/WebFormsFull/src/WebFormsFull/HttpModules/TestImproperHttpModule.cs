using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopLegacyWebForms.HttpModules
{
    public class TestImproperHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += (source, arguments) =>
            {
                var application = (HttpApplication)source;
                var endContext = application.Context;
                // Do something at the end of the request
            };
        }

        public void Dispose()
        {
            // Do cleanup
        }
    }
}