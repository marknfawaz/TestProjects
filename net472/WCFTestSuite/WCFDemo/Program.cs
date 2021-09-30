using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(EchoService), new Uri("net.tcp://localhost:8808/"), new Uri("https://localhost:8443/"));
            host.AddServiceEndpoint(typeof(IEchoService), new NetTcpBinding(), "/nettcp");
            BasicHttpBinding basicHttp = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            basicHttp.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new TestValidator();
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

    internal class TestValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            Console.WriteLine("UN = " + userName);
        //throw new NotImplementedException();
        }
    }
}