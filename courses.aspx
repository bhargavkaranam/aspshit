<%@ Page Language="C#" Inherits="slcm.courses" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Courses</title>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css">
    <style>
		table
        {
			
			width: 100%;
		}
	</style>
</head>
<body>
	
	<form method="get" id="form2" action="details.aspx">
		<input name="rollno" type="number" placeholder="Roll no" />
        <button type="submit">Get Details</button>
	</form>
	<form id="form1" runat="server">
		<div>  
                <asp:DataGrid ID="Grid" runat="server" PageSize="5" AllowPaging="True" DataKeyField="roll_no" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" OnItemCommand="Grid_DetailsCommand">  
                    <Columns>  
                        <asp:BoundColumn HeaderText="Roll No" DataField="roll_no"> </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="F_Name" DataField="first_name"> </asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="L_Name" DataField="last_name"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="address" HeaderText="Address"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="email" HeaderText="EmailId"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="course" HeaderText="Course"> </asp:BoundColumn>
						<asp:BoundColumn DataField="current_semester" HeaderText="Semester"> </asp:BoundColumn>
						<asp:ButtonColumn CommandName="Details" HeaderText="Details" Text="Details"> </asp:ButtonColumn>
                        <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit"> </asp:EditCommandColumn>  
                        <asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete"> </asp:ButtonColumn>
						
                    </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />  
                    <AlternatingItemStyle BackColor="White" />  
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />  
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /> </asp:DataGrid> <br /> <br />  
                
            
	</form>
    
</body>
<script
      src="https://code.jquery.com/jquery-3.2.1.min.js"
      integrity="sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4="
      crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>    
    <script>
        $(".modal").modal();
        $('select').material_select();
        
    </script>
</html>
