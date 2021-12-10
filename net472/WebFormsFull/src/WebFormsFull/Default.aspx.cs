using WebFormsFull.Models;
using WebFormsFull.Services;
using WebFormsFull.ViewModel;
using System;
using System.Web.UI;
using System.Collections.Generic;

namespace WebFormsFull
{
    public partial class _Default : Page
    {
        public const int DefaultPageIndex = 0;
        public const int DefaultPageSize = 2;

        public ICatalogService CatalogService { get; set; }

        protected int EventsTriggered { get; set; }
        protected PaginatedItemsViewModel<CatalogItem> Model { get; set; }
        protected List<People> PeopleModel { get; set; }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EventsTriggered += 1;

            Model = CatalogService.GetCatalogItemsPaginated(DefaultPageSize, DefaultPageIndex);
            PeopleModel = new List<People>()
            {
                new People("Andy","Wayne", "PG"),
                new People("Bill","Johnson", "SD"),
                new People("Caroline","Barry", "Manager")
            };

            PeopleGrid.DataSource = PeopleModel;
            PeopleGrid.DataBind();

            productList.DataSource = Model.Data;
            productList.DataBind();

            DataBind();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            EventsTriggered += 1;
            DataBind();
        }

        protected void AddPerson(object sender, EventArgs e)
        {
            PeopleModel.Add(new People("New", "New", "New"));
            PeopleGrid.DataBind();
        }
    }
}