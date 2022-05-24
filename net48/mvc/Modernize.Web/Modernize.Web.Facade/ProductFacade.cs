using Modernize.Web.Data;
using Modernize.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Web.Facade
{
    public class ProductFacade
    {
        private SqlProvider sqlProvider = new SqlProvider("");
        public List<Product> GetProducts() => sqlProvider.GetProducts();

        public void InsertProduct(Product Product) => sqlProvider.InsertProduct(Product);

        public void UpdateProduct(Product Product) => sqlProvider.UpdateProduct(Product);

        public void DeleteProduct(Product Product) => sqlProvider.DeleteProduct(Product);

        public Product GetProduct() => sqlProvider.GetProduct();
    }
}
