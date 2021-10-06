<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="用户页面.aspx.cs" Inherits="WebApplication9.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="441px" style="margin-left: 352px; margin-top: 86px" Width="584px">
                <asp:GridView ID="GridView2" runat="server" style="margin-left: 90px; margin-top: 55px">
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 79px"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="id"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 80px"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="兴趣"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 75px"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="优势"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 78px"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="年龄"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 76px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 70px" Text="查询" />
                <asp:Button ID="Button2" runat="server" Text="添加" OnClick="Button2_Click"  />
                <asp:Button ID="Button3" runat="server" Text="删除" OnClick="Button3_Click" />
                <asp:Button ID="Button4" runat="server" Text="修改" OnClick="Button4_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>