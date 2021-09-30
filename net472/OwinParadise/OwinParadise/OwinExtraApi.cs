using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Authorization;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System.Security.Claims;

namespace PortingParadise
{
    public class OwinExtraApi
    {
        public void OwinAuthorization(IAuthorizationRequirement req)
        {
            List<IAuthorizationRequirement> listReq = new List<IAuthorizationRequirement>() { req };
            AuthorizationHandlerContext ahc = new AuthorizationHandlerContext(listReq, new ClaimsPrincipal(), null);
            ahc.Succeed(req);

            AuthorizationOptions aops = new AuthorizationOptions();
            AuthorizationPolicy apol = new AuthorizationPolicy(listReq, new List<string>() { "" });
            aops.AddPolicy("", apol);
            aops.AddPolicy("", policy => { });

            AuthorizationPolicyBuilder apolBuild = new AuthorizationPolicyBuilder(apol);
            apolBuild = apolBuild.AddRequirements(req);
        }

        public void OwinDataHandler(SecureDataFormat<AuthenticationProperties> secure)
        {
            AuthenticationProperties props = new AuthenticationProperties();

            string secured = secure.Protect(props);
            AuthenticationProperties unsecured = secure.Unprotect(secured);

            byte[] decoded = new byte[10];
        }
    }
}
