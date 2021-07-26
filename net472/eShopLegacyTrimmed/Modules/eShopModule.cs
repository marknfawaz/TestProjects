using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopLegacyTrimmed.Modules
{
    public class eShopModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.EndRequest += (new EventHandler(Application_EndRequest));
        }

        private void Application_EndRequest(object source, EventArgs e)
        {
            // Do something with context near the end of request processing.
        }

        public void Dispose() { }
    }
}