using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace slcm
{

    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object o, EventArgs e)
        {
            test.InnerText = (string)Session["username"];

        }
        protected void Click(object a, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT * FROM users",con);
            SqlDataReader reader = sql.ExecuteReader();
            string s = "";
            while(reader.Read())
            {
                s = s + reader["email"].ToString();
            }
            con.Close();
            test.InnerText = s;

        }
    }

}
