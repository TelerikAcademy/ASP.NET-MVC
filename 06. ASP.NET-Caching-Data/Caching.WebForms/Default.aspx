<%@ Page Title="[OutputCache] demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Caching._Default" %>
<%@ Import Namespace="Caching" %>
<%--<%@ OutputCache Duration="10" VaryByParam="none" %>--%>
<%--<%@ OutputCache Duration="10" VaryByParam="none" Location="Server" %>--%>
<%--<%@ OutputCache Duration="15" VaryByParam="id" %>--%>
<%--<%@ OutputCache Duration="20" VaryByCustom="Browser" VaryByParam="none" %>--%>
<%--<%@ OutputCache CacheProfile="LongLived" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h2><%= Page.Title %></h2>
        <h3>Time: <%= DateTime.Now %></h3>
        <h3>Value of the "id" parameter: <%= Request.QueryString["id"] %></h3>
        <h3>Page number: <%= GlobalCounter.Next() %></h3>
    </div>
</asp:Content>
