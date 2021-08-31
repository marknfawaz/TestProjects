using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Authorization;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace OwinExtraAPI
{
    class Program
    {
        static void Main(string[] args)
        {

        }

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
    }
}
