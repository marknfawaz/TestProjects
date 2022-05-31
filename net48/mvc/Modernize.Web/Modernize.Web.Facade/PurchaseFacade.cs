using Modernize.Web.Data;
using Modernize.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modernize.Web.Facade
{
    public class PurchaseFacade
    {
        public string GetSampleData() => new SqlProvider("empty_connection_string").GetSampleData();

        private SqlProvider sqlProvider = new SqlProvider("");
        public async Task<List<Purchase>> GetPurchases() => await sqlProvider.GetPurchases();

        public void InsertPurchase(Purchase Purchase) => sqlProvider.InsertPurchase(Purchase);

        public void UpdatePurchase(Purchase Purchase) => sqlProvider.UpdatePurchase(Purchase);

        public void DeletePurchase(Purchase Purchase) => sqlProvider.DeletePurchase(Purchase);

        public async Task<Purchase> GetPurchase() => await sqlProvider.GetPurchase();
    }
}
