<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableRole.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>First Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="FNTB" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Last Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="LNTB" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Contact Number</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="CNTB" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Contact Type</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="CTDL" runat="server">
                        <asp:ListItem Value="Family">Family</asp:ListItem>
                        <asp:ListItem Value="Friends">Friends</asp:ListItem>
                        <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Button OnClick="Submit_Click" ID="Submit" runat="server" Text="Insert Record" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
