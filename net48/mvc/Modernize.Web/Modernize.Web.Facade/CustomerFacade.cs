using Modernize.Web.Data;
using Modernize.Web.Models;
using System.Collections.Generic;

namespace Modernize.Web.Facade
{
    public class CustomerFacade : ICustomerFacade
    {
        private SqlProvider sqlProvider = new SqlProvider("");
        public List<Customer> GetCustomers() => sqlProvider.GetCustomers();

        public void InsertCustomer(Customer customer) => sqlProvider.InsertCustomer(customer);

        public void UpdateCustomer(Customer customer) => sqlProvider.UpdateCustomer(customer);

        public void DeleteCustomer(Customer customer) => sqlProvider.DeleteCustomer(customer);

        public Customer GetCustomer() => sqlProvider.GetCustomer();        
    }
}
