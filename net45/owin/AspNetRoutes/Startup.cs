using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;

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

        public async Task<bool> SignUpUser(IAuthenticationManager authenticationManager, ISecureDataFormat<AuthenticationTicket> df)
        {
            List<ClaimsIdentity> claims = new List<ClaimsIdentity>() { new ClaimsIdentity() };
            AuthenticationProperties authProp = new AuthenticationProperties();

            var authResult = await authenticationManager.AuthenticateAsync("");
            authenticationManager.Challenge(new string[] { "" });
            var authResults = await authenticationManager.AuthenticateAsync(new string[] { "", "" });
            authenticationManager.Challenge(authProp, new string[] { "" });
            var authTypes = authenticationManager.GetAuthenticationTypes();
            authenticationManager.SignIn(claims.ToArray());
            authenticationManager.SignOut(authProp, new string[] { "" });

            ExternalLoginInfo info = authenticationManager.GetExternalLoginInfo();
            ExternalLoginInfo infoAsync1 = await authenticationManager.GetExternalLoginInfoAsync();
            ExternalLoginInfo infoAsync2 = await authenticationManager.GetExternalLoginInfoAsync("key_here", "expected");
            List<AuthenticationDescription> desc = authenticationManager.GetExternalAuthenticationTypes().ToList();
            bool rem = authenticationManager.TwoFactorBrowserRemembered("userID");
            bool remAsync = await authenticationManager.TwoFactorBrowserRememberedAsync("userID");

            AuthenticationTicket at = new AuthenticationTicket(claims.First(), authProp);
            string prot = df.Protect(at);
            AuthenticationTicket unProtectedAT = df.Unprotect(prot);

            OAuthAuthorizationServerOptions auth = new OAuthAuthorizationServerOptions()
            {
                AccessTokenExpireTimeSpan = new TimeSpan(),
                AllowInsecureHttp = true,
            };

            return at.Equals(unProtectedAT);
        }

        public void Protector(IDataProtectionProvider protector)
        {
            string[] purposes = new string[] { "","" };
            IDataProtector prot1 = protector.Create(purposes);
            DpapiDataProtectionProvider dpapi = new DpapiDataProtectionProvider();
            IDataProtector prot2 = dpapi.Create(purposes);
        }
    }
}