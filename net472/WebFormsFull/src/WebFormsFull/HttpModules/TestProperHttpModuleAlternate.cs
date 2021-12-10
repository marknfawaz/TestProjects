using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopLegacyWebForms.HttpModules
{
    public class TestProperHttpModuleAlternate : IHttpModule
    {
        public string X { get; set; }

        public void Init(HttpApplication context)
        {
            context.ResolveRequestCache += new EventHandler(Application_ResolveRequestCache);
            context.PostResolveRequestCache += new EventHandler(Application_PostResolveRequestCache);
        }

        public void Application_ResolveRequestCache(object source, EventArgs e)
        {
            // Do some stuff here
            X = source.GetType().ToString();
        }

        public void Application_PostResolveRequestCache(object source, EventArgs e)
        {
            // Do some other stuff over here
            int x = 12;
            int y = x + 1;
            x = y - 1;

            X = x.ToString() + X;
        }

        public void Dispose()
        {
            // Do cleanup
        }
    }
}