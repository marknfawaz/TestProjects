using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace TC2CodeBasicHttpTransportSecurity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost sh = new ServiceHost(typeof(EchoService), new Uri("https://localhost:9000/")))
            {
                sh.AddServiceEndpoint(typeof(IEchoService), new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/basicHttps");
                sh.Open();
                foreach (var endpoint in sh.Description.Endpoints)
                {
                    Console.WriteLine("Listening on " + endpoint.ListenUri.ToString());
                }

                Console.WriteLine("Hit enter to close");
                Console.ReadLine();
                sh.Close();
            }
        }
    }
}