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
    class SignalR
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR();
            }
        }

        static void Main(string[] args)
        {
            string uri = "http://localhost:9999/";
            //using (WebApp.Start<Startup>(uri))
            //{
                Console.WriteLine("Started");
                // Open the SignalR negotiation page to make sure things are working.
                Process.Start(uri + "signalr/negotiate");
                Console.ReadKey();
                Console.WriteLine("Finished");
            //}
        }
    }
}
