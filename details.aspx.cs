using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace slcm
{

    public partial class details : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
                BindData();
        }
        public void BindData()
        {
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            cmd.CommandText = "Select * from student_course WHERE roll_no = @rn";
            cmd.Parameters.AddWithValue("@rn",Request.QueryString["rollno"]);
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            Grid.DataSource = ds;
            Grid.DataBind();
            con.Close();
            for(int i = 1; i <= 7; i++)
            {
                TableRow row = new TableRow();
                TableCell semNo = new TableCell();
                TableCell indGPA = new TableCell();
                TableCell cgpa = new TableCell();
                semNo.Text = i.ToString();

                con.Open();
                float gpa = 0;
                int total = 0;
                cmd.CommandText = "SELECT grade,courses.credits FROM student_course inner join courses ON student_course.course = courses.course WHERE semester = " + Convert.ToInt32(i) + " AND roll_no = " + Convert.ToInt32(Request.QueryString["rollno"]);
                cmd.Connection = con;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    total = total + sdr.GetInt32(1);
                    switch(sdr.GetString(0))
                    {
                        case "A":
                            gpa = gpa + (sdr.GetInt32(1) * 9);
                            break;
                        case "B":
                            gpa = gpa + (sdr.GetInt32(1) * 8);
                            break;
                        case "C":
                            gpa = gpa + (sdr.GetInt32(1) * 7);
                            break;

                    }

                }

                indGPA.Text = (gpa / total).ToString();
                cgpa.Text = "lol";
                row.Cells.Add(semNo);
                row.Cells.Add(indGPA);
                row.Cells.Add(cgpa);
                semGPA.Rows.Add(row);
                con.Close();
            }

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
            Response.Write(e.CommandName);
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
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
            cmd.Parameters.Add("@EmpId", System.Data.SqlDbType.Int).Value = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
            cmd.Parameters.Add("@course", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@grade", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
            cmd.Parameters.Add("@semester", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
            cmd.CommandText = "Update student_course set course = @course, grade = @grade, semester = @semester where roll_no=@EmpId and id = @id";
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Grid.EditItemIndex = -1;
            BindData();
        }

        protected void Grid_DetailsCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Details")
                ShowDetails(e);

        }

        protected void ShowDetails(DataGridCommandEventArgs e)
        {
            TableCell itemCell = e.Item.Cells[0];
            string item = itemCell.Text;
            Response.Redirect("details.aspx?rollno=" + item);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            con.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("Insert into student_course (roll_no, course, grade, semester) values(@rn, @course, @grade,@semester)", con);
            cmd.Parameters.Add("@rn", System.Data.SqlDbType.Int).Value = TextBox1.Text;
            cmd.Parameters.Add("@course", System.Data.SqlDbType.VarChar, 100).Value = TextBox2.Text;
            cmd.Parameters.Add("@grade", System.Data.SqlDbType.VarChar, 100).Value = TextBox3.Text;
            cmd.Parameters.Add("@semester", System.Data.SqlDbType.VarChar, 100).Value = TextBox4.Text;

            cmd.ExecuteNonQuery();
            con.Close();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            //BindData1();
        }
    }
}
