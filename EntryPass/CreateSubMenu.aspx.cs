using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Business_ObjectLayer;
using Business_Layer;
using System.IO;

namespace AirportAuthoritiesUI
{
    public partial class CreateSubMenu : System.Web.UI.Page
    {
        //static int id = 0;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Add SubMenu";
            if (Session["id"] == null)
            {
                Response.Redirect("Login/login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ShowMenu();
                    ShowPermission();
                    Showlevel();
                }
            }
            
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                string sd = ddlmenu.SelectedValue;
                obj.MenuID = Convert.ToInt32(ddlmenu.SelectedValue);
                obj.PermissionID =Convert.ToInt32(ViewState["id"]);
                obj.Permission = txtpermission.Text;
                obj.PermissionPage = txtpage.Text;
                obj.PermissionPageLevel = Convert.ToInt32(ddlpermissionlevel.SelectedValue);
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                int i = bal.InsertPermission(obj);
                if (i == 1)
                {
                    Label1.Text = "Permission Created Successfully !!";
                    // ShowPermission();
                    clear();
                    ShowPermission();
                }
                else
                {
                    Label1.Text = "Permission Updated Successfully !!";
                    // ShowPermission();
                    clear();
                    ShowPermission();
                }
            }
            catch
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void ShowPermission()
        {
            try
            {
                DataSet ds = bal.FetchPermission(obj);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ShowMenu()
        {
            try
            {
                DataSet ds = bal.FetchAllMenu(obj);
                ddlmenu.DataSource = ds;
                ddlmenu.DataTextField = "Name";
                ddlmenu.DataValueField = "id";
                ddlmenu.DataBind();
            }
            catch (Exception)
            {

                throw;
            }   
        }
        public void Showlevel()
        {
            try
            {
                DataSet ds = bal.FetchAllLevels(obj);
                ddlpermissionlevel.DataSource = ds;
                ddlpermissionlevel.DataTextField = "RoleName";
                ddlpermissionlevel.DataValueField = "RoleLevel";
                ddlpermissionlevel.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void clear()
        {
            txtpage.Text = "";
            txtpermission.Text = "";
            ddlpermissionlevel.SelectedIndex = 0;
            ViewState["id"] = 0;
            btn_submit.Text = "Submit";
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {

                    ViewState["id"] = Convert.ToInt32(e.CommandArgument.ToString());
                    obj.PermissionID = Convert.ToInt32(ViewState["id"]);
                    DataSet ds = bal.FetchPermissionByID(obj);
                    txtpermission.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtpage.Text = ds.Tables[0].Rows[0]["Url"].ToString();
                    ddlpermissionlevel.SelectedValue = ds.Tables[0].Rows[0]["PageLevel"].ToString();
                    ddlmenu.SelectedValue = ds.Tables[0].Rows[0]["Parentid"].ToString();
                    btn_submit.Text = "Update";
                }
               else if (e.CommandName == "Delete")
                {

                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    obj.PermissionID = id;
                    int i = bal.PermissionDelete(obj);
                    ShowPermission();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Repeater1_DataBinding(object sender, EventArgs e)
        {
            //Label active = (Label)FindControl("lblactive");
            //if (active.Text == "true")
            //{
            //    active.Text = "True";
            //}
            //else
            //{
            //    active.Text = "False";
            //}
        }
    }
}