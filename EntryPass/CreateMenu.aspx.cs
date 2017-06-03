using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Business_ObjectLayer;
using Business_Layer;
using System.IO;
using System.Data;


namespace AirportAuthoritiesUI
{
    public partial class CreateMenu : System.Web.UI.Page
    {
        //static int id = 0;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Add Menu";
            if (Session["id"] == null)
            {
                Response.Redirect("Login/login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ShowMenu();
                }
            }
        }

        public void ShowMenu()
        {
            try
            {
                DataSet ds = bal.FetchAllMenu(obj);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                obj.MenuID =Convert.ToInt32(ViewState["id"]);
                obj.MenuName = txtmenu.Text;
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                int i = bal.InsertMenu(obj);
                if (i == 1)
                {
                    Label1.Text = "Menu Submited Successfully";
                    clear();
                    ShowMenu();
                }
                else if (i == 101)
                {
                    Label1.Text = "Menu Updated Successfully";
                    clear();
                    ShowMenu();
                }
                else if (i == 102)
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Menu Already Exists";
                }
            }
            catch
            {
            }
        }

        public void clear()
        {
            txtmenu.Text = "";
            ViewState["id"] = 0;
            btn_submit.Text = "Submit";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    obj.MenuID = Convert.ToInt32(e.CommandArgument.ToString());
                    ViewState["id"] = Convert.ToInt32(e.CommandArgument.ToString());
                    DataSet ds = bal.FetchMenuByID(obj);
                    txtmenu.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    btn_submit.Text = "Update";
                }

               else if (e.CommandName == "Delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    obj.PermissionID = id;
                    int i = bal.PermissionDelete(obj);
                    //int id = Convert.ToInt32(e.CommandArgument.ToString());
                    //obj.Roleid = id;
                    //int i = bal.RoleDelete(obj);
                    ShowMenu();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}