using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;

namespace CsharpClassLibrary
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
