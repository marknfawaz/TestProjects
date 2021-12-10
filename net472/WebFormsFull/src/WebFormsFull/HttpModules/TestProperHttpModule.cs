using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopLegacyWebForms.HttpModules
{
    public class TestProperHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(Application_EndRequest);
        }

        public void Application_EndRequest(object source, EventArgs e)
        {
            var application = (HttpApplication)source;
            var endContext = application.Context;
            // Do something at the end of the request
        }

        public void Dispose()
        {
            // Do cleanup
        }
    }
}