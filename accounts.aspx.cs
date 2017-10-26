using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace slcm
{

    public partial class accounts : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("/index.aspx");
            if (!Page.IsPostBack)
                BindData();
        }
        public void BindData()
        {
            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            cmd.CommandText = "Select * from accounts";
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
            cmd.CommandText = "Delete from accounts where id=" + EmpId;
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
            cmd.Parameters.Add("@L_Name", System.Data.SqlDbType.BigInt).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@City", System.Data.SqlDbType.VarChar).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;

            cmd.CommandText = "Update accounts set branch=@F_Name,amount=@L_Name,type=@City where id=@EmpId";
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
            TableRow row = new TableRow();
            TableCell Branch = new TableCell();
            TableCell Income = new TableCell();
            TableCell Expense = new TableCell();
            TableCell Balance = new TableCell();
            double income = 0;
            double expense = 0;
            double balance = 0;
            TableCell itemCell = e.Item.Cells[1];
            string branch = itemCell.Text;
            Branch.Text = branch;

            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            cmd.CommandText = "Select amount,type from accounts WHERE branch = @branch";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@branch",branch);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                
                if (sdr.GetString(1) == "Debit")
                    income += sdr.GetDouble(0);
                else
                    expense += sdr.GetDouble(0);
            }
            balance = income - expense;

            Income.Text = income.ToString();
            Expense.Text = expense.ToString();
            Balance.Text = balance.ToString();

            row.Cells.Add(Branch);
            row.Cells.Add(Income);
            row.Cells.Add(Expense);
            row.Cells.Add(Balance);
            accountBalance.Rows.Add(row);
            cmd.Connection = con;

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            con.ConnectionString = @"Server=localhost;Database=slcm;User Id=sa;Password=P@55w0rd;";
            con.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("Insert into accounts (branch, amount, type) values(@branch, @name, @head)", con);
            cmd.Parameters.Add("@branch", System.Data.SqlDbType.VarChar, 100).Value = TextBox1.Text;
            cmd.Parameters.Add("@name", System.Data.SqlDbType.BigInt).Value = TextBox2.Text;
            cmd.Parameters.Add("@head", System.Data.SqlDbType.VarChar, 100).Value = TextBox3.Text;


            cmd.ExecuteNonQuery();
            con.Close();
            BindData();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";


        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            //BindData1();
        }

    }
}
