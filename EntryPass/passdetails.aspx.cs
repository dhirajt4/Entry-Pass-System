using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business_Layer;
using Business_ObjectLayer;
using System.IO;
using Microsoft.Reporting.WebForms;


namespace EntryPass
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        //static int name = 0;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillangencyname();
                passdetails();
                Page.Title = "Entry | A E P Pass Information";
            }
        }

        public void fillangencyname()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                DataSet dt = bal.fetchallpassdetail(obj);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    ddlAgencyName.DataSource = dt.Tables[0];
                    ddlAgencyName.DataTextField = dt.Tables[0].Columns["nameofagency"].ToString();
                    ddlAgencyName.DataValueField = dt.Tables[0].Columns["nameofagency"].ToString();
                    ddlAgencyName.DataBind();
                    ddlAgencyName.Items.Insert(0, "All");
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }
        public void passdetails()
        {
            try
            {
                if (Convert.ToInt32(ViewState["name"]) == 100)
                {
                    obj.Applicantname = ddlapplicantname.SelectedValue;
                }
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                obj.Active = 11;
                obj.Selectagencyname = ddlAgencyName.SelectedValue;
                DataSet dt = bal.DisplayApprovePass(obj);
                ViewState["dt"] = dt;
                if (dt.Tables[0].Rows.Count > 0)
                {
                    rptpassdetails.Visible = true;
                    rptpassdetails.DataSource = dt.Tables[0];
                    rptpassdetails.DataBind();
                    //dgvPassDetails.Columns[2].Visible = false;
                }
                else
                {
                    rptpassdetails.Visible = false;
                }
            }
            catch (Exception)
            {

                // throw;
            }
            finally
            {
                ViewState["name"] = 0;
            }
        }
        protected void ddlAgencyName_TextChanged(object sender, EventArgs e)
        {
            fillapplicantname();
            passdetails();
            
        }

        protected void rptpassdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "doc")
                {
                    string path = "Doc" + e.CommandArgument + ".pdf";
                    FileInfo file2 = new FileInfo(Server.MapPath("Physical//" + path));
                    if (file2.Exists)
                    {
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + path);
                        Response.TransmitFile(Server.MapPath("Physical//" + path));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('File Not Found');window.location ='#';", true);
                    }
                }
                else if (e.CommandName == "bcas")
                {
                    string path = "BCAS" + e.CommandArgument + ".pdf";
                    FileInfo file2 = new FileInfo(Server.MapPath("Physical//" + path));
                    if (file2.Exists)
                    {
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + path);
                        Response.TransmitFile(Server.MapPath("Physical//" + path));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('File Not Found');window.location ='#';", true);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void fillapplicantname()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                obj.Agencyname = ddlAgencyName.SelectedValue;
                DataSet dt = bal.selectagencyname(obj);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    ddlapplicantname.DataSource = dt;
                    ddlapplicantname.DataTextField = dt.Tables[0].Columns["applicantname"].ToString();
                    ddlapplicantname.DataTextField = dt.Tables[0].Columns["applicantname"].ToString();
                    ddlapplicantname.DataBind();
                }
                else
                {
                    ddlapplicantname.Items.Clear();
                }
            }
            catch (Exception)
            {
                
               // throw;
            }
           
        }

        protected void ddlapplicantname_TextChanged(object sender, EventArgs e)
        {
            ViewState["name"] = 100;
            passdetails();
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {

            try
            {
                string filename = "AEP" + DateTime.Now.ToString("_dd/mm/yyyy_HH:mm:ss") + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = ViewState["dt"];
                dgGrid.DataBind();
                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
                ViewState["dt"] = null;
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
    }
}