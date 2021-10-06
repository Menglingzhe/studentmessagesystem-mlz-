using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//数据库读取例子
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;";
            //打开连接
            conn.Open();
            String res = "select [Uname] from [Usertable] WHERE [Uid]='" + TextBox1.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(res, conn);
            SqlDataReader drNew = cmd.ExecuteReader();
            if (drNew.HasRows)
            {
                while (drNew.Read())
                {
                   Label1.Text = drNew["Uname"].ToString();
                }
            }
            drNew.Close();
        }
    }
}