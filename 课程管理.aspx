<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="课程管理.aspx.cs" Inherits="WebApplication9.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="课程号"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 68px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="课程名"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 65px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="先修课课程号"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="学分"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 84px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server"  Text="增加" OnClick="Button1_Click1"  />
            <asp:Button ID="Button2" runat="server" Text="删除" OnClick="Button2_Click"  />
            <asp:Button ID="Button3" runat="server" Text="修改" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="查询" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" Text="刷新" OnClick="Button5_Click"  />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
