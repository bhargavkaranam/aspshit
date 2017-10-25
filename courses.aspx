<%@ Page Language="C#" Inherits="slcm.courses" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>courses</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>  
                <asp:DataGrid ID="Grid" runat="server" PageSize="5" AllowPaging="True" DataKeyField="roll_no" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">  
                    <Columns>  
                        <asp:BoundColumn HeaderText="Roll No" DataField="roll_no"> </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="F_Name" DataField="first_name"> </asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="L_Name" DataField="last_name"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="address" HeaderText="Address"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="email" HeaderText="EmailId"> </asp:BoundColumn>  
                        <asp:BoundColumn DataField="course" HeaderText="Course"> </asp:BoundColumn>
						<asp:BoundColumn DataField="current_semester" HeaderText="Semester"> </asp:BoundColumn>
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
</html>
