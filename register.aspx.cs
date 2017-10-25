using System;
using System.Web;
using System.Web.UI;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace slcm
{

    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            MD5 md5Hash = MD5.Create();
            string uname = Request.Form["usernameRegister"];
            string pass = Request.Form["passwordRegister"];

            pass = GetMd5Hash(md5Hash, pass);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            con.Open();
            SqlCommand sql = new SqlCommand("INSERT INTO users(email,password) VALUES(@email,@password)", con);
            sql.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 100).Value = uname;
            sql.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 100).Value = pass;
            sql.ExecuteNonQuery();
            con.Close();
            Response.Redirect("index.aspx");
        }
        protected string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
