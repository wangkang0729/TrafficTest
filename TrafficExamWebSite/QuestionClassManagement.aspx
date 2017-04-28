<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionClassManagement.aspx.cs" Inherits="QuestionClassManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DataList ID="classes" runat="server"  Font-Size="9pt">
        <ItemTemplate>
        <table cellpadding="0" cellspacing="0" style="">
        <tr>
        <td style="width:35px"><asp:Label ID="Label10" runat="server" Font-Size="9pt"  Text='<%# DataBinder.Eval(Container.DataItem,"classID") %>'></asp:Label></td>
        <td style="width:70px"><asp:Label ID="labID" runat="server" Font-Size="9pt"  Text='<%# DataBinder.Eval(Container.DataItem,"className") %>'></asp:Label></td>
        <td style="width:70px"><asp:Label ID="Label1" runat="server" Font-Size="9pt"  Text='<%# DataBinder.Eval(Container.DataItem,"isReferences") %>'></asp:Label></td>
        <td style="width:30px"><asp:LinkButton OnClick="linkbtnDelete_Click" runat="server" CommandArgument='<%# Eval("classID")%>' Font-Size="9pt" >删除</asp:LinkButton></td>
        </tr> 
        </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:TextBox ID="classNameTextBox" runat="server"></asp:TextBox><asp:Button ID="addClassButton" OnClick="btnAdd_Click" runat="server" Text="Button" />
    <asp:Label ID="exLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
