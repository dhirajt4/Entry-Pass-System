using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Layer;
using Business_ObjectLayer;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.IO;


namespace AirportAuthoritiesUI
{
    public partial class Main : System.Web.UI.MasterPage
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                restriction();
                if (Session["CompanyID"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx");
                }
                else
                {

                    if (!IsPostBack)
                    {
                        //showMenu();
                        showMenu();
                        showUsername();
                        agencytypefetch();

                    }
                    ProfilePic1.Src = "profileImage/" + Session["Pic"].ToString();
                    ProfilePic2.Src = "profileImage/" + Session["Pic"].ToString();
                    ProfilePic4.Src = "profileImage/" + Session["Pic"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void restriction()
        {
            try
            {
                string name = Path.GetFileName(Request.PhysicalPath);
                obj.PermissionPage = name;
                obj.Loginstatusid = Session["Login_Status"].ToString();
                obj.Roleid = Convert.ToInt32(Session["RoleID"].ToString());
                obj.Id = Convert.ToInt32(Session["id"].ToString());
                int i = bal.CheckPermissionByUserPageNameUserID(obj);
                if (i == 303)
                {
                }
                else if (i == 202)
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    //FormsAuthentication.SignOut();

                }
                else if (i == 404)
                {
                    // Response.Redirect("Login/login.aspx");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('You have not permission to view this page !');window.location ='Login/login.aspx';", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('You have not permission to view this page !');window.location ='Login/login.aspx';", true);
            }
        }
        public void showMenu()
        {
            try
            {
                obj.Roleid = Convert.ToInt32(Session["RoleID"].ToString());
                DataSet ds = bal.Fetch_Menu(obj);
                if(ds.Tables[0].Rows.Count>0)
                {
                    rptmenu.DataSource = ds;
                    rptmenu.DataBind();
                }
                else
                {
                    rptmenu.DataSource = "";
                    rptmenu.DataBind();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rptmenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                 Label l = e.Item.FindControl("Label1") as Label;
            obj.MenuID = Convert.ToInt32(l.Text);
            obj.Roleid = Convert.ToInt32(Session["RoleID"].ToString());
            DataSet ds = bal.Fetch_MenuByID(obj);
            Repeater rptSubmenu = (Repeater)e.Item.FindControl("rptsubmenu");
            rptSubmenu.DataSource = ds;
            rptSubmenu.DataBind();
            }
            catch (Exception)
            {
                
               // throw;
            }
        }

        protected void rptchild_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Label l = e.Item.FindControl("Label2") as Label;
            obj.MenuID = Convert.ToInt32(l.Text);
            DataSet ds = bal.Fetch_MenuByID(obj);
            Repeater rptChild = (Repeater)e.Item.FindControl("rptchild");
            rptChild.DataSource = ds;
            rptChild.DataBind();
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        private void GetMenuData()
        {
            try
            {
                 DataSet ds = bal.Fetch_Menu(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataView view = new DataView(ds.Tables[0]);
                view.RowFilter = "Isnull(ParentId,0)=0";
                foreach (DataRowView row in view)
                {
                    MenuItem menuItem = new MenuItem(row["Name"].ToString(), row["Id"].ToString());
                    menuItem.NavigateUrl = row["Url"].ToString();
                    //Menu1.Items.Add(menuItem);
                    AddChildItems(ds.Tables[0], menuItem);
                }
            }
            }
            catch (Exception)
            {
                
               // throw;
            }
        }

        private void AddChildItems(DataTable table, MenuItem menuItem)
        {
            try
            {
                DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentId=" + menuItem.Value;
            foreach (DataRowView childView in viewItem)
            {
                MenuItem childItem = new MenuItem(childView["Name"].ToString(), childView["Id"].ToString());
                childItem.NavigateUrl = childView["Url"].ToString();
                menuItem.ChildItems.Add(childItem);
                AddChildItems(table, childItem);
            }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        private void agencytypefetch()
        {
            try
            {
                obj.Pathurl = Path.GetFileName(Request.Path);
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                 obj.DdlControlName = "ddlagency";
                DataSet ds6 = bal.displayddl(obj);
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    ddlagencytype.DataSource = ds6;
                    ddlagencytype.DataTextField = ds6.Tables[0].Columns["Name"].Caption;
                    ddlagencytype.DataValueField = ds6.Tables[0].Columns["RecordValueInt"].Caption;
                    ddlagencytype.DataBind();
                    ddlagencytype.Items.Insert(0, "---Select Organization Type ---");
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            try
            {
                 obj.Logid = Convert.ToInt32(Session["id"]);
            obj.Logout_status = Convert.ToBoolean("False");
            int i = bal.loginstatus(obj);
            if(i==101)
            {
                Session.Clear();
                Session.Abandon();
              // FormsAuthentication.SignOut();
                Response.Redirect("~/Login/login.aspx");
            }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        public void showUsername()
        {
            try
            {

                lblusername.Text = Session["name"].ToString();
                lblusername2.Text = Session["name"].ToString();
                lblusernameonpopup.Text = Session["name"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnaddagencyname_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAgencyaddress.Text) && !string.IsNullOrEmpty(txtagencyname.Text) && ddlagencytype.SelectedIndex>0)
                {
                    obj.Agency_PAN = txtAgencypan.Text;
                    obj.Agency_emailid = txtagencyemailid.Text;
                    obj.Agency_CIN = txtAgencycin.Text;
                    obj.Agency_mobile = txtagencyphone.Text;
                    obj.Angency_name = txtagencyname.Text;
                    obj.Angency_address = txtAgencyaddress.Text;
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Agency_Type_id = Convert.ToInt32(ddlagencytype.SelectedValue);
                    int i = bal.insertagencyname(obj);
                    if (i == 101)
                    {
                        clearagency();
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Add Successfully...!');window.location ='#';", true);
                    }
                    else if (i == 202)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again Later...!');window.location ='#';", true);
                    }
                    else if (i == 303)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Organization Name Already Exists...!');window.location ='#';", true);
                    }
                }
                else{
                     ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('All Field Required...!');window.location ='#';", true);
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        private void clearagency()
        {
            try
            {
                txtAgencyaddress.Text = string.Empty;
                txtAgencycin.Text = string.Empty;
                txtagencyemailid.Text = string.Empty;
                txtagencyname.Text = string.Empty;
                txtAgencypan.Text = string.Empty;
                txtagencyphone.Text = string.Empty;
                ddlagencytype.SelectedIndex = 0;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //protected void rptsubmenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    Label l = e.Item.FindControl("Label2") as Label;
        //    obj.PageTitleID = Convert.ToInt32(l.Text);
        //    DataSet ds = bal.Fetch_PageTitleByID(obj);
        //    string title=ds.Tables[0].Rows[0]["Title"].ToString();
        //    Session["Title"] = title;
        //    string url = ds.Tables[0].Rows[0]["Url"].ToString();
        //    Response.Redirect(url);
        //}

    }
}