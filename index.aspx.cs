﻿using System;
using System.Web;
using System.Web.UI;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
namespace slcm
{

    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                username.Visible = true;
            }
        }
        protected void CheckLogin(object sender, System.EventArgs e)
        {
            MD5 md5Hash = MD5.Create();
            string uname = username.Value.ToString();
            string pass = password.Value.ToString();
            pass = GetMd5Hash(md5Hash, pass);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT count(email) FROM users WHERE email = @email AND password = @password", con);
            sql.Parameters.AddWithValue("@email",uname);
            sql.Parameters.AddWithValue("@password",pass);

            int rows = (int)sql.ExecuteScalar();

            if (rows == 1)
            {
                Session["username"] = uname;
                Response.Redirect("main.aspx");
            }
            else
                message.InnerText = "Wrong username or password";
            
            con.Close();
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
        protected void RegisterUser(object sender, System.EventArgs e)
        {
            




        }
    }
}
