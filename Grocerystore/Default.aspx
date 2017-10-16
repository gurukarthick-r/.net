<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grocerystore._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                   <img  src="Images/tvl1.jpg" id="myimages" style="width:1000px;height:250px" />                     <script type="text/javascript">
                         var i = 1;
                         function rotateimage() {
                             document.getElementById("myimages").setAttribute("src", "Images/tvl" + i + ".jpg");
                             i = i + 1;
                             if (i == 9) { i = 1; }

                         }
                         setInterval(rotateimage, 1000);
                     </script>
                    <%: Title %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Store Inventory Management System<br />
                </h1>
            </hgroup>
            <asp:Button ID="Button1" runat="server" Text="Login as User" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Login as Admin" OnClick="Button2_Click" />
            <br />
        </div>
    </section>
</asp:Content>

