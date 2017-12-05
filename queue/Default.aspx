<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QueueWR.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Mail Id: <asp:TextBox ID="mid" runat="server"></asp:TextBox>
        Subject: <asp:TextBox ID="sub" runat="server"></asp:TextBox>
        Message: <asp:TextBox ID="msg" runat="server"></asp:TextBox>
        <asp:Button ID="sumbmit" Text="Insert" runat="server" OnClick="sumbmit_Click" />
    </div>
    </form>
</body>
</html>
