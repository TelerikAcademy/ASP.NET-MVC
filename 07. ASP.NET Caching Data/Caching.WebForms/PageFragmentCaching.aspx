<%@ Page Title="Page Fragment Caching demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="Caching._Default" %>
<%@ Register Src="~/CacheableUserControl.ascx" TagPrefix="my" TagName="CacheableUserControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h2><%= Page.Title %></h2>
        <my:CacheableUserControl runat="server" />
    </div>
</asp:Content>