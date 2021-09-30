using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedeBasicHttpNetTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost sh = new ServiceHost(typeof(EchoService), new Uri("http://localhost:8000/"), new Uri("net.tcp://localhost:8808/")))
            {
                sh.AddServiceEndpoint(typeof(IEchoService), new BasicHttpBinding(), "/basicHttp");
                sh.AddServiceEndpoint(typeof(IEchoService), new NetTcpBinding(SecurityMode.Transport), "/netTcp");
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