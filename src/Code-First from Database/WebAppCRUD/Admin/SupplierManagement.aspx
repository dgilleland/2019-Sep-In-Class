<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierManagement.aspx.cs" Inherits="WebAppCRUD.Admin.SupplierManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Supplier Management System</h1>
    <h2>Supplier Summary</h2>

    <asp:Repeater ID="SupplierSummaryRepeater" runat="server"
        DataSourceID="SupplierSummaryDataSource"
        ItemType="WestWindSystem.ReadModels.SupplierSummary">
        <ItemTemplate>
            <div>
                <b><%# Item.CompanyName %></b>
                <i>TODO: Show supplier contact, phone</i>
                <asp:Repeater ID="ProductDetailsRepeater" runat="server"
                    DataSource="<%# Item.Products %>"
                    ItemType="WestWindSystem.ReadModels.SupplierProduct">
                    <HeaderTemplate><blockquote></HeaderTemplate>
                    <FooterTemplate></blockquote></FooterTemplate>
                    <ItemTemplate>
                        <div>
                            <b><%# Item.Name %></b>
                            <%# Item.Price.ToString("C") %>
                            <i>TODO: Show other details</i>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="SupplierSummaryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSupplierSummary" TypeName="WestWindSystem.BLL.SupplierManager"></asp:ObjectDataSource>
</asp:Content>
