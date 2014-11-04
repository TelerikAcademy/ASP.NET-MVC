<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="SQL_Injection_Example.Default" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <title>SQL injection Example</title>
</head>

<body>
    <form id="formLogin" runat="server">
        
        <h1>Messages</h1>
        <asp:ListView ID="ListViewMessages" runat="server" ItemType="SQL_Injection_Example.Message">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
                </ul>                
            </LayoutTemplate>
            <ItemTemplate>
                <li><%#: Item.MessageText %> (<%#: Item.MessageDate %>)
            </ItemTemplate>
            <EmptyDataTemplate><i>No messages found</i></EmptyDataTemplate>
        </asp:ListView>

        <h1>Search</h1>
        <asp:TextBox ID="TextBoxSearch" runat="server" /> 
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />

        <h1>Search hints</h1>
        Try the following searches:
        <ul>
            <li>am <i>(works correctly)</i></li>
            <li>~ <i>(works correctly)</i></li>
            <li>% <i>(matches all messages)</i></li>
            <li>%% <i>(matches all messages)</i></li>
            <li>30 <i>(matches all messages containing '30')</i></li> 
            <li>30% <i>(matches all messages containing '30')</i></li> 
            <li>' <i>(crashes)</i></li>
            <li>'; INSERT INTO Messages(MessageText, MessageDate) VALUES ('Hacked!!!', '1.1.1980') -- <i>(injects a neq message)</i></li>
            <li>'; DELETE FROM Messages -- <i>Hope you have a backup</i></li>
        </ul>
    </form>
</body>

</html>
