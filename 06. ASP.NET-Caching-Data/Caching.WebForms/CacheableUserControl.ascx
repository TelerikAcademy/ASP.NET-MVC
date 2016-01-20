<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheableUserControl.ascx.cs" Inherits="Caching.CacheableUserControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="true" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="Caching" %>
<div style="outline: 3px solid black; padding: 10px;">
    <h3>I am a cachable user control</h3>
    <h3>My time is: <%= DateTime.Now.ToString(CultureInfo.InvariantCulture) %></h3>
    <h3>My number is: <%= GlobalCounter.Next() %></h3>
</div>