<%@ Page Title="Post-Cache Substitution demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostCacheSubstitution.aspx.cs" Inherits="Caching.PostCacheSubstitution" %>
<%@ OutputCache Duration="10" VaryByParam="none" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="Caching" %>

<script runat="server">
    protected static string GetCurrentTime(HttpContext ctx)
    {
        return DateTime.Now.ToLongTimeString();
    }
    protected static string GetNewNumber(HttpContext ctx)
    {
        return GlobalCounter.Next().ToString(CultureInfo.InvariantCulture);
    }
</script>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h2><%= Page.Title %></h2>
        <h3>Page loaded: <%= DateTime.Now.ToLongTimeString() %><br /></h3>
        <h3>Response.WriteSubstitution: <% Response.WriteSubstitution(GetCurrentTime); %></h3>
        <h3>GetCurrentTime (&lt;asp:Substitution&gt;): <asp:Substitution runat="server" MethodName="GetCurrentTime" /></h3>
        <h3>Page number on load: <%= GlobalCounter.Next() %></h3>
        <h3>Page number with Response.WriteSubstitution: <% Response.WriteSubstitution(GetNewNumber); %></h3>
    </div>
</asp:Content>
