using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Web.Facade
{
    public class Factory
    {
        public static T GetFacade<T>()
        {
            if (typeof(T) == typeof(IProductFacade))
            {
                return (T)CreateProductFacade();
            }
            else if (typeof(T) == typeof(ICustomerFacade))
            {
                return (T)CreateCustomerFacade();
            }
            else if (typeof(T) == typeof(IPurchaseFacade))
            {
                return (T)CreatePurchaseFacade();
            }
            return default(T);
        }

        private static object CreateProductFacade()
        {
            return new ProductFacade();
        }

        private static object CreateCustomerFacade()
        {
            return new CustomerFacade();
        }

        private static object CreatePurchaseFacade()
        {
            return new PurchaseFacade();
        }
    }
}
