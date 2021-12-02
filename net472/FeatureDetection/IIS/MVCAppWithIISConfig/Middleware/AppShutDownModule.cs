using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMvcApplication
{
    public class AppShutDownModule : IHttpModule
    {
        public void Dispose()
        {
        }

        //comment this constructor
        // this method is used for registering events
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;
            if (TerminateRequest())
            {
                //context.Response.End();
                //return;
            }
            // Do something with context near the beginning of request processing.
        }

        private bool TerminateRequest()
        {
            return true;
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpContext context = ((HttpApplication)source).Context;

            // Do something with context near the end of request processing.
        }

    }
}