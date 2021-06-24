using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortingParadise
{
    class StaticFilesSample
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:12345";
            //using (WebApp.Start<Startup>(url))
            //{
                Process.Start(url); // Launch the browser.
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            //}
        }

        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseErrorPage();

                PhysicalFileSystem defaultFS = new PhysicalFileSystem(@".\defaults");
                // Remap '/' to '.\defaults\'.
                // Turns on static files and default files.
                app.UseFileServer(new FileServerOptions()
                {
                    RequestPath = PathString.Empty,
                    FileSystem = defaultFS,
                });

                // Only serve files requested by name.
                app.UseStaticFiles("/files");

                // Turns on static files, directory browsing, and default files.
                app.UseFileServer(new FileServerOptions()
                {
                    RequestPath = new PathString("/public"),
                    EnableDirectoryBrowsing = true,
                });

                // Browse the root of your application (but do not serve the files).
                // NOTE: Avoid serving static files from the root of your application or bin folder,
                // it allows people to download your application binaries, config files, etc..
                app.UseDirectoryBrowser(new DirectoryBrowserOptions()
                {
                    RequestPath = new PathString("/src"),
                    FileSystem = new PhysicalFileSystem(@""),
                });

                // Anything not handled will land at the welcome page.
                app.UseWelcomePage();
            }
        }
    }
}
