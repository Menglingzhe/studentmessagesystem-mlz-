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
    public partial class WebForm2 : System.Web.UI.Page
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
            GridView2.DataSource = ds.Tables["Table_book"].DefaultView;
            GridView2.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)//查询
        {
            Dao Sqltest = new Dao();
            string res;
            if (TextBox5.Text.ToString() == "")
            {
                res = String.Format("SELECT[Sno],[Sname],[Ssex],[Sage],[Sdept] FROM [Table_book] WHERE (([Sno] LIKE '%{0}%') AND ([Sname] LIKE '%{1}%') AND ([Ssex] LIKE '%{2}%') AND ([Sdept] LIKE '%{3}%'))"
                , TextBox1.Text.ToString()
                , TextBox2.Text.ToString()
                , TextBox3.Text.ToString()
                , TextBox4.Text.ToString());
            }
            else
            {
                res = String.Format("SELECT [id], [Name], [Age], [Interest], [Advantage] FROM [Table_book] WHERE (([Name] LIKE '%{0}%') AND ([id] LIKE '%{1}%') AND ([Interest] LIKE '%{2}%') AND ([Advantage] LIKE '%{3}%') AND ([Age] = {4}))"
               , TextBox1.Text.ToString()
               , TextBox2.Text.ToString()
               , TextBox3.Text.ToString(),
               TextBox4.Text.ToString(),
               Convert.ToInt32(TextBox5.Text.ToString()));
            }
            databind(res);
        }

        private void databind(string sql1)
        {
            SqlConnection con = new SqlConnection("Data Source=MLZ-DELL007;Initial Catalog=School;Integrated Security=True;");
            con.Open();
            SqlDataAdapter sdap = new SqlDataAdapter(sql1, con);
            DataSet ds = new DataSet();
            sdap.Fill(ds, "table");
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)//增加
        {
            Dao Sqltest = new Dao();
            string res = String.Format("Insert into[dbo].[Table_book]([Name],[id],[Interest],[Advantage],[Age]) values('{0}','{1}','{2}','{3}',{4});"
              , TextBox1.Text.ToString()
              , TextBox2.Text.ToString()
              , TextBox3.Text.ToString(),
              TextBox4.Text.ToString(),
              Convert.ToInt32(TextBox5.Text.ToString()));
            Sqltest.Execute(res);
            Sqltest.DaoClose();
            GetData();
        }

        protected void Button3_Click(object sender, EventArgs e)//删除
        {
            Dao Sqltest = new Dao();
            string res = String.Format("DELETE Table_book WHERE ([id] ={0})"
            , TextBox2.Text.ToString());
            Sqltest.Execute(res);
            Sqltest.DaoClose();
            GetData();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Dao Sqltest = new Dao();
            string res = "update Table_book set Name='" + TextBox1.Text.ToString() + "',Age='" + Convert.ToInt32(TextBox5.Text.ToString()) + "',Interest='" + TextBox3.Text.ToString() + "',Advantage='" + TextBox4.Text.ToString() + "' where id =" + TextBox2.Text.ToString() + "";
            Sqltest.Execute(res);
            Sqltest.DaoClose();
            GetData();
        }
    }
}