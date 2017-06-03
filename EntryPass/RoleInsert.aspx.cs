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
    public partial class RoleInsert : System.Web.UI.Page
    {
        //static int id = 0;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Add Role";
            if (Session["id"] == null)
            {
                Response.Redirect("Login/login.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    ShowRole();
                }
            }
        }

        public void ShowRole()
        {
            try
            {
                DataSet ds = bal.FetchRole(obj);
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
                obj.Roleid =Convert.ToInt32(ViewState["id"]);
                obj.Role = txtrole.Text;
                obj.RoleLevel = Convert.ToInt32(txtrolelevel.Text);
                int i = bal.InsertRole(obj);
                if (i == 1)
                {
                    Label1.Text = "Role Submited Successfully";
                    clear();
                    ShowRole();
                }
                else if (i == 101)
                {
                    Label1.Text = "Role Updated Successfully";
                    clear();
                    ShowRole();
                }
                else if (i == 102)
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Role Already Exists";
                }
            }
            catch
            {
            }
        }

        public void clear()
        {
            txtrole.Text = "";
            txtrolelevel.Text = "";
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
                    obj.Roleid = Convert.ToInt32(e.CommandArgument.ToString());
                    ViewState["id"] = Convert.ToInt32(e.CommandArgument.ToString());
                    DataSet ds = bal.FetchRoleByID(obj);
                    txtrole.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    txtrolelevel.Text = ds.Tables[0].Rows[0]["RoleLevel"].ToString();
                    btn_submit.Text = "Update";
                }

                else if (e.CommandName == "Delete")
                {

                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    obj.Roleid = id;
                    int i = bal.RoleDelete(obj);
                    ShowRole();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}