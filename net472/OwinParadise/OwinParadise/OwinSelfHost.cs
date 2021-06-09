using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PortingParadise
{
    class OwinSelfHost
    {
        public class Program
        {
            static void Main()
            {
                string baseAddress = "http://localhost:10281/";

                // Start OWIN host
                //using (WebApp.Start<Startup>(url: baseAddress))
                //{
                    // Create HttpCient and make a request to api/values
                    HttpClient client = new HttpClient();

                    HttpResponseMessage response = client.GetAsync(baseAddress + "api/values").Result;

                    Console.WriteLine(response);
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                //}

                Console.ReadLine();
            }
        }

        public class Startup
        {
            // This code configures Web API contained in the class Startup, which is additionally specified as the type parameter in WebApplication.Start
            public void Configuration(IAppBuilder appBuilder)
            {
                appBuilder.UseWebApi(new HttpConfiguration());
            }
        }

        public class ValuesController : ApiController
        {
            // GET api/values
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET api/values/5
            public string Get(int id)
            {
                return "value";
            }

            // POST api/values
            public void Post([FromBody] string value)
            {
            }

            // PUT api/values/5
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/values/5
            public void Delete(int id)
            {
            }
        }
    }
}
