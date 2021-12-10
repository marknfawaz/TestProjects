using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopLegacyWebForms.HttpHandlers
{
    public class TestHttpHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            // Do some request handling
            context.Response.StatusCode = 200;
        }
    }
}