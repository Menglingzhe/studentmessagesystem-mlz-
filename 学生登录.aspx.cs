using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//登录
        {
            string DriUserName1 = TextBox1.Text.Trim();
            string DriPassWord1 = TextBox2.Text.Trim();
            String logsql = "";
            string Dirclass1 = DropDownList1.SelectedValue;
            SqlConnection conn = new SqlConnection();//uid=;pwd=; 创建一个连接数据库的对象
            conn.ConnectionString = @"Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;"; //用这行登录访问所要的数据库
            if (Dirclass1 == "super")
            {
                
                string sqlString = "select  *  from [Managetable] where [Mid]='" + DriUserName1 + "' and [Mpassword]='" + DriPassWord1 + "'"; //在数据库里面执行的语句
                string sqlCheck = "select count([Mid]) from [Managetable] where [Mid]='" + DriUserName1 + "'";
                conn.Open();
                SqlCommand check = new SqlCommand(sqlCheck, conn);
                if (Convert.ToInt16(check.ExecuteScalar()) == 0)
                {
                    Response.Write("<script>alert('管理员不存在！');</script>");

                }
                else
                {
                    Session["name"] = DriUserName1;
                    Session["id"] = DriUserName1;
                    SqlDataAdapter sda = new SqlDataAdapter(sqlString, conn);//创建DataAdapter数据适配器实例
                    DataSet ds = new DataSet();//创建DataSet实例，里面可以放很多的table
                    sda.Fill(ds);//使用DataAdapter的Fill方法(填充)，调用SELECT命令
                    if (ds.Tables[0].Rows.Count == 1)//ds里面的第一个表存在这一行数据 匹配成功
                    {
                        Response.Write("<script language='javascript'>alert('欢迎管理员!');location.href='WebForm4.aspx';</script>");
                        
                    }
                    else
                    {

                        Response.Write("<script language='javascript'>alert('密码错误!');location.href='学生登录.aspx';</script>");
                    }
                }
            }
            else if(Dirclass1 == "user")
            {
                
                string sqlString = "select  *  from [Usertable] where [Uid]='" + DriUserName1 + "' and [Upassword]='" + DriPassWord1 + "'"; //在数据库里面执行的语句
                string sqlCheck = "select count([Uid]) from [Usertable] where [Uid]='" + DriUserName1 + "'";
                conn.Open();
                SqlCommand check = new SqlCommand(sqlCheck, conn);
                if (Convert.ToInt16(check.ExecuteScalar()) == 0)
                {
                    Response.Write("<script>alert('用户名不存在！');</script>");

                }
                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sqlString, conn);//创建DataAdapter数据适配器实例
                    DataSet ds = new DataSet();//创建DataSet实例，里面可以放很多的table
                    sda.Fill(ds);//使用DataAdapter的Fill方法(填充)，调用SELECT命令
                    if (ds.Tables[0].Rows.Count == 1)//ds里面的第一个表存在这一行数据 匹配成功
                    {
                        Session["name"] = DriUserName1;
                        Session["id"] = DriUserName1;
                        Response.Write("<script language='javascript'>alert('登录成功!');location.href='WebForm3.aspx';</script>");
                    }
                    else
                    {

                        Response.Write("<script language='javascript'>alert('密码错误!');location.href='学生登陆.aspx';</script>");
                    }
                }
            }

            if (Dirclass1 == "super")
            {
                 logsql = "insert into SchLog values ( '" + DriUserName1 + "' , '" + DateTime.Now + "' , '" + "Login" + "')";
            }
            else if (Dirclass1 == "user")
            {
                 logsql = "insert into SchLog values ( '" + DriUserName1 + "' , '" + DateTime.Now + "' , '" + "Login" + "')";
            }
            try
            {
                Dao Sqltest = new Dao();
                
                Sqltest.Execute(logsql);
                Sqltest.DaoClose();
            }
            catch
            {
                Response.Write("<script>alert('登录日志出错！');</script>");
            }
            finally
            {

            }





        }

        protected void Button2_Click(object sender, EventArgs e)//跳转到注册
        {
            Response.Redirect("用户注册.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Write("<script>location.href='用户注册.aspx';</script>");
        }
    }
}