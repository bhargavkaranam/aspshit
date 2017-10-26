<%@ Page Language="C#" Inherits="slcm.details" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Details</title>
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
	<form id="form1" runat="server">
		<div>
			<asp:DataGrid ID="Grid" runat="server" PageSize="5" AllowPaging="True" DataKeyField="roll_no" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" OnItemCommand="Grid_DetailsCommand">
					<Columns>  
						<asp:BoundColumn HeaderText="Id" DataField="id"> </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Roll No" DataField="roll_no"> </asp:BoundColumn>
                        <asp:BoundColumn DataField="course" HeaderText="Course"> </asp:BoundColumn>
						<asp:BoundColumn DataField="grade" HeaderText="Grade"> </asp:BoundColumn>
                        <asp:BoundColumn DataField="semester" HeaderText="Semester"> </asp:BoundColumn>
                        <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit"> </asp:EditCommandColumn>  
                        <asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete"> </asp:ButtonColumn>
                        
                    </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />  
                    <AlternatingItemStyle BackColor="White" />  
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />  
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /> </asp:DataGrid> <br /> <br />
                <asp:table runat="server" id="semGPA">
    				
            
              <asp:TableRow>
                  <asp:TableCell>Semester</asp:TableCell>
                  <asp:TableCell>GPA</asp:TableCell>
                  <asp:TableCell>CGPA</asp:TableCell>
              </asp:TableRow>
            


          </asp:table>
			
			<table>  
                    <tr>  
                        <td>  
                            <asp:Label ID="lblEmpId" runat="server" Text="Roll No"></asp:Label>  
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
                        </td>  
                        <td>  
                            <asp:Label ID="lblfname" runat="server" Text="Course"></asp:Label>  
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
                        </td>  
                        <td>  
                            <asp:Label ID="lblLname" runat="server" Text="Grade"></asp:Label>  
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  
                        </td>
						<td>  
                            <asp:Label ID="lblSemester" runat="server" Text="Semester"></asp:Label>  
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  
                        </td>

                    </tr>  
                </table>  
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />  
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />  
                <asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click" /> </div>	
		</div>
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
