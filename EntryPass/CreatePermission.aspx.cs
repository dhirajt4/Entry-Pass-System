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
    public partial class CreatePermission : System.Web.UI.Page
    {
       // static int id = 0;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Set Permission";
            if (Session["id"] == null)
            {
                Response.Redirect("Login/login.aspx");
            }
            else
            {
            }
            ShowPermission();
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                obj.PermissionID =Convert.ToInt32(ViewState["id"]);
                obj.Permission = txtpermission.Text;
                obj.PermissionPage = txtpage.Text;
                obj.PermissionPageLevel = Convert.ToInt32(txtpermissionlevel.Text);
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
            Response.Redirect("AllPermission.aspx");
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

        public void clear()
        {
            txtpage.Text = "";
            txtpermission.Text = "";
            txtpermissionlevel.Text = "";
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
                    txtpermission.Text = ds.Tables[0].Rows[0]["PermissionName"].ToString();
                    txtpage.Text = ds.Tables[0].Rows[0]["PermissionPage"].ToString();
                    txtpermissionlevel.Text = ds.Tables[0].Rows[0]["PermissionLevel"].ToString();
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
    }
}