<%@ Page Title="Cache Dependencies demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CacheDependencies.aspx.cs" Inherits="Caching.CacheDependencies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h1><%= Page.Title %></h1>
        <h2>Value taken from cache: <span id="currentTimeSpan" runat="server"></span></h2>
        <h2>File path: <span id="filePathSpan" runat="server"></span></h2>
    </div>
</asp:Content>
