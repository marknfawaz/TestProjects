using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortingParadise
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class CustomServer
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string baseUrl = "http://localhost:12345/";

                //using (WebApp.Start<Startup>(new StartOptions(baseUrl) { ServerFactory = "MyCustomServer" }))
                //{
                    // Note: CustomServer has not actually been implemented, no requests will be accepted.

                    // Launch the browser
                    // Process.Start(baseUrl);

                    Console.WriteLine("Started, Press any key to stop.");
                    Console.ReadKey();
                    Console.WriteLine("Stopped");
                //}
            }
        }

        public class Startup
        {
            // Invoked once at startup to configure your application.
            public void Configuration(IAppBuilder app)
            {
                app.UseWelcomePage();
            }
        }

        public class CustomServerClass : IDisposable
        {

            internal CustomServerClass()
            {
                // Create a configurable instance
            }
            
            internal void Start(AppFunc next, IList<IDictionary<string, object>> addresses)
            {
                // Start a server that listens on the given address(es).

                // Listen for incoming requests.

                // Dispatch them into the OWIN pipeline by calling next.

                // Clean up the request when the AppFunc Task completes.

                // Shut down when Dispose is called.
            }

            public void Dispose()
            {
                // Stop
            }
        }

        public static class OwinServerFactory
        {
            /// <summary>
            /// Optional. This gives the server the chance to tell the application about what capabilities are supported.
            /// </summary>
            /// <param name="properties"></param>
            public static void Initialize(IDictionary<string, object> properties)
            {
                // TODO: Add Owin.Types.BuilderProperties for setting capabilities, etc..


                // Consider adding a configurable object to the properties if the application needs to set some specific server settings.
                properties[typeof(CustomServer).FullName] = new CustomServer();
            }

            public static IDisposable Create(AppFunc app, IDictionary<string, object> properties)
            {
                object obj;

                // Get the user configured server instance, if any.
                CustomServerClass server = null;
                if (properties.TryGetValue(typeof(CustomServer).FullName, out obj))
                {
                    server = obj as CustomServerClass;
                }
                server = server ?? new CustomServerClass();

                // Get the address collection
                IList<IDictionary<string, object>> addresses = null;
                if (properties.TryGetValue("host.Addresses", out obj))
                {
                    addresses = obj as IList<IDictionary<string, object>>;
                }

                server.Start(app, addresses);

                return server;
            }
        }
    }
}
