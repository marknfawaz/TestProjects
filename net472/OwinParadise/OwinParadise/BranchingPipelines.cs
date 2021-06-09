using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity.Owin;

namespace PortingParadise
{
    class BranchingPipelines
    {
        public void Configuration(IAppBuilder app)
        {
            /*
            app.CreatePerOwinContext<AppBuilderProvider>(() => new AppBuilderProvider(app));
            app.CreatePerOwinContext((IdentityFactoryOptions<AppBuilderProvider> options, IOwinContext owin) => new AppBuilderProvider(app));
            app.CreatePerOwinContext(
                (IdentityFactoryOptions<AppBuilderProvider> options, IOwinContext owin) => new AppBuilderProvider(app),
                (IdentityFactoryOptions<AppBuilderProvider> options, AppBuilderProvider appProv) => new AppBuilderProvider(app));
            */
            app.Use<AddBreadCrumbMiddleware>("start-of-the-line");

            app.Map("/branch1", app1 =>
            {
                app1.Use<AddBreadCrumbMiddleware>("took-branch1");

                // Nesting paths, e.g. /branch1/branch2
                app1.Map("/branch2", app2 =>
                {
                    app2.Use<AddBreadCrumbMiddleware>("took-branch2");
                    app2.Use<DisplayBreadCrumbs>();
                });

                MapIfIE(app1);
                app1.Use<DisplayBreadCrumbs>();
            });

            // Only full segments are matched, so /branch1 does not match /branch100
            app.Map("/branch100", app1 =>
            {
                app1.Use<AddBreadCrumbMiddleware>("took-branch100");
                app1.Use<DisplayBreadCrumbs>();
            });

            MapIfIE(app);

            app.Use<AddBreadCrumbMiddleware>("no-branches-taken");
            app.Use<DisplayBreadCrumbs>();
        }

        private void MapIfIE(IAppBuilder app)
        {
            app.MapWhen(IsIE, app2 =>
            {
                app2.Use<AddBreadCrumbMiddleware>("took-IE-branch");
                app2.Use<DisplayBreadCrumbs>();
            });
        }

        private bool IsIE(IOwinContext context)
        {
            IHeaderDictionary headers = context.Request.Headers;
            return true; //headers.Get("User-Agent").Contains("Trident");
        }

        public class AppBuilderProvider : IDisposable
        {
            private IAppBuilder _app;
            public AppBuilderProvider(IAppBuilder app)
            {
                _app = app;
            }
            public IAppBuilder Get() { return _app; }
            public void Dispose() { }
        }

        public class AddBreadCrumbMiddleware : OwinMiddleware
        {
            private string _breadcrumb;

            public AddBreadCrumbMiddleware(OwinMiddleware next, string breadcrumb)
                : base(next)
            {
                _breadcrumb = breadcrumb;
            }

            public override Task Invoke(IOwinContext context)
            {
                IOwinRequest request = context.Request;
                request.Headers.Append("breadcrumbs", _breadcrumb);
                return Next.Invoke(context);
            }
        }

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

                string responseText = /*request.Headers.Get("breadcrumbs") +*/ "\r\n"
                    + "PathBase: " + request.PathBase + "\r\n"
                    + "Path: " + request.Path + "\r\n";

                return response.WriteAsync(responseText);
            }
        }
    }
}
