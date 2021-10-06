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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            Dao Sqltest = new Dao();
            Sqltest.connect();
            string sql = "select * from [School].[dbo].[Student]";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Sqltest.command(sql);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Table_book");
            GridView1.DataSource = ds.Tables["Table_book"].DefaultView;
            GridView1.DataBind();
           
        }

        protected void Button1_Click(object sender, EventArgs e)//查找
        {
            Dao Sqltest = new Dao();
            String StuID = TextBox1.Text.Trim();
            String StuName = TextBox2.Text.Trim();
            String StuSex = TextBox3.Text.Trim();
            String StuSdept = TextBox4.Text.Trim();
            String StuAge = TextBox5.Text.Trim();
            try
            {
                String select_by_id = "select * from Student where ";
                int flag = 0;  //0是单条件，1是多条件
                
                if (StuID != "")
                    select_by_id += "Sno='" + StuID + "'";    //单条件 按学号
                if (StuName != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Sname LIKE'" + StuName + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Sname LIKE'" + StuName + "'";

                }
                if (StuAge != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Sage='" + StuAge + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Sage='" + StuAge + "'";
                }
                if (StuSdept != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Sdept='" + StuSdept + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Sdept='" + StuSdept + "'";
                }
                if (StuSex != "")
                {
                    if (flag == 0)
                    {
                        select_by_id += "Ssex='" + StuSex + "'";
                        flag = 1;
                    }
                    if (flag == 1)
                        select_by_id += "And Ssex='" + StuSex + "'";
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

        protected void Button2_Click(object sender, EventArgs e)//插入
        {
            String StuID = TextBox1.Text.Trim();
            String StuName = TextBox2.Text.Trim();
            String StuSex = TextBox3.Text.Trim();
            String StuSdept = TextBox4.Text.Trim();
            String StuAge = TextBox5.Text.Trim();

            try
            {
                Dao Sqltest = new Dao();
                string res = "INSERT INTO  Student (Sno,Sname,Ssex,Sdept,Sage)    " +
                    "VALUES ('" + StuID + "','" + StuName + "','" + StuSex + "','" + StuSdept + "'," + StuAge + ")";
                Sqltest.Execute(res);
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

        protected void Button5_Click(object sender, EventArgs e)//刷新
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            GetData();

        }

        protected void Button3_Click(object sender, EventArgs e)//修改
        {
            String StuID = TextBox1.Text.Trim();
            String StuName = TextBox2.Text.Trim();
            String StuSex = TextBox3.Text.Trim();
            String StuSdept = TextBox4.Text.Trim();
            String StuAge = TextBox5.Text.Trim();

            try
            {
                if ((StuID == "") | (StuName == "") | (StuSex == "") | (StuSdept == "") | (StuAge == ""))
                {
                    string message = null;
                    if (message == null)
                    {
                        Response.Write("<script>alert('输入不能为空！');</script>");
                       
                    }
                }
                else { 

                Dao Sqltest = new Dao();
                string res = "UPDATE Student SET Sname = '" + StuName + "', Ssex = '" + StuSex + "', Sdept = '" + StuSdept + "', Sage = '" + StuAge + "' WHERE Sno = '" + StuID + "'";

                Sqltest.Execute(res);
                Sqltest.DaoClose();
                Response.Write("<script>alert('修改成功！');</script>");
                GetData();
                }
            }
            catch
            {
                Response.Write("<script>alert('输入数据违反要求！');</script>");
            }
            finally
            {

            }
        }

        protected void Button4_Click(object sender, EventArgs e)//删除
        {
            try
            {
                Dao Sqltest = new Dao();
                string res = String.Format("DELETE [Student] WHERE ([Sno]  ={0})", TextBox1.Text.ToString());
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


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Dao Sqltest = new Dao();
            Sqltest.connect();
            string sql = "select * from [School].[dbo].[Student]";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Sqltest.command(sql);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Table_book");
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ds.Tables["Table_book"].DefaultView;               //引用刚才建立的数据源
            GridView1.DataBind();
        }



    }



}