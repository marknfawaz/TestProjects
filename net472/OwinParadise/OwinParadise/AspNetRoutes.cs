using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;

namespace PortingParadise
{
    public class AspNetRoutes
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(InvokeResponse);
        }

        // Invoked once per request.
        public Task InvokeResponse(IOwinContext context)
        {
            ResponseCookieCollection cookies = context.Response.Cookies;
            cookies.Append("OwinCookieKey", "OwinCookieValue");

            Uri.TryCreate(@"C:\Users", UriKind.Absolute, out Uri uriValue);
            PathString path = PathString.FromUriComponent(uriValue);
            bool check = path.Equals(new PathString(@"/C:/Users"));

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello World " + check);
        }

        public static Task InvokeRequest(IOwinContext context)
        {
            RequestCookieCollection cookies = context.Request.Cookies;
            string owinCookieValue = cookies["OwinCookieKey"];

            IReadableStringCollection stringquery = context.Request.Query;
            string owinquery = stringquery["owin"];

            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello World 2");
        }

        public async Task<bool> SignUpUser(IAuthenticationManager authenticationManager, ISecureDataFormat<AuthenticationTicket> df, AuthenticationTicket at)
        {
            List<ClaimsIdentity> claims = new List<ClaimsIdentity>() { new ClaimsIdentity() };
            AuthenticationProperties authProp = new AuthenticationProperties();

            var authResult = await authenticationManager.AuthenticateAsync("");
            authenticationManager.Challenge(new string[] { "" });
            var authResults = await authenticationManager.AuthenticateAsync(new string[] { "", "" });
            authenticationManager.Challenge(authProp, new string[] { "" });
            authenticationManager.SignOut(authProp, new string[] { "" });

            string prot = df.Protect(at);
            AuthenticationTicket unProtectedAT = df.Unprotect(prot);

            return at.Equals(unProtectedAT);
        }

        public void Protector(IDataProtectionProvider protector)
        {
            string[] purposes = new string[] { "", "" };
            IDataProtector prot1 = protector.Create(purposes);
        }

        public void UtilitiesLogger(ILogger logger, IAppBuilder app)
        {
            WebUtilities.AddQueryString("uri", new Dictionary<string, string>());
            WebUtilities.AddQueryString("uri", "name", "value");

            logger.WriteInformation("message");
        }
    }
}
