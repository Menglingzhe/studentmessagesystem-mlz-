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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }


        public void GetData()
        {
            Dao Sqltest = new Dao();
            Sqltest.connect();
            string sql = "select * from [School].[dbo].[Course]";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Sqltest.command(sql);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Table_book");
            GridView1.DataSource = ds.Tables["Table_book"].DefaultView;
            GridView1.DataBind();
            

        }


        protected void Button1_Click1(object sender, EventArgs e)//插入
        {
            String Cno = TextBox1.Text.Trim();
            String Cname = TextBox2.Text.Trim();
            String Cpno = TextBox3.Text.Trim();
            String Ccredit = TextBox4.Text.Trim();
            string insertStr;
            try
            {
                Dao Sqltest = new Dao();
                if (Cpno.Equals(""))
                {
                    insertStr = "INSERT INTO  Course (Cno,Cname,Ccredit) " +
                    "VALUES ('" + Cno + "','" + Cname + "','" + Ccredit + "')";
                }
                else
                {
                    insertStr = "INSERT INTO  Course (Cno,Cname,Cpno,Ccredit) " +
                   "VALUES ('" + Cno + "','" + Cname + "','" + Cpno + "','" + Ccredit + "')";
                }
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

        protected void Button2_Click(object sender, EventArgs e)//删除
        {
            try
            {
                Dao Sqltest = new Dao();
                string res = String.Format("DELETE [Course] WHERE ([Cno]  ={0})", TextBox1.Text.ToString());
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
            String Cno = TextBox1.Text.Trim();
            String Cname = TextBox2.Text.Trim();
            String Cpno = TextBox3.Text.Trim();
            String Ccredit = TextBox4.Text.Trim();

            try
            {
                if ((Cno == "") | (Cname == "") | (Cpno == "") | (Ccredit == ""))
                {
                    string message = null;
                    if (message == null)
                    {
                        Response.Write("<script>alert('输入不能为空！');</script>");
                    }
                }
                Dao Sqltest = new Dao();
                string res = "UPDATE Course SET Cname = '" + Cname + "',Ccredit='" + Ccredit + "'WHERE Cno = '" + Cno + "'";// +"'AND Cpno='" +Cpno+ "'";
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

        protected void Button4_Click(object sender, EventArgs e)//查找
        {
            String Cno = TextBox1.Text.Trim();
            String Cname = TextBox2.Text.Trim();
            String Cpno = TextBox3.Text.Trim();
            String Ccredit = TextBox4.Text.Trim();

            try
            {
                String select_by_id = "select * from Course where ";
                int flag = 0;  //0是单条件，1是多条件
               
                if (Cno != "")
                    select_by_id += "Cno='" + Cno + "'";    //单条件 按学号
                if (Cname != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Cname LIKE'" + Cname + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Cname LIKE'" + Cname + "'";
                }
                if (Cpno != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Cpno='" + Cpno + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Cpno='" + Cpno + "'";
                }
                if (Ccredit != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Ccredit='" + Ccredit + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Ccredit='" + Ccredit + "'";
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

        protected void Button5_Click(object sender, EventArgs e)
        {
           
            GetData();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
    }
}