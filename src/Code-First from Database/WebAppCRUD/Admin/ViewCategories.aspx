<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCategories.aspx.cs" Inherits="WebAppCRUD.Admin.ViewCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Categories</h1>

    <asp:Repeater ID="CategoryRepeater" runat="server"
         DataSourceID="CategoryDataSource"
         ItemType="WestWindSystem.Entities.Category">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li>
                <b><%# Item.CategoryName %></b>
                &mdash;
                <i><%# Item.Description %></i>
                <img src="data:<%# Item.PictureMimeType %>;base64,<%# Convert.ToBase64String(Item.Picture) %>" width="50" />
            </li>
        </ItemTemplate>
        <SeparatorTemplate><hr /></SeparatorTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="CategoryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategorys" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
