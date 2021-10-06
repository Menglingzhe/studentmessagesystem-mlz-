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
    public partial class 成绩管理 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            Dao Sqltest = new Dao();
            Sqltest.connect();
            string sql = "select * from [School].[dbo].[SC]";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Sqltest.command(sql);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Table_book");
            GridView1.DataSource = ds.Tables["Table_book"].DefaultView;
            GridView1.DataBind();
            
            

        }

        protected void Button1_Click(object sender, EventArgs e)//增加
        {
            String Sno = TextBox1.Text.Trim();
            String Cno = TextBox2.Text.Trim();
            String Grade = TextBox3.Text.Trim();
            try
            {
                Dao Sqltest = new Dao();
                string insertStr = "INSERT INTO  SC (Sno,Cno,Grade) " +
                    "VALUES ('" + Sno + "','" + Cno + "','" + Grade + "')";
                Sqltest.Execute(insertStr);
                Sqltest.DaoClose();
                Response.Write("<script>alert('添加成功！');</script>");

                GetData();
            }
            catch
            {
                Response.Write("<script>alert('输入数据违反要求！');</script>");
            }
            finally
            {
              
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String Sno = TextBox1.Text.Trim();
            String Cno = TextBox2.Text.Trim();
            String Grade = TextBox3.Text.Trim();
            try
            {
                Dao Sqltest = new Dao();
                string res = String.Format("DELETE [SC] WHERE ([Sno]  ={0})", TextBox1.Text.ToString());
                Sqltest.Execute(res);
                Sqltest.DaoClose();
                GetData();
                Response.Write("<script>alert('删除成功！');</script>");

            }
            catch
            {
                Response.Write("<script>alert('输入数据违反要求！');</script>");
            }
            finally
            {
               
            }

        }

        protected void Button3_Click(object sender, EventArgs e)//修改
        {
            String Sno = TextBox1.Text.Trim();
            String Cno = TextBox2.Text.Trim();
            String Grade = TextBox3.Text.Trim();

            try
            {
                if ((Sno == "") | (Cno == "") | (Grade == ""))
                {
                    string message = null;
                    if (message == null)
                    {
                        Response.Write("<script>alert('输入不能为空！');</script>");
                    }
                }
                Dao Sqltest = new Dao();
                string res = "UPDATE SC SET Grade = '" + Grade + "' WHERE Sno = '" + Sno + "'AND Cno ='" + Cno + "'";
                Sqltest.Execute(res);
                Sqltest.DaoClose();
                Response.Write("<script>alert('修改成功！');</script>");
                GetData();

            }
         
            catch
            {
                Response.Write("<script>alert('输入数据违反要求！');</script>");
            }
            finally
            {
                
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String Sno = TextBox1.Text.Trim();
            String Cno = TextBox2.Text.Trim();
            String Grade = TextBox3.Text.Trim();

            try
            {
                String select_by_id = "select * from SC where ";
                int flag = 0;  //0是单条件，1是多条件
               
                if (Sno != "")
                    select_by_id += "Sno='" + Sno + "'";    //单条件 按学号
                if (Cno != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Cno LIKE'" + Cno + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Cno LIKE'" + Cno + "'";

                }


                SqlConnection con = new SqlConnection("Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;");
                con.Open();
                SqlDataAdapter sdap = new SqlDataAdapter(select_by_id, con);
                DataSet ds = new DataSet();
                sdap.Fill(ds, "table");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                Response.Write("<script>alert('查询成功！');</script>");
            }
            catch
            {
                Response.Write("<script>alert('查询语句有误，请认真检查SQL语句!');</script>");
            }
            finally
            {
                
            }

        }

        protected void Button5_Click(object sender, EventArgs e)//刷新
        {
            GetData();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

      


    }
}