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
    public partial class 学生成绩查询 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                string Cno = TextBox1.Text.Trim();
                string Sno = TextBox2.Text.Trim();
                Dao Sqltest = new Dao();

                if (Sno.Equals("") | Cno.Equals(""))
                {
                    Response.Write("<script>alert('请输入所有数据!');</script>");
                }
                else {
                string res = String.Format("SELECT* FROM [SC] WHERE (([Sno] ='{0}') AND([Cno] ='{1}'));"
                , Sno
                , Cno);
                
                SqlConnection con = new SqlConnection("Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;");
                con.Open();
                SqlDataAdapter sdap = new SqlDataAdapter(res, con);
                DataSet ds = new DataSet();
                sdap.Fill(ds, "table");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                }


                

            }
            catch
            {
                Response.Write("<script>alert('查询语句有误，请认真检查SQL语句!');</script>");

            }
            finally
            {

            }
        }

        
    }
}