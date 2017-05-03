<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddQuestion.aspx.cs" Inherits="AddQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="imgFileUpload" runat="server" />
        <asp:Button ID="okButton" runat="server" OnClick="okbtn_Click"  Text="Button" Font-Size="9pt"/>
        
    </div>
    </form>
    <embed src='TheFox.mp3' autostart='true'></embed>
</body>
</html>
