<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreInventorymgmt.aspx.cs" Inherits="Grocerystore.StoreInventorymgmt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <hgroup class="title">
                <h1><%: Title %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Store Inventory Management System</h1>
            </hgroup>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View3" runat="server">
                <asp:Button ID="addfurnitures" runat="server" Text="Stock New Furnitures" Width="152px" CommandName="addfurnitures" OnCommand="addproducts_Command" />
                <asp:Button ID="maintainfurnitures" runat="server"  Text="Restock Furnitures" CommandName="maintainfurnitures" OnCommand="maintainproducts_Command" style="margin-left: 5px" Width="152px"/>
                <br />
                <asp:Button ID="addveggie" runat="server"  Text="Stock New Vegetables" Width="152px" CommandName="addvegetables" OnCommand="addproducts_Command"/>
                &nbsp;<asp:Button ID="maintainveggie" runat="server" Text="Restock Vegetables" Width="152px"  CommandName="maintainvegetables" OnCommand="maintainproducts_Command"/>
                &nbsp;<br /> <asp:Button ID="addgrocery" runat="server" Text="Stock New Grocery" Width="152px" CommandName="addgroceries" OnCommand="addproducts_Command"/>
                &nbsp;<asp:Button ID="maintaingrocery" runat="server" CommandName="maintaingroceries" OnCommand="maintainproducts_Command" Text="Restock Grocery" Width="152px" />
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Default.aspx" Text="Exit" Width="60px" />
                &nbsp;<asp:Button ID="Button2" runat="server" PostBackUrl="~/Groceryorderform.aspx" Text="Order Entry" />
            </asp:View>
            <asp:View ID="View1" runat="server" >
                <h2>Product Management screen</h2>   
                <asp:Button ID="uploadtodb" runat="server" OnClick="uploadtodb_Click" Text="Upload to DB" Width="100px" />
                &nbsp;<asp:Button ID="mainmenubutton" runat="server" OnClick="mainmenubutton_Click" Text="Main Menu" />
&nbsp;<asp:GridView ID="nongrocGridView" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="id" ForeColor="Black" OnRowCancelingEdit="nongrocGridView_RowCancelingEdit" OnRowDeleting="nongrocGridView_RowDeleting" OnRowEditing="nongrocGridView_RowEditing" OnRowUpdating="nongrocGridView_RowUpdating">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                        <asp:BoundField DataField="unitprice" HeaderText="unitprice" SortExpression="unitprice" />
                        <asp:BoundField DataField="availquantity" HeaderText="availquantity" SortExpression="availquantity" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <asp:Label ID="nongroclabel" runat="server" Text=""></asp:Label>
                <br />
                <br />
                
            </asp:View>
            <asp:View ID="View2" runat="server" OnActivate="View2_Activate">
                <table>
                    <tr>
                        <td colspan="2"><h3>New Product Insert screen</h3><h4><asp:Label ID="insertscreenlabel" runat="server" Text=""></asp:Label></h4>  </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="newproductinsertButton" runat="server" Text="Insert to DB" OnClick="newproductinsertButton_Click" />           
                            <asp:Button ID="mainmenubutton_addprod" runat="server" OnClick="mainmenubutton_addprod_Click" Text="Main Menu" />
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="NAME"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="UNIT PRICE"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="unitpriceTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="QUANTITY"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="quantityTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="newproductinsertlabel" runat="server"></asp:Label>
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
