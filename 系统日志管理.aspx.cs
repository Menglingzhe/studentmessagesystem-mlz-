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
    public partial class 系统日志管理 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dao Sqltest = new Dao();
            Sqltest.connect();
            string sql = "select * from [School].[dbo].[SchLog]";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Sqltest.command(sql);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Table_book");
            GridView1.DataSource = ds.Tables["Table_book"].DefaultView;
            GridView1.DataBind();
        }
    }
}