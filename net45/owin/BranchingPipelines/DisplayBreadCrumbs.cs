using Microsoft.Owin;
using System.Threading.Tasks;

namespace BranchingPipelines
{
    public class DisplayBreadCrumbs : OwinMiddleware
    {
        public DisplayBreadCrumbs(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            IOwinRequest request = context.Request;
            IOwinResponse response = context.Response;
            response.ContentType = "text/plain";

            string responseText = request.Headers.Get("breadcrumbs") + "\r\n"
                + "PathBase: " + request.PathBase + "\r\n"
                + "Path: " + request.Path + "\r\n";

            return response.WriteAsync(responseText);
        }
    }
}