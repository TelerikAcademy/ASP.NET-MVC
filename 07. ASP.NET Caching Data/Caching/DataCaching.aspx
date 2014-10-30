<%@ Page Title="Data Caching demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataCaching.aspx.cs" Inherits="Caching.DataCaching" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h1><%= Page.Title %></h1>
        <h2>Value taken from cache: <span id="currentTimeSpan" runat="server"></span></h2>
    </div>
</asp:Content>