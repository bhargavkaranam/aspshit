using System;
using System.Web;
using System.Web.UI;

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
            string uname = username.Value.ToString();
            string pass = password.Value.ToString();
            if (uname.Equals("bhargav") && pass.Equals("test"))
            {
                Session["username"] = "bhargav";
                Response.Redirect("main.aspx");
            }
            else
                message.InnerText = "Wrong username or password";

        }
        protected void RegisterUser(object sender, System.EventArgs e)
        {
            
        }
    }
}
