<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Grocerystore.checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function mesg()
        {
            alert("Thank you for your Payment");
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <hgroup class="title">
                <h1><%: Title %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Store Order Checkout Screen</h1>
            </hgroup>
         <table border="1" style="width: 700px">
             <tr>
                 <th>
                     Item Type
                 </th>
                 <th>
                     Items Selected
                 </th>
                 <th>
                     Total Price
                 </th>
             </tr>
             <tr>
                 <td> <h3>Vegetables</h3></td>
                 <td>
                     <asp:ListBox ID="VegcheckoutListBox" runat="server" Rows="10" Width="350px"></asp:ListBox> 
                 </td>
                 <td>
                     <asp:TextBox ID="VegcheckoutTextBox" runat="server"></asp:TextBox>
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td> <h3>Groceries</h3></td>
                 <td>
                     <asp:ListBox ID="GroccheckoutListBox" runat="server" Rows="10" Width="350px"></asp:ListBox> 
                 </td>
                 <td>
                     <asp:TextBox ID="GroccheckoutTextBox" runat="server"></asp:TextBox>
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td> <h3>Furnitures</h3></td>
                 <td>
                     <asp:ListBox ID="FurncheckoutListBox" runat="server" Rows="10" Width="350px"></asp:ListBox> 
                 </td>
                 <td>
                     <asp:TextBox ID="FurncheckoutTextBox" runat="server"></asp:TextBox>
                 </td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td></td>
                 <td>
                     <asp:Label ID="Label1" runat="server" ForeColor="#6600FF" Text="Total Price"></asp:Label>
                 </td>
                 <td> <asp:TextBox ID="TotalCheckoutprice" runat="server"></asp:TextBox></td>
                 <td> <asp:Button ID="pay" runat="server" Text="Pay" OnClientClick="mesg()" Width="61px" /></td>
             </tr>
          </table>
    </div>
    </form>
</body>
</html>
