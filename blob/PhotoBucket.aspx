

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoBucket.aspx.cs" Inherits="blob.PhotoBucket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:fileupload runat="server" ID="ImgSelector"></asp:fileupload>    
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </center>
        <hr />
        <br />
        <asp:ListView ID="ImgList" runat="server">
            <ItemTemplate>
                <asp:Image ImageUrl="<%#((Microsoft.WindowsAzure.Storage.Blob.IListBlobItem)Container.DataItem).Uri %>" AlternateText="Image" runat="server" />
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
