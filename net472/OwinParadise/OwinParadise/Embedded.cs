using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortingParadise
{
    class Embedded
    {
        public class Startup
        {
            // Invoked once at startup to configure your application.
            public void Configuration(IAppBuilder app)
            {
                app.UseWelcomePage();
            }
        }

        public static void Main(string[] args)
        {
            string baseUrl = "http://localhost:12345/";

            //using (WebApp.Start<Startup>(new StartOptions(baseUrl) { ServerFactory = "Microsoft.Owin.Host.HttpListener" }))
            //{
                // Launch the browser
                Process.Start(baseUrl);

                // Keep the server going until we're done
                Console.WriteLine("Press Any Key To Exit");
                Console.ReadKey();
            //}
        }
    }
}
