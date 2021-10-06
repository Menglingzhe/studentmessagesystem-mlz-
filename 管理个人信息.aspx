<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理个人信息.aspx.cs" Inherits="WebApplication9.查询个人信息" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="新密码"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="电话号码"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="出生日期"></asp:Label>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" />
                </asp:Panel>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Button ID="Button2" runat="server" Text="修改个人信息" OnClick="Button2_Click" />

        </div>
    </form>
</body>
</html>
