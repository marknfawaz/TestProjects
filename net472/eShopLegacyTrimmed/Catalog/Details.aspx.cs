using eShopLegacyTrimmed.Models;
using eShopLegacyTrimmed.Services;
using System;
using System.Web.UI;

namespace eShopLegacyTrimmed.Catalog
{
    public partial class Details : Page
    {
        protected CatalogItem product;

        public ICatalogService CatalogService { get; set; } = new CatalogServiceMock();

        protected void Page_Load(object sender, EventArgs e)
        {
            var productId = Convert.ToInt32(Page.RouteData.Values["id"]);
            product = CatalogService.FindCatalogItem(productId);

            this.DataBind();
        }
    }
}