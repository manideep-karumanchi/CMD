<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableRole.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="InsertTable" runat="server">
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
        <div>
            <fieldset id="editfs" runat="server" visible="false">
                First Name: <asp:TextBox ID="EFNTB" runat="server"></asp:TextBox><br />
                Last Name: <asp:TextBox ID="ELNTB" runat="server"></asp:TextBox><br />
                Contact Number: <asp:TextBox ID="ECNTB" runat="server"></asp:TextBox><br />
                Contact Type: <asp:TextBox ID="ECTTB" runat="server"></asp:TextBox><br />
                <asp:Button ID="RB" runat="server" Text="Replace" OnClick="RB_Click" />
                <asp:Button ID="DB" runat="server" Text="Delete" OnClick="DB_Click" />

            </fieldset>
        </div>
        <hr />
        <asp:GridView ID="ContactsGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="ContactsGrid_RowCommand">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="RowKey" HeaderText="Contact Number" />
                <asp:BoundField DataField="PartitionKey" HeaderText="Contact Type" />
                <asp:ButtonField ButtonType="Button" Text="Edit" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
