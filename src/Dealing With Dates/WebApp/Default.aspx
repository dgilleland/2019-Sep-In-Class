<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Dealing With Dates</h1>
        <p class="lead">Date-related data in the Web & Entity Framework requires some thinking. How</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <p>A number of different <code>type</code> values can be used on the <code>&lt;input ... /&gt;</code> element for dealing with dates and times. Additionally, each browser renders those elements differently, so much so that developers/designers often look to 3rd-party libraries to bring consistency to the user experience. Here, however, we're looking at the date/time input variations as shown in the Chrome browser.</p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Straight HTML</h2>
            <asp:LinkButton ID="ParseHtmlInput" runat="server" CssClass="btn btn-primary" OnClick="ParseHtmlInput_Click">Parse HTML Input</asp:LinkButton>
            <dl>
                <dt><input id="HtmlDate" runat="server" type="date" name="date_Sample" /> <label>Date</label></dt>
                <dd></dd>
                <dt><input id="HtmlDateTime" runat="server" type="datetime" name="dateTime_Sample" /> <label>DateTime</label></dt>
                <dd></dd>
                <dt><input id="HtmlDateTimeLocal" runat="server" type="datetime-local" name="dateTimeLocal_Sample" /> <label>DateTime-Local</label></dt>
                <dd></dd>
                <dt><input id="HtmlTime" runat="server" type="time" name="time_Sample" /> <label>Time</label></dt>
                <dd></dd>
                <dt><input id="HtmlWeek" runat="server" type="week" name="week_Sample" /> <label>Week</label></dt>
                <dd></dd>
                <dt><input id="HtmlMonth" runat="server" type="month" name="month_Sample" /> <label>Month</label></dt>
                <dd></dd>
            </dl>
        </div>
        <div class="col-md-4">
            <h2>Output</h2>
            <output id="PostBackOutput" runat="server" />
        </div>
        <div class="col-md-4">
            <h2>ASP.Net TextBox</h2>
            <asp:LinkButton ID="ParseTextBoxInput" runat="server" CssClass="btn btn-primary" OnClick="ParseTextBoxInput_Click">Parse <code>&lt;asp:TextBox /&gt;</code> Input</asp:LinkButton>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
