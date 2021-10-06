using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class 用户注册 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Rname = TextBox1.Text.Trim();
            string Rpassword = TextBox2.Text.Trim();
            string Rid = TextBox3.Text.Trim();
            string Rnumber = TextBox4.Text.Trim();
            
            
            DateTime Rdate = Calendar1.SelectedDate;

            if ( Rname.Equals("") | Rpassword.Equals("") | Rid.Equals("") | Rnumber.Equals("") )
            {
                Response.Write("<script>alert('输入不完整！');</script>");
            }

            SqlConnection conn = new SqlConnection();//uid=;pwd=; 创建一个连接数据库的对象
            string myConnString = "Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;"; //用这行登录访问所要的数据库

            SqlConnection sqlConnection = new SqlConnection(myConnString);  //实例化连接对象
            sqlConnection.Open();
            try
            {
                string sql = String.Format("Insert into[dbo].[Usertable]([Uidentity],[Uname],[Upassword] ,[Uid],[Unumber] ,[Ubirthday])values('用户','{0}','{1}','{2}','{3}','{4}');"
               , TextBox1.Text.ToString()
              , TextBox2.Text.ToString()
              , TextBox3.Text.ToString(),
              TextBox4.Text.ToString()
              , Rdate);
                
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
              
                sqlConnection.Close();


                Response.Write("<script language='javascript'>alert('注册成功!');location.href='学生登录.aspx';</script>");
            }
            catch
            {
                Response.Write("<script>alert('输入异常！');</script>");
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}