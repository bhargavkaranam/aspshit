using System;
using System.Web;
using System.Web.UI;
using System.Data.Sql;
using System.Data.SqlClient;
namespace slcm
{

    public partial class admission : System.Web.UI.Page
    {
        protected void Page_Load(object o, EventArgs e)
        {
            string fname = Request.Form["first_name"];
            string lname = Request.Form["last_name"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string batch = Request.Form["year"];
            string course = Request.Form["branch"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            con.Open();
            SqlCommand sql = new SqlCommand("INSERT INTO students(first_name,last_name,email,address,batch,course,current_semester) VALUES(@first_name,@last_name,@email,@address,@batch,@course, 1)", con);
            sql.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 100).Value = email;
            sql.Parameters.Add("@first_name", System.Data.SqlDbType.VarChar, 100).Value = fname;
            sql.Parameters.Add("@last_name", System.Data.SqlDbType.VarChar, 100).Value = lname;
            sql.Parameters.Add("@address", System.Data.SqlDbType.VarChar, 100).Value = address;
            sql.Parameters.Add("@batch", System.Data.SqlDbType.Int).Value = batch;
            sql.Parameters.Add("@course", System.Data.SqlDbType.VarChar, 100).Value = course;
            sql.ExecuteNonQuery();
            sql = new SqlCommand("SELECT roll_no FROM students WHERE email = @email", con);
            sql.Parameters.AddWithValue("@email",email);
            int roll = (int)sql.ExecuteScalar();
            con.Close();
            Response.Redirect("main.aspx?action=admission&rollno=" + roll);
        }

    }
}
