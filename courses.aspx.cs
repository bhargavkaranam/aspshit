using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace slcm
{

    public partial class courses : System.Web.UI.Page
    {
        SqlDataAdapter da;  
        DataSet ds = new DataSet();  
        SqlCommand cmd = new SqlCommand();  
        SqlConnection con = new SqlConnection();  
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                BindData();
        }
        public void BindData()
        {
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            cmd.CommandText = "Select * from students";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            Grid.DataSource = ds;
            Grid.DataBind();
            con.Close();
        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            BindData();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            cmd.Connection = con;
            int EmpId = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            cmd.CommandText = "Delete from students where roll_no=" + EmpId;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Grid.EditItemIndex = -1;
            BindData();
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            cmd.Parameters.Add("@EmpId", System.Data.SqlDbType.Int).Value = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
            cmd.Parameters.Add("@F_Name", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
            cmd.Parameters.Add("@L_Name", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@City", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
            cmd.Parameters.Add("@EmailId", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
            cmd.Parameters.Add("@EmpJoining", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
            cmd.Parameters.Add("@Semester", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
            cmd.CommandText = "Update students set first_name=@F_Name,last_name=@L_Name,address=@City,email=@EmailId,course=@EmpJoining,current_semester=@Semester where roll_no=@EmpId";
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Grid.EditItemIndex = -1;
            BindData();
        }



    }
}
