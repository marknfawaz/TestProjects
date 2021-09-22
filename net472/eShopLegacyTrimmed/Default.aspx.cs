using eShopLegacyTrimmed.Models;
using eShopLegacyTrimmed.Services;
using eShopLegacyTrimmed.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace eShopLegacyTrimmed
{
    public partial class _Default : Page
    {
        public const int DefaultPageIndex = 0;
        public const int DefaultPageSize = 10;

        public static ICatalogService CatalogService { get; set; } = new CatalogServiceMock();

        protected PaginatedItemsViewModel<CatalogItem> Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PaginationParamsAreSet())
            {
                var size = Convert.ToInt32(Page.RouteData.Values["size"]);
                var index = Convert.ToInt32(Page.RouteData.Values["index"]);
                Model = CatalogService.GetCatalogItemsPaginated(size, index);
            }
            else
            {
                Model = CatalogService.GetCatalogItemsPaginated(DefaultPageSize, DefaultPageIndex);
            }

            PeopleGrid.DataSource = new List<People>()
            {
                new People("Andy","Wayne", "PG"),
                new People( "Bill","Johnson", "SD" ),
                new People("Caroline","Barry", "Manager")
            };
            PeopleGrid.DataBind();

            ProductList.DataSource = Model.Data;
            ProductList.DataBind();
            ConfigurePagination();
        }

        private bool PaginationParamsAreSet()
        {
            return Page.RouteData.Values.Keys.Contains("size") && Page.RouteData.Values.Keys.Contains("index");
        }

        private void ConfigurePagination()
        {
            PaginationNext.NavigateUrl = GetRouteUrl("ProductsByPageRoute", new { index = Model.ActualPage + 1, size = Model.ItemsPerPage });
            var pagerNextExtraStyles = Model.ActualPage < Model.TotalPages - 1 ? "" : " esh-pager-item--hidden";
            PaginationNext.CssClass = PaginationNext.CssClass + pagerNextExtraStyles;

            PaginationPrevious.NavigateUrl = GetRouteUrl("ProductsByPageRoute", new { index = Model.ActualPage - 1, size = Model.ItemsPerPage });
            var pagerPreviousExtraStyles = Model.ActualPage > 0 ? "" : " esh-pager-item--hidden";
            PaginationPrevious.CssClass = PaginationPrevious.CssClass + pagerPreviousExtraStyles;
        }
    }
}