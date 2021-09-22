<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eShopLegacyTrimmed._Default" %>

<asp:Content ID="CatalogList" ContentPlaceHolderID="MainContent" runat="server">
    <div class="esh-link-wrapper">

    </div>
    
    <div class="esh-table">
        <p class="esh-link-wrapper">
            <a runat="server" href="/Create" class="btn esh-button esh-button-primary">
                Create New
            </a>
            <a runat="server" href="/About" class="btn esh-button esh-button-primary">
                About
            </a>
            <a runat="server" href="/Contact" class="btn esh-button esh-button-primary">
                Contact
            </a>
        </p>

        <asp:GridView ID="PeopleGrid" runat="server" AutoGenerateColumns="false">
          <Columns>
            <asp:BoundField DataField="Name" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Position" HeaderText="Person Type" />
          </Columns>
        </asp:GridView>

        <asp:ListView ID="ProductList" ItemPlaceholderID="itemPlaceHolder" runat="server" ItemType="eShopLegacyTrimmed.Models.CatalogItem">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr class="esh-table-header">
                            <th></th>
                            <th>Name
                            </th>
                            <th>Description
                            </th>
                            <th>Brand
                            </th>
                            <th>Type
                            </th>
                            <th>Price
                            </th>
                            <th>Picture name
                            </th>
                            <th>Stock
                            </th>
                            <th>Restock
                            </th>
                            <th>Max stock
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img class="esh-thumbnail" src='/Pics/<%#:Item.PictureFileName%>' />
                    </td>
                    <td>
                        <p>
                            <%#:Item.Name%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.Description%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.CatalogBrand.Brand%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.CatalogType.Type%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <span class="esh-price"><%#:Item.Price%></span>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.PictureFileName%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.AvailableStock%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.RestockThreshold%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.MaxStockThreshold%>
                        </p>
                    </td>
                    <td>
                        <asp:HyperLink NavigateUrl='<%#: "/Catalog/Edit/" + Item.Id %>' runat="server" CssClass="esh-table-link">
                            Edit
                        </asp:HyperLink>
                        |
                        <asp:HyperLink NavigateUrl='<%#: "/Catalog/Details/" + Item.Id %>' runat="server" CssClass="esh-table-link">
                            Details
                        </asp:HyperLink>
                        |
                        <asp:HyperLink NavigateUrl='<%#: "/Catalog/Delete/" + Item.Id %>' runat="server" CssClass="esh-table-link">
                            Delete
                        </asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div class="esh-pager">
        <div class="container">
            <article class="esh-pager-wrapper row">
                <nav>
                    <asp:HyperLink ID="PaginationPrevious" runat="server" CssClass="esh-pager-item esh-pager-item--navigable">
                        Previous
                    </asp:HyperLink>

                    <span class="esh-pager-item">Showing <%: Model.ItemsPerPage%> of <%: Model.TotalItems%> products - Page <%: (Model.ActualPage + 1)%> - <%: Model.TotalPages%>
                    </span>

                    <asp:HyperLink ID="PaginationNext" runat="server" CssClass="esh-pager-item esh-pager-item--navigable">
                        Next
                    </asp:HyperLink>
                </nav>
            </article>
        </div>
    </div>
</asp:Content>