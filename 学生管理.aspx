<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="学生管理.aspx.cs" Inherits="WebApplication9.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="学号"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="姓名"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="性别"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="专业"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="年龄"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="增加" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="修改" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="删除" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="刷新" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="true"   >
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
