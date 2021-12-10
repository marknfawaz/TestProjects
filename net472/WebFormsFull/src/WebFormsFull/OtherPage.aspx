<%@ Page Title="Form Controls" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OtherPage.aspx.cs" Inherits="WebFormsFull.OtherPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:TextBox ID="SLTTB" Text="Single Line Textbox" TextMode="SingleLine" runat="server"/>
    <br /><br />
    <asp:TextBox ID="PWTB" TextMode="Password" runat="server"/>
    <br /><br />
    <asp:TextBox ID="MLTB" Text="Multi Line TextBox" TextMode="MultiLine" runat="server"/>
    <br /><br />
    <asp:RadioButton ID="RadioTest11" GroupName="TestGroup1" Text="Radio Test 1-1" runat="server"/>
    <asp:RadioButton ID="RadioTest12" GroupName="TestGroup1" Text="Radio Test 1-2" runat="server"/>
    <asp:RadioButton ID="RadioTest13" GroupName="TestGroup1" Text="Radio Test 1-3" runat="server"/>
    <br />
    <asp:RadioButton ID="RadioTest21" GroupName="TestGroup2" Text="Radio Test 2-1" runat="server"/>
    <asp:RadioButton ID="RadioTest22" GroupName="TestGroup2" Text="Radio Test 2-2" runat="server"/>
</asp:Content>
