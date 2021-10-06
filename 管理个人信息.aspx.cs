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
    public partial class 查询个人信息 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Getdata1();
            Panel1.Visible = false;
        }

        public void Getdata1() {
            string nameid;
            nameid = Session["name"].ToString();
            try
            {
                Dao Sqltest = new Dao();
                String res = "select * from [Usertable] where [Uid]='" + nameid + "'";
                SqlConnection con = new SqlConnection("Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;");
                con.Open();
                SqlDataAdapter sdap = new SqlDataAdapter(res, con);
                DataSet ds = new DataSet();
                sdap.Fill(ds, "table");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

            }
            catch
            {
                Response.Write("<script>alert('查询语句有误，请认真检查SQL语句!');</script>");

            }
            finally
            {

            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string nameid;
            nameid = Session["name"].ToString();

            string Rname = TextBox1.Text.Trim();
            string Rpassword = TextBox2.Text.Trim();
            string Rid = nameid;
            string Rnumber = TextBox4.Text.Trim();
            DateTime Rdate = Calendar1.SelectedDate;

            if (Rname.Equals("") | Rpassword.Equals("") | Rid.Equals("") | Rnumber.Equals(""))
            {
                Response.Write("<script>alert('输入不完整！');</script>");
            }

            SqlConnection conn = new SqlConnection();//uid=;pwd=; 创建一个连接数据库的对象
            string myConnString = "Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;"; //用这行登录访问所要的数据库

            SqlConnection sqlConnection = new SqlConnection(myConnString);  //实例化连接对象
            sqlConnection.Open();
            
            try
            {
                string res = "update [Usertable] set [Uname]='" + TextBox1.Text.ToString() + "',[Upassword]='" + TextBox2.Text.ToString() + "',[Unumber]='" + TextBox4.Text.ToString() + "',[Ubirthday]='" + Rdate + "'  where [Uid] =" + Rid + "";

                SqlCommand sqlCommand = new SqlCommand(res, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                sqlConnection.Close();


                Response.Write("<script language='javascript'>alert('修改成功!');</script>");
                Getdata1();
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
    }
}