<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheableUserControl.ascx.cs" Inherits="Caching.CacheableUserControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="true" %>

<h2>I am a cachable user control</h2>
<h2>My time is: <%= DateTime.Now.ToString() %></h2>