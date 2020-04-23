<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="excelFile_upload.aspx.cs" Inherits="uCarenet_test.excelFile_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>uCarenet Test Excel File Upload Web Page</title>
    <meta name="description" content="Excel File Upload" />
</head>
<body>
    <h1>Excel File Upload</h1>
    <form id="excelFile_upload_form" runat="server">
        <div>
            <asp:FileUpload ID="excelFileUpload" runat="server" />
            <asp:Button id="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Upload" />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:GridView ID="excelFileGridView" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
