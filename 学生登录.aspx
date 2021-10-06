<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="学生登录.aspx.cs" Inherits="WebApplication9.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 331px;margin:auto;margin-top:10%;box-shadow: 10px 5px 5px red;border-radius: 25px; background-color:aqua;width:300px;border-style:solid;">
            <asp:Label ID="Label1" runat="server" Text="用户名" style="margin-left: 22px" Width="60px"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="24px" style="margin-left: 13px; margin-top: 77px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="密码" style="margin-left: 17px" Width="60px"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Height="26px" style="margin-left: 19px; margin-top: 6px"></asp:TextBox>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 64px">
                <asp:ListItem Value="user">用户</asp:ListItem>
                <asp:ListItem Value="super">管理员</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" style="margin-left: 39px; margin-top: 33px" />
            <asp:Button ID="Button2" runat="server" Text="学生注册" style="margin-left: 33px" OnClick="Button2_Click1" />
        </div>
    </form>
</body>
</html>
