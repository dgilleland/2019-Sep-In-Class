<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAddresses.aspx.cs" Inherits="WebAppCRUD.Admin.ViewAddresses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Addresses CRUD</h1>

    <asp:ObjectDataSource runat="server" ID="AddressDataSource" DataObjectTypeName="WestWindSystem.Entities.Address" DeleteMethod="DeleteAddress" InsertMethod="AddAddress" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController" UpdateMethod="UpdateAddress"></asp:ObjectDataSource>
</asp:Content>
