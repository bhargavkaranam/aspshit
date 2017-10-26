<%@ Page Language="C#" Inherits="slcm.inventory" CodeFile="inventory.aspx.cs"%>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Inventory</title>
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
		<asp:DataGrid runat="server" id="Grid" PageSize="5" AllowPaging="True" DataKeyField="id" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" OnItemCommand="Grid_DetailsCommand">
				<Columns>  
                        <asp:BoundColumn HeaderText="Id" DataField="id"> </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Department" DataField="branch"> </asp:BoundColumn>
                        <asp:BoundColumn DataField="Name" HeaderText="name"> </asp:BoundColumn>
                        <asp:BoundColumn DataField="Location" HeaderText="location"> </asp:BoundColumn>
                        <asp:BoundColumn DataField="Quantity" HeaderText="quantity"> </asp:BoundColumn>
                        <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit"> </asp:EditCommandColumn>  
                        <asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete"> </asp:ButtonColumn>
                        
                    </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />  
                    <AlternatingItemStyle BackColor="White" />  
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />  
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /> </asp:DataGrid> <br /> <br />
                
		       <table>  
                    <tr>  
					
                        <td>  
                            <asp:Label ID="lblEmpId" runat="server" Text="Branch"></asp:Label>  
                            <asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
                            
                        </td>  
                        <td>  
                            <asp:Label ID="lblfname" runat="server" Text="Name"></asp:Label>  
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
                        </td>  
                        <td>  
                            <asp:Label ID="lblLname" runat="server" Text="Location"></asp:Label>  
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  
                        </td>
					    <td>  
                            <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>  
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  
                        </td>


                    </tr>  
                </table>  
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />  
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />  
                <asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click" /> </div> 
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
