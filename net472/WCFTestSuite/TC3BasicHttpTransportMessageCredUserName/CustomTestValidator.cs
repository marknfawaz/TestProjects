using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace TC3BasicHttpTransportMessageCredUserName
{
    public class CustomTestValidator : UserNamePasswordValidator
    {
        // This method validates users. It allows in two users, test1 and test2
        // with passwords 1tset and 2tset respectively.
        // This code is for illustration purposes only and
        // must not be used in a production environment because it is not secure.	
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "test1" && password == "1tset") && !(userName == "test2" && password == "2tset"))
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown Username or Incorrect Password");
            // When you do not want to throw an infomative fault to the client,
            // throw the following exception.
            // throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }
        }
    }
}