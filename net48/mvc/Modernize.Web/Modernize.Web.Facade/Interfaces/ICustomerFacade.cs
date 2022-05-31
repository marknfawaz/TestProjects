using Modernize.Web.Models;
using System.Collections.Generic;

namespace Modernize.Web.Facade
{
    public interface ICustomerFacade
    {
        List<Customer> GetCustomers();

        void InsertCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        Customer GetCustomer();
    }
}
