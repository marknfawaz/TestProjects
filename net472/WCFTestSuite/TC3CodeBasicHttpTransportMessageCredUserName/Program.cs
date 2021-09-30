using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TC3CodeBasicHttpTransportMessageCredUserName
{
    class Program
    {
        //This test case specifically ensures we can /can't determine servicehost tied to contract or not
        private static ServiceHost ConfigureWcfHost<TService, TContract>(string servicePrefix)
        {
            Type contract = typeof(TContract);
            var host = new ServiceHost(typeof(TService), new Uri("https://localhost:9890"));
            var serverBindingHttpsUserPassword = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
            serverBindingHttpsUserPassword.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            host.AddServiceEndpoint(contract, serverBindingHttpsUserPassword, "/wsHttp");
            CustomUserNamePasswordValidator.AddToHost(host);
            return host;
        }

        static void Main()
        {
            var hostEchoService = ConfigureWcfHost<EchoService, IEchoService>("EchoService");
            hostEchoService.Open();
            Console.WriteLine("Hit enter to close");
            Console.ReadLine();
            hostEchoService.Close();
        }
    }

    internal class CustomUserNamePasswordValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            bool valid = userName.ToLowerInvariant().EndsWith("valid") && password.ToLowerInvariant().EndsWith("valid");
            if (!valid)
            {
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }

        public static void AddToHost(ServiceHostBase host)
        {
            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustomUserNamePasswordValidator();
        }
    }
}