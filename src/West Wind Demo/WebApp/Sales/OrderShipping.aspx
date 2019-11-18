<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderShipping.aspx.cs" Inherits="WebApp.Sales.OrderShipping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Order Shipping</h1>

    <div class="row">
        <div class="col-md-12">
            <p>
                <!-- The asp:Literal renders it's content as plain text
                     (not wrapped in any HTML) -->
                <asp:Literal ID="SupplierInfo" runat="server" />
            </p>

            <asp:ListView ID="CurrentOrders" runat="server"
                DataSourceID="OrdersDataSource"
                ItemType="WestWindSystem.DataModels.OutstandingOrder">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("OrderId") %>' runat="server" ID="OrderIdTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("ShipToName") %>' runat="server" ID="ShipToNameTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("OrderDate") %>' runat="server" ID="OrderDateTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("RequiredBy") %>' runat="server" ID="RequiredByTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("DaysRemaining") %>' runat="server" ID="DaysRemainingTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("OutstandingItems") %>' runat="server" ID="OutstandingItemsTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("FullShippingAddress") %>' runat="server" ID="FullShippingAddressTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Comments") %>' runat="server" ID="CommentsTextBox" /></td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            (<%# Item.OrderId %>)
                            <%# Item.ShipToName %>
                        </td>
                        <td>
                            <%# Item.OrderDate.ToString("MMM dd, yyyy") %>
                        </td>
                        <td>
                            <%# Item.RequiredBy.ToString("MMM dd, yyyy") %>
                            - in <%# Item.DaysRemaining %> days
                        </td>
                        <td>
                            <asp:LinkButton ID="EditOrder" runat="server" CommandName="Edit" CssClass="btn btn-default">Ship Order</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" class="table table-hover">
                                    <tr runat="server" style="">
                                        <th runat="server">Shipped To</th>
                                        <th runat="server">Ordered On</th>
                                        <th runat="server">Required By</th>
                                        <th runat="server"></th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>

            <%--TODO: Switch out the hard-coded supplier ID--%>
            <asp:ObjectDataSource ID="OrdersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadOrders" TypeName="WestWindSystem.BLL.OrderProcessingController">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="supplierId" Type="Int32"></asp:Parameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
