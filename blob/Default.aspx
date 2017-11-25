<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="blob.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:button runat="server" text="Upload" ID="UBtn" OnClick="UBtn_Click" />    
        <asp:button runat="server" text="Download" ID="DBtn" OnClick="DBtn_Click" />    
    </div>
    </form>
</body>
</html>

