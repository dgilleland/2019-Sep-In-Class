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
                OnItemCommand="CurrentOrders_ItemCommand"
                ItemType="WestWindSystem.DataModels.OutstandingOrder">
                <EditItemTemplate>
                    <tr class="bg-info">
                        <td>
                            <asp:Label Text='<%# Item.OrderId %>' runat="server" ID="OrderIdLabel" />
                            <asp:Label Text='<%# Item.ShipToName %>' runat="server" ID="ShipToNameLabel" />
                        </td>
                        <td>
                            <%# Item.OrderDate.ToString("MMM dd, yyyy") %>
                        </td>
                        <td>
                            <%# Item.RequiredBy.ToString("MMM dd, yyyy") %>
                            - in <%# Item.DaysRemaining %> days
                        </td>
                        <td>
                            <asp:LinkButton ID="Cancel" runat="server" CommandName="Cancel" CssClass="btn btn-default">Close</asp:LinkButton>
                        </td>
                    </tr>
                    <tr class="bg-info">
                        <td colspan="4">
                            <asp:Label ID="OrderComments" runat="server" Text="<%# Item.Comments %>" />
                            <asp:DropDownList ID="ShipperDropDown" runat="server"
                                CssClass="form-control"
                                DataSourceID="ShippersDataSource"
                                DataTextField="Shipper" DataValueField="ShipperId"
                                AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[Select a Shipper]</asp:ListItem>
                            </asp:DropDownList>
                            <asp:GridView ID="ProductsGridView" runat="server"
                                CssClass="table table-hover table-condensed"
                                DataSource="<%# Item.OutstandingItems %>"
                                ItemType="WestWindSystem.DataModels.OrderProductInformation"
                                AutoGenerateColumns="false"
                                DataKeyNames="ProductId">
                                <Columns>
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                    <asp:BoundField DataField="QtyPerUnit" HeaderText="Qty per Unit" />
                                    <asp:BoundField DataField="Outstanding" HeaderText="Outstanding" />
                                    <asp:TemplateField HeaderText="Ship Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ShipQuantity" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="ShippingAddress" runat="server" Text="<%# Item.FullShippingAddress %>" />
                            <asp:TextBox ID="TrackingCode" runat="server" />
                            <asp:TextBox ID="FreightCharge" runat="server" />
                            <asp:LinkButton ID="ShipOrder" runat="server"
                                CommandName="Ship" CssClass="btn btn-primary">
                                Ship Order
                            </asp:LinkButton>
                        </td>
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
                            <asp:LinkButton ID="EditOrder" runat="server" CommandName="Edit" CssClass="btn btn-default">Order Details</asp:LinkButton>
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

            <asp:ObjectDataSource ID="ShippersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListShippers" TypeName="WestWindSystem.BLL.OrderProcessingController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
