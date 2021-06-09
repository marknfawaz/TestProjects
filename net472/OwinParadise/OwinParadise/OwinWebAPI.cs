using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PortingParadise
{
    class OwinWebAPI
    {
        public class Startup
        {
            // Invoked once at startup to configure your application.
            public void Configuration(IAppBuilder builder)
            {
                builder.UseWebApi(new HttpConfiguration(new HttpRouteCollection()));
            }
        }

        public class CustomerController : ApiController
        {
            public CustomerController()
            {
            }

            // Gets
            [HttpGet]
            public Customer Get(string customerId)
            {
                return new Customer()
                {
                    ID = Int32.Parse(customerId),
                    LastName = "Smith",
                    FirstName = "Mary",
                    HouseNumber = "333",
                    Street = "Main Street NE",
                    City = "Redmond",
                    State = "WA",
                    ZipCode = "98053"
                };
            }
        }

        [DataContract]
        public class Customer
        {
            [DataMember]
            public int ID { get; set; }

            [DataMember]
            public string LastName { get; set; }

            [DataMember]
            public string FirstName { get; set; }

            [DataMember]
            public string HouseNumber { get; set; }

            [DataMember]
            public string Street { get; set; }

            [DataMember]
            public string City { get; set; }

            [DataMember]
            public string State { get; set; }

            [DataMember]
            public string ZipCode { get; set; }
        }
    }
}
