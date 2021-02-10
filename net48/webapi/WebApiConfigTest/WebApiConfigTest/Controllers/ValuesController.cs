using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace WebApiConfigTest.Controllers
{
    public class ValuesController : ApiController
    {
        private const string constConnectionString = "FirstConnectionString";
        private const string constAppSetting = "ClientValidationEnabled";
        // GET api/values
        public IEnumerable<string> Get()
        {
            var conn = ConfigurationManager.ConnectionStrings["FirstConnectionString"];
            var conn2 = ConfigurationManager.ConnectionStrings["SecondConnectionString"].ConnectionString;
            var conn3 = ConfigurationManager.ConnectionStrings[constConnectionString].ConnectionString;

            var webConn1 = WebConfigurationManager.ConnectionStrings["FirstConnectionString"];
            var webConn2 = WebConfigurationManager.ConnectionStrings["SecondConnectionString"].ConnectionString;
            var webConn3 = WebConfigurationManager.ConnectionStrings[constConnectionString].ConnectionString;

            var appSetting = ConfigurationManager.AppSettings["ClientValidationEnabled"];
            var appSetting3 = WebConfigurationManager.AppSettings[constAppSetting];

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
