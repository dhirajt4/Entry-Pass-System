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

namespace EntryPass
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P BCAS Update";
            if (!IsPostBack)
            {
                permanentpassdetails();
            }
      }
        public void permanentpassdetails()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                obj.Active = 4;
                DataSet dt = bal.DisplayApprovePass(obj);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    rptpermanentAEPUpdate.Visible = true;
                    rptpermanentAEPUpdate.DataSource = dt.Tables[0];
                    rptpermanentAEPUpdate.DataBind();
                    //GridView1.Visible = true;
                    //GridView1.DataSource = dt.Tables[0];
                    //GridView1.DataBind();
                }
                else
                {
                    //rptpermanentAEPUpdate.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvpermanentpass_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        
        protected void dgvpermanentpass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;

        //    permanentpassdetails();
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1; 
        //    permanentpassdetails();
        //}

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
           

        //    permanentpassdetails();
        //}

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

        //    GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

        //    //Label lblID = (Label)row.FindControl("lblID");

        //    //TextBox txtname=(TextBox)gr.cell[].control[];

        //    TextBox textName = (TextBox)row.Cells[0].Controls[0];

        //   // TextBox textadd = (TextBox)row.Cells[1].Controls[0];

        //   // TextBox textc = (TextBox)row.Cells[2].Controls[0];

        //    //TextBox textadd = (TextBox)row.FindControl("txtadd");

        //    //TextBox textc = (TextBox)row.FindControl("txtc");

        //    GridView1.EditIndex = -1;
        //    string aa = textName.Text;
        //}

        protected void rptpermanentAEPUpdate_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                try
                {
                    ((Label)e.Item.FindControl("lblPeriodFrom")).Visible = false;
                    ((Label)e.Item.FindControl("lblPeriodTo")).Visible = false;
                    ((Label)e.Item.FindControl("lblpassno")).Visible = false;
                    ((TextBox)e.Item.FindControl("txtPeriodFrom")).Visible = true;
                    ((TextBox)e.Item.FindControl("txtPeriodTo")).Visible = true;
                    ((TextBox)e.Item.FindControl("txtpassno")).Visible = true;
                    ((FileUpload)e.Item.FindControl("fuPermanentAepDoc")).Visible = true;
                    ((LinkButton)e.Item.FindControl("linkEdit")).Visible = false;
                    ((LinkButton)e.Item.FindControl("linkUpdate")).Visible = true;
                    ((LinkButton)e.Item.FindControl("linkCancel")).Visible = true;
                }
                catch (Exception)
                {

                    // throw;
                }

            }
            else if (e.CommandName == "Update")
            {
                try
                {
                    TextBox from = (TextBox)e.Item.FindControl("txtPeriodFrom");
                    TextBox to = (TextBox)e.Item.FindControl("txtPeriodTo");
                    TextBox passno = (TextBox)e.Item.FindControl("txtpassno");
                    Label id = (Label)e.Item.FindControl("lbluniqueid");
                    FileUpload fileupload = (FileUpload)e.Item.FindControl("fuPermanentAepDoc");
                    obj.Periodfrom = Convert.ToDateTime(((TextBox)e.Item.FindControl("txtPeriodFrom")).Text);
                    obj.Periodto = Convert.ToDateTime(to.Text);
                    obj.PermanentAEpid1 = id.Text;
                    obj.PermanentAEPNo = passno.Text;
                    obj.LoginID = Convert.ToInt32(Session["id"]);
                    if (fileupload.PostedFile.FileName != "" && passno.Text != "")
                    {
                        int i = bal.updatepermanentpass(obj);
                        if (i == 202)
                        {
                            string pp = fileupload.PostedFile.FileName;
                            if (fileupload.PostedFile.FileName != "")
                            {
                                string bcas = "BCAS" + obj.PermanentAEpid1 + Path.GetExtension(fileupload.PostedFile.FileName);
                                string path2 = Server.MapPath("Physical//" + bcas);
                                FileInfo file2 = new FileInfo(path2);
                                if (file2.Exists)
                                {
                                    file2.Delete();
                                    fileupload.SaveAs(Server.MapPath("Physical/") + "/" + bcas);
                                }
                                else
                                {
                                    fileupload.SaveAs(Server.MapPath("Physical/") + "/" + bcas);
                                }
                            }
                            permanentpassdetails();
                            ((Label)e.Item.FindControl("lblPeriodFrom")).Visible = true;
                            ((Label)e.Item.FindControl("lblPeriodTo")).Visible = true;
                            ((Label)e.Item.FindControl("lblpassno")).Visible = true;
                            ((TextBox)e.Item.FindControl("txtPeriodFrom")).Visible = false;
                            ((TextBox)e.Item.FindControl("txtPeriodTo")).Visible = false;
                            ((TextBox)e.Item.FindControl("txtpassno")).Visible = false;
                            ((FileUpload)e.Item.FindControl("fuPermanentAepDoc")).Visible = false;
                            ((LinkButton)e.Item.FindControl("linkEdit")).Visible = true;
                            ((LinkButton)e.Item.FindControl("linkUpdate")).Visible = false;
                            ((LinkButton)e.Item.FindControl("linkCancel")).Visible = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('AEP No & Verification Document Successfully Update ...!!!');window.location ='#';", true);
                            
                        }
                        else
                        {
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please insert AEP No & Verification Document...!!!');window.location ='#';", true);
                    }
                }
                catch (Exception)
                {

                    // throw;
                }

            }
            else if (e.CommandName == "Cancel")
            {
                try
                {
                    ((Label)e.Item.FindControl("lblPeriodFrom")).Visible = true;
                    ((Label)e.Item.FindControl("lblPeriodTo")).Visible = true;
                    ((Label)e.Item.FindControl("lblpassno")).Visible = true;
                    ((TextBox)e.Item.FindControl("txtPeriodFrom")).Visible = false;
                    ((TextBox)e.Item.FindControl("txtPeriodTo")).Visible = false;
                    ((TextBox)e.Item.FindControl("txtpassno")).Visible = false;
                    ((FileUpload)e.Item.FindControl("fuPermanentAepDoc")).Visible = false;
                    ((LinkButton)e.Item.FindControl("linkEdit")).Visible = true;
                    ((LinkButton)e.Item.FindControl("linkUpdate")).Visible = false;
                    ((LinkButton)e.Item.FindControl("linkCancel")).Visible = false;
                }
                catch (Exception)
                {

                    // throw;
                }

            }
        }
    }
}