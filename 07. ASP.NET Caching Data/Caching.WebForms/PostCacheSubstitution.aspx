<%@ Page Title="Post-Cache Substitution demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostCacheSubstitution.aspx.cs" Inherits="Caching.PostCacheSubstitution" %>
<%@ OutputCache Duration="10" VaryByParam="none" %>

<script runat="server">
   protected static string GetCurrentTime(HttpContext ctx) {
      return DateTime.Now.ToString();
   }
</script>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h1><%= Page.Title %></h1>
        <h2><%= DateTime.Now %><br /></h2>
        <h2>Response.WriteSubstitution: <% Response.WriteSubstitution(GetCurrentTime); %></h2>
        <h2>GetCurrentTime: <asp:Substitution runat="server" MethodName="GetCurrentTime" /></h2>
    </div>
</asp:Content>
