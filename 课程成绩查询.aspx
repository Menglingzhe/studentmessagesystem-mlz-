<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="课程成绩查询.aspx.cs" Inherits="WebApplication9.学生成绩查询" %>

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
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="学号"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="课程成绩查询" />
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
