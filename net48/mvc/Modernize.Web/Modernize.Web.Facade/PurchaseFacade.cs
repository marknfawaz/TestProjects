using Modernize.Web.Data;
using Modernize.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Web.Facade
{
    public class PurchaseFacade
    {
        public string GetSampleData() => new SqlProvider("empty_connection_string").GetSampleData();

        private SqlProvider sqlProvider = new SqlProvider("");
        public List<Purchase> GetPurchases() => sqlProvider.GetPurchases();

        public void InsertPurchase(Purchase Purchase) => sqlProvider.InsertPurchase(Purchase);

        public void UpdatePurchase(Purchase Purchase) => sqlProvider.UpdatePurchase(Purchase);

        public void DeletePurchase(Purchase Purchase) => sqlProvider.DeletePurchase(Purchase);

        public Purchase GetPurchase() => sqlProvider.GetPurchase();
    }
}
