<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="WebAppSimpleASPX.Default" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <title>Hello</title>
</head>

<body>
    <form id="FormGreetings" runat="server">
        Enter your name:<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonGreetings" runat="server" Text="Greetings" OnClick="ButtonGreetings_Click" />
        <br />
        <asp:Literal ID="LiteralGreetings" Text="" Mode="Encode" runat="server" />
    </form>
</body>

</html>
