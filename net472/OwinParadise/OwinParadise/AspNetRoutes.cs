using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortingParadise
{
    public class AspNetRoutes
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(Invoke);
        }

        // Invoked once per request.
        public Task Invoke(IOwinContext context)
        {
            ResponseCookieCollection cookies = context.Response.Cookies;
            cookies.Append("OwinCookieKey", "OwinCookieValue");

            Uri.TryCreate(@"C:\Users", UriKind.Absolute, out Uri uriValue);
            PathString path = PathString.FromUriComponent(uriValue);
            bool check = path.Equals(new PathString(@"/C:/Users"));

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello World " + check);
        }
    }
}
