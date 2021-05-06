using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace AspNetRoutes
{
    public class Startup
    {
        // Invoked once at startup to configure your application.
        public void Configuration(IAppBuilder app)
        {
            app.Run(Invoke);
        }

        // Invoked once per request.
        public Task Invoke(IOwinContext context)
        {
            ResponseCookieCollection cookies = context.Response.Cookies;
            cookies.Append("OwinCookieKey", "OwinCookieValue");

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello World");
        }
    }
}