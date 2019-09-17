<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="WebAppCRUD.Admin.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Products</h1>

    <asp:GridView ID="ProductGridView" runat="server"
         CssClass="table table-hover"
         AutoGenerateColumns="False"
         DataSourceID="ProductsDataSource"
         ItemType="WestWindSystem.Entities.Product">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID"></asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName"></asp:BoundField>
            
            <asp:TemplateField HeaderText="Supplier">
                <ItemTemplate>
                    <asp:DropDownList ID="SupplierDropDown" runat="server"
                        DataSourceID="SupplierDataSource"
                        SelectedValue="<%# Item.SupplierID %>"
                        DataTextField="CompanyName"
                        DataValueField="SupplierID"
                        Enabled="false"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="CategoryID" HeaderText="Category ID" SortExpression="CategoryID"></asp:BoundField>
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty / Unit" SortExpression="QuantityPerUnit"></asp:BoundField>
            <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Min Qty" SortExpression="MinimumOrderQuantity"></asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Price" SortExpression="UnitPrice"></asp:BoundField>
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="On Order" SortExpression="UnitsOnOrder"></asp:BoundField>
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ProductsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListProducts" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>

    <asp:ObjectDataSource runat="server" ID="CategoryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategorys" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>

    <asp:ObjectDataSource runat="server" ID="SupplierDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
