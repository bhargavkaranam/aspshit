<%@ Page Language="C#" Inherits="slcm.accounts" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Research</title>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css">
    <style>
        table
        {
            width: 100%;
        }
		#accountBalance
        {
			background: #EEEEEE;
		}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DataGrid runat="server" id="Grid" PageSize="5" AllowPaging="True" DataKeyField="id" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" OnItemCommand="Grid_DetailsCommand">
                <Columns>  
                        <asp:BoundColumn HeaderText="Id" DataField="id"> </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Department" DataField="branch"> </asp:BoundColumn>
                        <asp:BoundColumn DataField="amount" HeaderText="Name"> </asp:BoundColumn>
                        <asp:BoundColumn DataField="type" HeaderText="Head"> </asp:BoundColumn>
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
                <asp:table runat="server" id="accountBalance">
                    
            
              <asp:TableRow>
				  <asp:TableCell>Branch</asp:TableCell>
                  <asp:TableCell>Income</asp:TableCell>
                  <asp:TableCell>Expenditure</asp:TableCell>
                  <asp:TableCell>Balance</asp:TableCell>
              </asp:TableRow>
            


          </asp:table>

               <table>  
                    <tr>  
                    
                        <td>  
                            <asp:Label ID="lblEmpId" runat="server" Text="Branch"></asp:Label>  
                            <asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
                            
                        </td>  
                        <td>  
                            <asp:Label ID="lblfname" runat="server" Text="Amount"></asp:Label>  
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  
                        </td>  
                        <td>  
                            <asp:Label ID="lblLname" runat="server" Text="Type"></asp:Label>  
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  
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
