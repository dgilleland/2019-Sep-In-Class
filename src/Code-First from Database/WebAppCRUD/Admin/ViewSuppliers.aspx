<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSuppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Suppliers</h1>

    <asp:ListView ID="SuppliersListView" runat="server"
        DataSourceID="SuppliersDataSource"
        ItemType="WestWindSystem.Entities.Supplier">
        <LayoutTemplate>
            <blockquote>
                <div id="itemPlaceholder" runat="server"></div>
            </blockquote>
        </LayoutTemplate>

        <ItemTemplate>
            <div>
                <b><%# Item.CompanyName %></b>
                &ndash;
                <i><%# Item.ContactName %></i>
                (<%# Item.ContactTitle %> - <%# Item.Phone %>)
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="SuppliersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
