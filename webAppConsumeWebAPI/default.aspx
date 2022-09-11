<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="webAppConsumeWebAPI._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="btnGet" Text="getEmployees" OnClick="btnGet_Click" />
            <br />
            <asp:Label runat  ="server" ID ="lblMsg"></asp:Label>
        </div>
    </form>
</body>
</html>
