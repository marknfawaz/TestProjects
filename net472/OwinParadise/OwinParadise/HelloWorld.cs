using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortingParadise
{
    class HelloWorld
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(Invoke);
        }

        public Task Invoke(IOwinContext context)
        {
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello World");
        }
    }
}
