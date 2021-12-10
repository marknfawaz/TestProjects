<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsFull._Default" %>

<asp:Content ID="CatalogList" ContentPlaceHolderID="MainContent" runat="server">

    <div class="esh-table">
        <p class="esh-link-wrapper">
            <asp:Button ID="TestButton" Text="TestButton" OnClick="AddPerson" runat="server" /> |
            <span>Events Triggered:</span>
            <asp:Label ID="TestLabel" Text="<%#EventsTriggered%>" runat="server"/> |
            <asp:HyperLink ID="TestHyperLink" runat="server" NavigateUrl="OtherPage">
                OtherPageLink
            </asp:HyperLink>
        </p>

        <asp:GridView ID="PeopleGrid" runat="server" AutoGenerateColumns="false">
          <Columns>
            <asp:BoundField DataField="Name" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Position" HeaderText="Person Type" />
          </Columns>
        </asp:GridView>

        <asp:ListView ID="productList" ItemPlaceholderID="itemPlaceHolder" runat="server" ItemType="WebFormsFull.Models.CatalogItem">
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
                        <image class="esh-thumbnail" src='/Pics/<%#:Item.PictureFileName%>' />
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
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
