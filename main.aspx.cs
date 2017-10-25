using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace slcm
{

    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object o, EventArgs e)
        {


            if (Request.QueryString["action"] != null)
                ((Label)Master.FindControl("message")).Text = "Student registration done. The roll number is " + Request.QueryString["rollno"];
            
        }
    }

}
