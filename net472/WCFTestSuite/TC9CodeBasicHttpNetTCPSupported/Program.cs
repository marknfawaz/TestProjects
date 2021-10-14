using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace TC9CodeBasicHttpNetTCPSupported
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(EchoService), new Uri("net.tcp://localhost:8808/"), new Uri("https://localhost:8443/"));
            host.AddServiceEndpoint(typeof(IEchoService), new NetTcpBinding(), "/nettcp");
            BasicHttpBinding basicHttp = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            basicHttp.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
            host.AddServiceEndpoint(typeof(IEchoService), basicHttp, "/basichttp");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpsGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.Open();
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("Listening on " + endpoint.ListenUri.ToString());
            }

            Console.WriteLine("Hit enter to close");
            Console.ReadLine();
            host.Close();
        }
    }
}