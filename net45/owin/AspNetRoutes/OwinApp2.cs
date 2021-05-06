using System.Threading.Tasks;
using Microsoft.Owin;

namespace AspNetRoutes
{
    public class OwinApp2
    {
        // Invoked once per request.
        public static Task Invoke(IOwinContext context)
        {
            RequestCookieCollection cookies = context.Request.Cookies;
            string owinCookieValue = cookies["OwinCookieKey"];

            context.Request.QueryString = new QueryString("owin", "owinValue");
            IReadableStringCollection stringquery = context.Request.Query;
            string owinquery = stringquery["owin"];

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello World 2");
        }
    }
}