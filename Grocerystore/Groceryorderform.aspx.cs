using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Grocerystore
{
    public partial class Groceryorderform : System.Web.UI.Page
    {
        #region loadfromdb
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string datasetname, dttable, cachename,controllistname;

                valinit("vegcache", "vegtotalprice");
                string vegselstmt ="select * from vegetables where availquantity<>0";
                datasetname = "vegdataset";
                dttable = "vegtable";
                cachename = "vegcache";
                controllistname = "Veggie";
                populatecheckboxlist(vegselstmt, datasetname, dttable, cachename,controllistname);

                valinit("groccache", "groctotalprice");
                string grocselstmt = "select * from grocery where availquantity<>0";
                datasetname = "grocdataset";
                dttable = "groctable";
                cachename = "groccache";
                controllistname = "groc";
                populatecheckboxlist(grocselstmt, datasetname, dttable, cachename,controllistname);

                valinit("furncache", "furntotalprice");
                string furnselstmt = "select * from furnituretable where availquantity<>0";
                datasetname = "furndataset";
                dttable = "furntable";
                cachename = "furncache";
                controllistname = "furn";
                populatecheckboxlist(furnselstmt, datasetname, dttable, cachename, controllistname);
            }
        }

        private void valinit(string cachename, string tp)
        {
            Cache[cachename] = "";
            Session[tp] = 0;
        }
        
        private void populatecheckboxlist(string stmt, string dsname, string dttable, string cachename, string controllistname)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string selstmt = stmt;
                    SqlDataAdapter da = new SqlDataAdapter(selstmt, con);
                    DataSet ds = new DataSet(dsname);
                    DataTable dt = new DataTable();
                    da.Fill(ds,dsname);
                    dt = ds.Tables[dsname];
                    dt.TableName=dttable;
                    dt.PrimaryKey = new DataColumn[] {dt.Columns["id"]};
                    Cache[cachename] = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem li = new ListItem();
                        li.Text = dr["name"].ToString();
                        li.Value = dr["id"].ToString();
                        if (controllistname == "Veggie")
                            VeggieCheckBoxList.Items.Add(li);
                        else if (controllistname == "groc")
                            GroceryCheckBoxList.Items.Add(li);
                        else if (controllistname == "furn")
                            FurnitureDropDownList.Items.Add(li);
                    }
                }
        }
        #endregion

        #region veggie
        protected void veggieaddcart_Click(object sender, EventArgs e)
        {
            if (VeggieCheckBoxList.SelectedIndex == -1 || VeggieRadioButtonList.SelectedIndex == -1)
            {
                Vegmsglabel.Text = "Please select required vegetables and quantity";
                Vegmsglabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Vegmsglabel.Text = "";
                DataTable dt = (DataTable)Cache["vegcache"];
                double totalprice = 0;
                if (Session["vegtotalprice"] == null)
                    totalprice = 0;
                else
                    totalprice = Convert.ToDouble(Session["vegtotalprice"]);
                foreach (ListItem li in VeggieCheckBoxList.Items)
                {
                    if (li.Selected)
                    {
                        DataRow dr = dt.Rows.Find(li.Value);
                        double unitprice = (double)dr["unitprice"];
                        double itemprice = unitprice * Convert.ToDouble(VeggieRadioButtonList.SelectedValue);
                        totalprice = totalprice + itemprice;
                        string addeditem = "Veg: " + li.Text.ToUpper() + " |Unit price: $" + unitprice + " |Total: $" + itemprice;
                        ListItem cartitem = new ListItem();
                        cartitem.Text = addeditem;
                        string cartval = itemprice.ToString() + "-" + li.Text;
                        cartitem.Value = cartval;
                        VeggieListBox.Items.Add(cartitem);
                        Session["vegtotalprice"] = totalprice;
                    }
                }
                vegtotal.Text = "Total Price = $" + Session["vegtotalprice"].ToString();
                vegtotal.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void vegselectall_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in VeggieCheckBoxList.Items)
            {
                li.Selected = true;
            }
        }

        protected void vegclearall_Click(object sender, EventArgs e)
        {
            VeggieCheckBoxList.ClearSelection();
            VeggieRadioButtonList.ClearSelection();
            VeggieListBox.Items.Clear();
            vegtotal.Text = "";
            Vegmsglabel.Text = "";
            Session["vegtotalprice"] = 0;
            Session["vegcarttable"] = null;
        }

        protected void VeggieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vegremovecart.Visible = true;
        }

        protected void vegremovecart_Click(object sender, EventArgs e)
        {
            if (VeggieListBox.SelectedIndex != -1)
            {
                string[] itemval = VeggieListBox.SelectedValue.Split('-');
                double itemvalue = Convert.ToDouble(itemval[0]);
                VeggieListBox.Items.RemoveAt(VeggieListBox.SelectedIndex);
                Vegmsglabel.Text = "Item deleted from cart";
                Vegmsglabel.ForeColor = System.Drawing.Color.Green;
                vegremovecart.Visible = false;
                double earlierprice = Convert.ToDouble(Session["vegtotalprice"]);
                double finalprice = earlierprice - itemvalue;
                Session["vegtotalprice"] = finalprice;
                vegtotal.Text = "Total Price = $" + Session["vegtotalprice"].ToString();
            }
        }

        protected void clearveggie_Click(object sender, EventArgs e)
        {
            VeggieCheckBoxList.ClearSelection();
        }

        protected void vegcheckout_Click(object sender, EventArgs e)
        {
            Session["furncarttable"] = FurnitureListBox;
            Session["vegcarttable"] = VeggieListBox;
        }

        #endregion

        #region grocery
        protected void groceryaddcart_Click(object sender, EventArgs e)
        {
            if (GroceryCheckBoxList.SelectedIndex == -1 || GroceryRadioButtonList.SelectedIndex == -1)
            {
                grocerymsglabel.Text = "Please select required grocery and quantity";
                grocerymsglabel.ForeColor=System.Drawing.Color.Red;
            }
            else
            {
               grocerymsglabel.Text = "";
                DataTable dt = (DataTable)Cache["groccache"];
                double totalprice = 0;
                if (Session["groctotalprice"] == null)
                    totalprice = 0;
                else
                    totalprice = Convert.ToDouble(Session["groctotalprice"]);
                foreach (ListItem li in GroceryCheckBoxList.Items)
                {
                    if (li.Selected)
                    {
                        DataRow dr = dt.Rows.Find(li.Value);
                        double unitprice = (double)dr["unitprice"];
                        double itemprice = unitprice * Convert.ToDouble(GroceryRadioButtonList.SelectedValue);
                        totalprice = totalprice + itemprice;
                        string addeditem = "Groc: " + li.Text.ToUpper() + " |Unit price: $" + unitprice + " |Total: $" + itemprice;
                        ListItem cartitem = new ListItem();
                        cartitem.Text = addeditem;
                        string cartval = itemprice.ToString() + "-" + li.Text;
                        cartitem.Value = cartval;
                        GroceryListBox.Items.Add(cartitem);
                        Session["groctotalprice"] = totalprice;
                    }
                }
                grocerytotal.Text = "Total Price = $" + Session["groctotalprice"].ToString();
                grocerytotal.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void groceryselectall_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in GroceryCheckBoxList.Items)
            {
                li.Selected = true;
            }
        }

        protected void groceryclearall_Click(object sender, EventArgs e)
        {
            GroceryCheckBoxList.ClearSelection();
            GroceryRadioButtonList.ClearSelection();
            GroceryListBox.Items.Clear();
            grocerytotal.Text = "";
            grocerymsglabel.Text = "";
            Session["groctotalprice"] = 0;
            Session["groccarttable"] = null;
        }

        protected void GroceryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groceryremovecart.Visible = true;
        }

        protected void grocremovecart_Click(object sender, EventArgs e)
        {

            if (GroceryListBox.SelectedIndex != -1)
            {
                string[] itemval = GroceryListBox.SelectedValue.Split('-');
                double itemvalue = Convert.ToDouble(itemval[0]);
                GroceryListBox.Items.RemoveAt(GroceryListBox.SelectedIndex);
                grocerymsglabel.Text = "Item deleted from cart";
                grocerymsglabel.ForeColor = System.Drawing.Color.Green;
                groceryremovecart.Visible = false;
                double earlierprice = Convert.ToDouble(Session["groctotalprice"]);
                double finalprice = earlierprice - itemvalue;
                Session["groctotalprice"] = finalprice;
                grocerytotal.Text = "Total Price = $" + Session["groctotalprice"].ToString();
            }
        }

        protected void cleargrocery_Click(object sender, EventArgs e)
        {
            GroceryCheckBoxList.ClearSelection();
        }

        protected void grocerycheckout_Click(object sender, EventArgs e)
        {
            Session["furncarttable"] = FurnitureListBox;
            Session["groccarttable"] = GroceryListBox;
        }

        #endregion

        #region furniture
        protected void Furnitureaddcart_Click(object sender, EventArgs e)
        {
            if (FurnitureDropDownList.SelectedValue == "-1" || FurnitureTextBox.Text == "")
            {
                Furnituremsglabel.Text = "Please select required furniture and quantity";
                Furnituremsglabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                double totalprice=0;
                Furnituremsglabel.Text = "";
                if (Session["furntotalprice"] == null)
                    totalprice = 0;
                else
                    totalprice = Convert.ToDouble(Session["furntotalprice"]);
                DataTable dt = (DataTable)Cache["furncache"];
                DataRow dr = dt.Rows.Find(FurnitureDropDownList.SelectedValue);
                double unitprice = Convert.ToDouble(dr["unitprice"]);
                double itemprice = unitprice * Convert.ToInt32(FurnitureTextBox.Text);
                totalprice = totalprice + itemprice;
                string itemtext = FurnitureDropDownList.SelectedItem.Text.ToUpper() + " |Unit price= " + unitprice + " |Total price=" + itemprice;
                ListItem li = new ListItem();
                li.Text = itemtext;
                li.Value = itemprice.ToString() + "-"+ FurnitureDropDownList.SelectedItem.Text;
                FurnitureListBox.Items.Add(li);
                Session["furntotalprice"] = totalprice;
                Furnituretotal.Text = "Total Price = $" + Session["furntotalprice"].ToString();
                Furnituretotal.ForeColor = System.Drawing.Color.Green;
            }
            
        }

        protected void removecart_Click(object sender, EventArgs e)
        {
            if (FurnitureListBox.SelectedIndex != -1)
            {
                string[] itemval = FurnitureListBox.SelectedValue.Split('-');
                double itemprice = Convert.ToDouble(itemval[0]);
                FurnitureListBox.Items.RemoveAt(FurnitureListBox.SelectedIndex);
                Furnituremsglabel.Text = "Furniture removed from cart";
                Furnituremsglabel.ForeColor = System.Drawing.Color.Green;
                double earlierprice = Convert.ToDouble(Session["furntotalprice"]);
                double finalprice = earlierprice - itemprice;
                Session["furntotalprice"] = finalprice;
                Furnituretotal.Text = "Total Price = $" + Session["furntotalprice"].ToString();
                Furnituretotal.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void FurnitureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            furnremovecart.Visible = true;
        }

        protected void clearall_Click(object sender, EventArgs e)
        {
            FurnitureListBox.Items.Clear();
            Furnituretotal.Text = "";
            FurnitureTextBox.Text = "";
            Furnituremsglabel.Text = "";
            FurnitureDropDownList.ClearSelection();
            Session["furntotalprice"] = null;
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Furnituremsglabel.Text = "";
            /*string[] furniturearray = new string[100];
            int i =0;
            foreach (ListItem li in FurnitureListBox.Items)
            {
                furniturearray[i] = li.Text;
                ++i;
            }
            Session["furncarttable"] = furniturearray;*/
            Session["furncarttable"] = FurnitureListBox;
            Server.Transfer("~/checkout.aspx");
        }
      

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (e.CurrentStepIndex == 0)
            {
                Session["vegcarttable"] = VeggieListBox;
                Vegmsglabel.Text = "";
            }
            else if (e.CurrentStepIndex == 1)
            {
                Session["groccarttable"] = GroceryListBox;
                grocerymsglabel.Text = "";
            }
        }
     
        #endregion
    }
}