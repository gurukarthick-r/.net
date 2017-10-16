using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Grocerystore
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Veggie and Grocery checkout buttons transfer through crosspage postback. Hence checking through
             *  the findcontrol property. there is no server.transfer for veggie/grocery checkout screens. transfer
             *  set at the button property window  pagecrosspagepostback itself.
             * 
             * furniture checkout happens through the wizard finish button and it does not support crosspage postback
             * so getting the listitems through session. Refer groceryorderform.aspx.cs for server.transfer method for
             * furniture.
             * 
           
             */
            if (!IsPostBack)
            {
                double vegcheckoutprice = 0, groccheckoutprice = 0, furncheckoutprice = 0;
                Groceryorderform previouspage = (Groceryorderform)Page.PreviousPage;
                if (previouspage != null)
                {
                    Wizard w1 = (Wizard)previouspage.FindControl("Wizard1");
                    ListBox vl = (ListBox)w1.FindControl("VeggieListBox");
                    foreach (ListItem li in vl.Items)
                    {
                        VegcheckoutListBox.Items.Add(li);
                    }
                    if (Session["vegtotalprice"] == null)
                        VegcheckoutTextBox.Text = "0";
                    else
                    {
                        VegcheckoutTextBox.Text = Session["vegtotalprice"].ToString();
                        vegcheckoutprice = Convert.ToDouble(VegcheckoutTextBox.Text);
                    }

                    ListBox gl = (ListBox)w1.FindControl("GroceryListBox");
                    foreach (ListItem li in gl.Items)
                    {
                        GroccheckoutListBox.Items.Add(li);
                    }
                    if (Session["groctotalprice"] == null)
                        GroccheckoutTextBox.Text = "0";
                    else
                    {
                        GroccheckoutTextBox.Text = Session["groctotalprice"].ToString();
                        groccheckoutprice = Convert.ToDouble(GroccheckoutTextBox.Text);
                    }
                }

                /* Server.trasnfer method transfer  from groceryorderform*/
                if (Session["furncarttable"] != null )
                {
                    foreach (ListItem li in ((ListBox)(Session["furncarttable"])).Items)
                    {
                        FurncheckoutListBox.Items.Add(li);
                    }
                    if (Session["furntotalprice"] == null)
                        FurncheckoutTextBox.Text = "0";
                    else
                    {
                        FurncheckoutTextBox.Text = Session["furntotalprice"].ToString();
                        furncheckoutprice = Convert.ToDouble(FurncheckoutTextBox.Text);
                    }
                }

                double totalcartprice = vegcheckoutprice + groccheckoutprice + furncheckoutprice;
                TotalCheckoutprice.Text = totalcartprice.ToString();

                //ListItem[] groclist = new ListItem[] { (ListItem)Session["groccarttable"] };
                //GroccheckoutListBox.Items.AddRange(groclist);
            }
         }
        
       }
}