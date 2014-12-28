<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PriceFeedGenerator.aspx.cs" Inherits="Bazaar.Pages.PriceFeedGenerator" %>
<%@ OutputCache Duration="60" VaryByParam="*" Location="Any" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Literal runat="server" ID="LtrNews"></asp:Literal>
    </div>
    </form>
</body>
</html>
