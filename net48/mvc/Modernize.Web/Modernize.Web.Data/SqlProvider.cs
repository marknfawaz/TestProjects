using Modernize.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Web.Data
{
    public class SqlProvider
    {
        private const int SQL_TIMEOUT = 5000;
        private const string _connectionStringSQLAuthFormat = "Server={0};initial catalog={1};User ID={2}; Password={3}";
        private const string _connectionStringWindowsAuthFormat = "Server={0};initial catalog={1}; integrated security=SSPI";

        private readonly string _connectionString;
        public SqlProvider(string server, string db)
        {
            _connectionString = string.Format(_connectionStringWindowsAuthFormat, server, db);
        }
        public SqlProvider(string server, string db, string username, string password)
        {
            _connectionString = string.Format(_connectionStringSQLAuthFormat, server, db, username, password);
        }
        public SqlProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetSampleData() => "Sample Data";

        public List<Product> GetProducts()
        {
            return new List<Product>();
        }

        public Product GetProduct()
        {
            return new Product();
        }

        public void InsertProduct(Product product)
        {

        }

        public void DeleteProduct(Product product)
        {

        }

        public void UpdateProduct(Product product)
        {

        }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>();
        }

        public Customer GetCustomer()
        {
            return new Customer();
        }

        public void InsertCustomer(Customer Customer)
        {

        }

        public void DeleteCustomer(Customer Customer)
        {

        }

        public void UpdateCustomer(Customer Customer)
        {

        }

        public List<Purchase> GetPurchases()
        {
            return new List<Purchase>();
        }

        public Purchase GetPurchase()
        {
            return new Purchase();
        }

        public void InsertPurchase(Purchase Purchase)
        {

        }

        public void DeletePurchase(Purchase Purchase)
        {

        }

        public void UpdatePurchase(Purchase Purchase)
        {

        }
    }
}
