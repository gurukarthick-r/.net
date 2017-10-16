using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Grocerystore 
{
    public partial class StoreInventorymgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            addfurnitures.ToolTip = "Add furnitures";
        }
        
        #region mainmenu
        protected void addproducts_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "addfurnitures":
                    {
                        Session["insertstmt"] = "insert into furnituretable values(@name,@unitprice,@availquantity)";
                        Session["insertscreenmsg"] = "Insert Furnitures ";
                        MultiView1.ActiveViewIndex = 2; //transfer to add newproduct view
                        newproductinsertlabel.Text = ""; //initialize label so that previous msg is erased
                        break;
                    }
                case "addvegetables":
                    {
                        Session["insertstmt"] = "insert into vegetables values(@name,@unitprice,@availquantity)";
                        Session["insertscreenmsg"] = "Insert Vegetables";
                        MultiView1.ActiveViewIndex = 2; //transfer to add newproduct view
                        newproductinsertlabel.Text = ""; //initialize label so that previous msg is erased
                        break;
                    }
                case "addgroceries":
                    {
                        Session["insertstmt"] = "insert into grocery values(@name,@unitprice,@availquantity)";
                        Session["insertscreenmsg"] = "Insert Groceries";
                        MultiView1.ActiveViewIndex = 2; //transfer to add newproduct view
                        newproductinsertlabel.Text = ""; //initialize label so that previous msg is erased
                        break;
                    }
            }
        }

        protected void maintainproducts_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "maintainfurnitures":
                    {
                        Session["maintainselectstmt"] = "select * from furnituretable";
                        Session["maintaindeletestmt"] = "delete from furnituretable where id=@id";
                        Session["maintaintablename"] = "Furnitures";
                        MultiView1.ActiveViewIndex = 1;
                        loaddb_nginventory();
                        break;
                    }
                case "maintainvegetables":
                    {
                        Session["maintainselectstmt"] = "select * from vegetables";
                        Session["maintaindeletestmt"] = "delete from vegetables where id=@id";
                        Session["maintaintablename"] = "Vegetables";
                        MultiView1.ActiveViewIndex = 1;
                        loaddb_nginventory();
                        break;
                    }
                case "maintaingroceries":
                    {
                        Session["maintainselectstmt"] = "select * from grocery";
                        Session["maintaindeletestmt"] = "delete from grocery where id=@id";
                        Session["maintaintablename"] = "Groceries";
                        MultiView1.ActiveViewIndex = 1;
                        loaddb_nginventory();
                        break;
                    }
            }
        }
        #endregion
 
        #region loadgridview
        private void loaddb_nginventory()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string tablename = Session["maintaintablename"].ToString();
                SqlDataAdapter da = new SqlDataAdapter(Session["maintainselectstmt"].ToString(), con);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds, tablename);
                nongrocGridView.DataSource = ds;
                nongrocGridView.DataBind();
                ds.Tables[tablename].PrimaryKey = new DataColumn[] { ds.Tables[tablename].Columns["id"] };
                Cache[tablename] = ds;
                nongroclabel.Text = "Products loaded successfully " + tablename + " tables";
                nongroclabel.ForeColor = System.Drawing.Color.Green;
                nongrocGridView.Columns[1].Visible = false;
            }
        }
        private void loadcache_nginventory()
        {
            string cachename = Session["maintaintablename"].ToString();
            if(Cache[cachename] != null)
            {
                nongrocGridView.Columns[1].Visible = false;
                nongrocGridView.DataSource = (DataSet)Cache[cachename];
                nongrocGridView.DataBind();
            }
            else 
            {
                nongroclabel.Text = "Non grocery inventory not in cache";
                nongroclabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion

        #region gridviewmaintain
        protected void nongrocGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            nongrocGridView.EditIndex = e.NewEditIndex;
            loadcache_nginventory();
        }

        protected void nongrocGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string tablename=Session["maintaintablename"].ToString();
            DataSet ds = (DataSet)Cache[tablename];
            DataRow dr = ds.Tables[tablename].Rows.Find(e.Keys["id"]);
            dr.Delete();
            nongroclabel.Text = "delete success";
            nongroclabel.ForeColor = System.Drawing.Color.Green;
            Cache[tablename] = ds;
            loadcache_nginventory();
        }

        protected void nongrocGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            nongrocGridView.EditIndex = -1;
            loadcache_nginventory();
            nongroclabel.Text = "Edit cancel success";
            nongroclabel.ForeColor = System.Drawing.Color.Green;
        }

        protected void nongrocGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string tablename = Session["maintaintablename"].ToString();
            DataSet ds = (DataSet)Cache[tablename];
            DataRow dr = ds.Tables[tablename].Rows.Find(e.Keys["id"]);
            dr["name"] = e.NewValues["name"];
            dr["unitprice"] = e.NewValues["unitprice"];
            dr["availquantity"] = e.NewValues["availquantity"];
            Cache[tablename] = ds;
            nongrocGridView.EditIndex = -1;
            nongroclabel.Text = "Product :"+ dr["name"].ToString() + " update success";
            nongroclabel.ForeColor = System.Drawing.Color.Green;
            loadcache_nginventory();
        }

        protected void uploadtodb_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string selcmd = Session["maintainselectstmt"].ToString();
                string tablename = Session["maintaintablename"].ToString();
                SqlDataAdapter da = new SqlDataAdapter(selcmd, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                DataSet ds = (DataSet)Cache[tablename];
                da.SelectCommand.Parameters.Add("@name", SqlDbType.NChar, 50, "name");
                da.SelectCommand.Parameters.Add("@unitprice", SqlDbType.Float, 0, "unitprice");
                da.SelectCommand.Parameters.Add("@availquantity", SqlDbType.Int, 0, "availquantity");

                string delstatement = Session["maintaindeletestmt"].ToString();
                SqlCommand delcmd = new SqlCommand(delstatement, con);
                delcmd.Parameters.Add("@id", SqlDbType.Int, 0, "id");

                da.DeleteCommand = delcmd;
                con.Open();
                da.Update(ds, tablename);
                
                Cache.Remove(tablename);
                loaddb_nginventory();
                
            }
        }

        protected void mainmenubutton_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        #endregion

        #region addnewproduct
        protected void View2_Activate(object sender, EventArgs e)
        {
            insertscreenlabel.Text = Session["insertscreenmsg"].ToString();
        }

        protected void newproductinsertButton_Click(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 2)
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sqlcmd = Session["insertstmt"].ToString();
                    SqlCommand cmd = new SqlCommand(sqlcmd, con);
                    cmd.Parameters.AddWithValue("name", nameTextBox.Text);
                    cmd.Parameters.AddWithValue("unitprice", unitpriceTextBox.Text);
                    cmd.Parameters.AddWithValue("@availquantity", quantityTextBox.Text);
                    con.Open();
                    int rowinserted = cmd.ExecuteNonQuery();
                    newproductinsertlabel.Text = nameTextBox.Text + " added to database";
                    newproductinsertlabel.ForeColor = System.Drawing.Color.Green;
                    nameTextBox.Text = "";
                    quantityTextBox.Text = "";
                    unitpriceTextBox.Text = "";
                }
            }
        }
    
        protected void mainmenubutton_addprod_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        #endregion

    }
}