﻿using Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BranchingPipelines
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppBuilderProvider>(() => new AppBuilderProvider(app));
            app.CreatePerOwinContext((IdentityFactoryOptions<AppBuilderProvider> options, IOwinContext owin) => new AppBuilderProvider(app));
            app.CreatePerOwinContext(
                (IdentityFactoryOptions<AppBuilderProvider> options, IOwinContext owin) => new AppBuilderProvider(app),
                (IdentityFactoryOptions<AppBuilderProvider> options, AppBuilderProvider appProv) => new AppBuilderProvider(app));

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
            return headers.Get("User-Agent").Contains("Trident");
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
    }
}