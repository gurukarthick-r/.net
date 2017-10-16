<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groceryorderform.aspx.cs" Inherits="Grocerystore.Groceryorderform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style14
        {
            width: 217px;
        }
        .auto-style15
        {
            width: 386px;
        }
        .auto-style16
        {
            width: 217px;
            height: 32px;
        }
        .auto-style17
        {
            width: 386px;
            height: 32px;
        }
        .auto-style21
        {
            width: 78px;
            height: 32px;
        }
        .auto-style22
        {
            width: 78px;
        }
        .auto-style25
        {
            width: 487px;
        }
        .auto-style26
        {
            width: 300px;
        }
        .auto-style27
        {
            width: 301px;
        }
        .auto-style28
        {
            width: 611px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <hgroup class="title">
                <h1><%: Title %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Store Order Entry Screen</h1>
            </hgroup>
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" Width="635px" StartNextButtonText="Proceed to Grocery" BorderColor="#CC9900" BorderStyle="Double" BorderWidth="2px" style="margin-right: 19px" StepNextButtonText="Proceed to Furnitures" StepPreviousButtonText="Go Back" FinishCompleteButtonText="Proceed to Checkout" FinishPreviousButtonText="Go Back" Height="377px" OnFinishButtonClick="Wizard1_FinishButtonClick" OnNextButtonClick="Wizard1_NextButtonClick" DisplaySideBar="False">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                    <table border="1" style="width: 700px">
                        <tr>
                            <td class="auto-style14" >
                                <asp:CheckBoxList ID="VeggieCheckBoxList" runat="server" Width="260px" Height="250"></asp:CheckBoxList> 
                            </td>
                            <td class="auto-style15">
                                <asp:RadioButtonList ID="VeggieRadioButtonList" runat="server" Width="186px" Height="250">
                                    <asp:ListItem Text="2kg" Value="2.00"></asp:ListItem>
                                    <asp:ListItem Text="1kg" Value="1.00"></asp:ListItem>
                                    <asp:ListItem Text="3/4kg" Value="0.75"></asp:ListItem>
                                    <asp:ListItem Text="1/2kg" Value="0.50"></asp:ListItem>
                                    <asp:ListItem Text="1/4kg" Value="0.25"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="auto-style22">
                                <asp:ListBox ID="VeggieListBox" runat="server" Width="352px" Height="200px" style="margin-right: 18px" AutoPostBack="True" OnSelectedIndexChanged="VeggieListBox_SelectedIndexChanged" EnableViewState="True"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                                <td class="auto-style16"><asp:Button ID="vegselectall" runat="server" OnClick="vegselectall_Click" Text="Select All" Width="70px" />
                                <asp:Button ID="vegclearall" runat="server" OnClick="vegclearall_Click" Text="Clear All" Width="66px" />
                                    <asp:Button ID="vegclearveggie" runat="server" OnClick="clearveggie_Click" Text="Clear Veggie" Width="79px" />
                            </td>
                            <td class="auto-style17"><asp:Button ID="vegaddcart" runat="server" Text="Add to Cart" OnClick="veggieaddcart_Click" Width="87px" />
                                <asp:Button ID="vegremovecart" runat="server" Text="Remove Cart" Width="95px" OnClick="vegremovecart_Click" Visible="False" />
                                </td>
                                <td class="auto-style21">
                                    <asp:TextBox ID="vegtotal" runat="server" Width="261px" ForeColor="#33CC33"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Vegmsglabel" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style22">
                                <asp:Button ID="vegcheckout" runat="server" Text="Checkout" Width="73px" OnClick="vegcheckout_Click" PostBackUrl="~/checkout.aspx" />
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                <table border="1" style="width: 700px">
                        <tr>
                            <td class="auto-style14" >
                                <asp:CheckBoxList ID="GroceryCheckBoxList" runat="server" Width="260px" Height="250"></asp:CheckBoxList> 
                            </td>
                            <td class="auto-style15">
                                <asp:RadioButtonList ID="GroceryRadioButtonList" runat="server" Width="186px" Height="250">
                                    <asp:ListItem Text="2kg" Value="2.00"></asp:ListItem>
                                    <asp:ListItem Text="1kg" Value="1.00"></asp:ListItem>
                                    <asp:ListItem Text="3/4kg" Value="0.75"></asp:ListItem>
                                    <asp:ListItem Text="1/2kg" Value="0.50"></asp:ListItem>
                                    <asp:ListItem Text="1/4kg" Value="0.25"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="auto-style22">
                                <asp:ListBox ID="GroceryListBox" runat="server" Width="352px" Height="200px" style="margin-right: 18px" AutoPostBack="True" OnSelectedIndexChanged="GroceryListBox_SelectedIndexChanged"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                                <td class="auto-style16"><asp:Button ID="groceryselectall" runat="server" OnClick="groceryselectall_Click" Text="Select All" Width="70px" />
                                <asp:Button ID="groceryclearall" runat="server" OnClick="groceryclearall_Click" Text="Clear All" Width="58px" />
                                    <asp:Button ID="cleargrocery" runat="server" OnClick="cleargrocery_Click" Text="Clear Grocery" Width="86px" />
                            </td>
                            <td class="auto-style17"><asp:Button ID="groceryaddcart" runat="server" Text="Add to Cart" OnClick="groceryaddcart_Click" Width="87px" />
                                <asp:Button ID="groceryremovecart" runat="server" Text="Remove Cart" Width="95px" OnClick="grocremovecart_Click" Visible="False" />
                                </td>
                                <td class="auto-style21">
                                    <asp:TextBox ID="grocerytotal" runat="server" Width="261px" ForeColor="#33CC33"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="grocerymsglabel" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style22">
                                <asp:Button ID="grocerycheckout" runat="server" Text="Checkout" Width="73px" OnClick="grocerycheckout_Click" PostBackUrl="~/checkout.aspx" />
                            </td>
                        </tr>
                    </table>
                    </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">
                    <table border="1" style="width: 706px">
                        <tr>
                            <td class="auto-style26">
                                <asp:DropDownList ID="FurnitureDropDownList" runat="server">
                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style27">
                                <asp:Label ID="lb1" runat="server" Text ="Enter the quantity"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:TextBox ID="FurnitureTextBox" runat="server" style="margin-left: 0px" Width="71px"></asp:TextBox>
                                &nbsp;&nbsp;
                                </td>
                            <td class="auto-style25">
                                <asp:ListBox ID="FurnitureListBox" runat="server" Width="430px" Height="200px" style="margin-right: 18px; margin-left: 0px;" AutoPostBack="True" OnSelectedIndexChanged="FurnitureListBox_SelectedIndexChanged"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Furnituremsglabel" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style27">
                                <asp:Button ID="Furnitureaddcart" runat="server" Text="Add to Cart" Width="82px" OnClick="Furnitureaddcart_Click" />
                                &nbsp;<asp:Button ID="furnremovecart" runat="server" Text="Remove Cart" OnClick="removecart_Click" Visible="False" />
                            </td>
                            <td class="auto-style25">
                                    <asp:TextBox ID="Furnituretotal" runat="server" Width="256px" ForeColor="#33CC33"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="clearall" runat="server" OnClick="clearall_Click" Text="Clear All" />
                            </td>
                        </tr>
                        </table>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
    </form>
</body>
</html>
