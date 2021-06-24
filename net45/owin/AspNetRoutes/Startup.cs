using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System;
using Microsoft.Owin.Security;
using System.Web;
using System.Security.Claims;
using System.Collections.Generic;

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

            Uri.TryCreate(@"C:\Users", UriKind.Absolute, out Uri uriValue);
            PathString path = PathString.FromUriComponent(uriValue);
            bool check = path.Equals(new PathString(@"/C:/Users"));

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello World " + check);
        }

        public async Task<bool> SignUpUser(IAuthenticationManager authenticationManager)
        {
            List<ClaimsIdentity> claims = new List<ClaimsIdentity>();
            AuthenticationProperties authProp = new AuthenticationProperties();

            var authResult = await authenticationManager.AuthenticateAsync("");
            authenticationManager.Challenge(new string[]{ "" });
            var authTypes = authenticationManager.GetAuthenticationTypes();
            authenticationManager.SignIn(claims.ToArray());
            authenticationManager.SignOut(authProp, new string[] { "" });

            return true;
        }
    }
}