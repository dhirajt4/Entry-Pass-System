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
    public partial class ForApprovel : System.Web.UI.Page
    {
        public string selectexcel = string.Empty;
        //static string aa;
        // static int k = 0;
        DataSet ds = new DataSet();
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Page.Title = "Entry | A E P Approval Process";
                displayPassForApprovel();
            }
        }
        public void displayPassForApprovel()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                if (rbUnapproved.Checked == true)
                {
                    obj.Active = 0;
                }
                else if (rbapproved.Checked == true)
                {
                    obj.Active = 20;
                }
                else if (rbreject.Checked == true)
                {
                    obj.Active = -1;
                }
                else if (rbyearlypassdetail.Checked == true)
                {
                    obj.Active = 15;
                }
                ds = bal.DisplayApprovePass(obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptforPassapprovel.Visible = true;
                    rptforPassapprovel.DataSource = ds.Tables[0];
                    rptforPassapprovel.DataBind();
                    //btnexporttoexcel.Visible = true;
                }
                else
                {
                    btnexporttoexcel.Visible = false;
                    rptforPassapprovel.Visible = false;
                }
            }
            catch (Exception)
            {

                // throw;
            }
        }
        protected void rptforPassapprovel_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                try
                {
                    Session["uniqueid"] = Convert.ToInt64(e.CommandArgument);
                    Response.Redirect("entrypass.aspx");

                }
                catch (Exception)
                {

                    // throw;
                }
            }
            else if (e.CommandName == "print")
            {
                try
                {
                    Session["print"] = 303;
                    Session["receipt"] = null;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "SelectName('" + e.CommandArgument.ToString() + " ');", true);
                }
                catch (Exception)
                {

                    // throw;
                }
            }
            else if (e.CommandName == "Approvel")
            {
                try
                {
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Active = 2;
                    obj.Passno = Convert.ToInt64(e.CommandArgument);
                    int i = bal.sendforApprovel(obj);
                    if (i == 202)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass Send For Approval');window.location ='#';", true);
                        displayPassForApprovel();
                    }
                    else
                    {
                    }
                }
                catch (Exception)
                {

                    // throw;
                }

            }

            else if (e.CommandName == "Receipt")
            {
                try
                {
                    ViewState["k"] = 202;
                    popup();
                }
                catch (Exception)
                {

                    // throw;
                }
            }
            else if (e.CommandName == "delete")
            {
                try
                {
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Passno = Convert.ToInt64(e.CommandArgument);
                    int i = bal.deletepass(obj);
                    if (i == 202)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass Delete Successfully...');window.location ='#';", true);
                        displayPassForApprovel();
                    }
                }
                catch (Exception)
                {

                    //throw;
                }

            }
            else if (e.CommandName == "doc")
            {
                try
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
                catch (Exception)
                {

                    throw;
                }
            }
            else if (e.CommandName == "bcas")
            {
                try
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
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                Session["receipt"] = 202;
                ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "SelectName('" + e.CommandArgument + " ');", true);
            }

        }
        public void popup()
        {
            mask.Visible = true;
            pnlAllUsers.Enabled = false;
            rbcheque.Checked = false;
            rbCash.Checked = true;
            pnlcheque.Visible = false;
        }

        protected void rptforPassapprovel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            try
            {
                Label active = (Label)e.Item.FindControl("lblactive");
                LinkButton edit = (LinkButton)e.Item.FindControl("linkEdit");
                LinkButton approvel = (LinkButton)e.Item.FindControl("linkapprovel");
                LinkButton print = (LinkButton)e.Item.FindControl("linkprint");
                LinkButton receipt = (LinkButton)e.Item.FindControl("linkreceipt");
                Label receiptno = (Label)e.Item.FindControl("lblReceiptNo");
                LinkButton linkreceiptno = (LinkButton)e.Item.FindControl("linkreceiptno");
                LinkButton del = (LinkButton)e.Item.FindControl("linkdelete");
                CheckBox cbcheck = (CheckBox)e.Item.FindControl("cbcheck");
                Label passno = (Label)e.Item.FindControl("lblpassno");
                Label reject = (Label)e.Item.FindControl("lblrejectremark");
                Label approveddate = (Label)e.Item.FindControl("lblapproveddate");
                Label status = (Label)e.Item.FindControl("lblstatus");
                Label bcasapproval = (Label)e.Item.FindControl("lblbcasapprval");
                edit.Visible = false;
                approvel.Visible = false;
                linkreceiptno.Visible = false;
                cbcheck.Visible = false;
                status.Visible = false;
                print.Visible = false;
                if (Convert.ToInt32(active.Text) == -1)
                {
                    if (rbreject.Checked == true)
                    {
                        edit.Visible = true;
                        approvel.Visible = false;
                        cbcheck.Visible = false;
                        reject.Visible = true;
                        if (Convert.ToDateTime(approveddate.Text) == Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            passno.Attributes.Add("style", "background-color:yellow;");

                        }

                    }
                }
                else if (Convert.ToInt32(active.Text) == 0)
                {
                    edit.Visible = true;
                    approvel.Visible = false;
                    cbcheck.Visible = false;
                    del.Visible = true;
                    if (rbyearlypassdetail.Checked == true)
                    {
                        edit.Visible = false;
                        del.Visible = false;
                        cbcheck.Visible = true;
                    }
                }
                else if (Convert.ToInt32(active.Text) == 1)
                {
                    edit.Visible = false;
                    approvel.Visible = true;
                    cbcheck.Visible = false;
                    if (rbyearlypassdetail.Checked == true)
                    {
                        cbcheck.Visible = true;
                        approvel.Visible = false;
                    }
                }
                else if (Convert.ToInt32(active.Text) == 2)
                {
                    edit.Visible = false;
                    approvel.Visible = true;
                    cbcheck.Visible = false;
                }
                else if (Convert.ToInt32(active.Text) == 200 || Convert.ToInt32(active.Text) == 5)
                {
                    status.Visible = true;
                    edit.Visible = false;
                    approvel.Visible = false;
                    if (rbapproved.Checked == true)
                    {
                        cbcheck.Visible = true;
                        receipt.Visible = true;
                        if (receiptno.Text != "0")
                        {
                            linkreceiptno.Visible = true;
                            print.Visible = true;
                            receipt.Visible = false;
                            if (Convert.ToBoolean(bcasapproval.Text) == true)
                            {
                                print.Visible = false;
                            }
                        }
                    }
                }
                else if (Convert.ToInt32(active.Text) >= 3)
                {
                    cbcheck.Visible = false;
                    status.Visible = true;
                }
                if (Convert.ToInt32(active.Text) == 4)
                {
                    print.Visible = true;
                }
            }
            catch (Exception)
            {

                // throw;
            }

        }
        protected void btnBillPrint_Click(object sender, EventArgs e)
        {

        }
        protected void rbUnapproved_CheckedChanged(object sender, EventArgs e)
        {
            pnlgenerateReceipt.Visible = false;
            pnlexporttoexcel.Visible = false;
            displayPassForApprovel();
        }

        protected void rbapproved_CheckedChanged(object sender, EventArgs e)
        {
            displayPassForApprovel();
            pnlgenerateReceipt.Visible = false;
            pnlexporttoexcel.Visible = false;
        }
        protected void btnReceiptno_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["k"] = 202;
                popup();
            }
            catch (Exception)
            {

                // throw;
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ViewState["k"] = 101;
            GenerateAndPrintPass();
        }
        public void GenerateAndPrintPass()
        {
            Boolean ck = false;
            string ab;
            try
            {
                if (Convert.ToInt32(ViewState["k"]) != 101)
                {
                    if (rbCash.Checked)
                    {
                        obj.Paymenttype = "Cash";
                        // obj.Chequedate = DateTime.Now.ToShortDateString();

                    }
                    else
                    {
                        if (txtChequeDate.Text == "" || txtChequeno.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Fill Cheque No. And Date...');window.location ='#';", true);
                            pnlAllUsers.Enabled = false;
                            pnlcheque.Visible = true;
                            mask.Visible = true;
                            rbcheque.Checked = true;
                            rbCash.Checked = false;
                            return;
                        }
                        else
                        {
                            obj.Paymenttype = "Cheque";
                            obj.Chequedate = txtChequeDate.Text;
                            obj.Chequeno = txtChequeno.Text;
                        }
                    }
                }
                foreach (RepeaterItem item in rptforPassapprovel.Items)
                {
                    CheckBox chkowner = (CheckBox)item.FindControl("cbcheck");
                    if (chkowner.Checked)
                    {
                        Label uniqueid = (Label)item.FindControl("lblApprove_id");
                        ab = (uniqueid.Text);
                        ViewState["aa"] = ViewState["aa"] + ab + ",";
                        ck = true;
                    }
                }

                if (ck == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Pass');window.location ='#';", true);
                    return;
                }
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                ViewState["aa"] = ViewState["aa"].ToString().Substring(0, ViewState["aa"].ToString().Length - 1);
                obj.GenerateReceipt = ViewState["aa"].ToString();
                if (Convert.ToInt32(ViewState["k"]) == 202)
                {
                    int i = bal.GenerateReceiptno(obj);
                    if (i == 202)
                    {
                        displayPassForApprovel();
                        Session["receipt"] = 202;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "SelectName('" + ViewState["aa"].ToString() + " ');", true);
                    }
                    txtChequeDate.Text = "";
                    txtChequeDate.Text = "";
                }
                else if (Convert.ToInt32(ViewState["k"]) == 101)
                {
                    Session["print"] = 303;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "SelectName('" + ViewState["aa"].ToString() + " ');", true);
                }
            }
            catch (Exception)
            {
                ViewState["aa"] = "";
                // throw;
            }
            finally
            {
                ViewState["aa"] = string.Empty;
                ViewState["k"] = 0;
                closePopup();
            }

        }
        public void closePopup()
        {
            mask.Visible = false;
            pnlAllUsers.Enabled = true;
            rbCash.Checked = true;
            pnlcheque.Visible = false;
        }
        protected void btnsumbit_Click(object sender, EventArgs e)
        {
            GenerateAndPrintPass();
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            closePopup();
        }

        protected void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            pnlcheque.Visible = false;
        }

        protected void rbcheque_CheckedChanged(object sender, EventArgs e)
        {
            pnlcheque.Visible = true;
        }

        protected void rbreject_CheckedChanged(object sender, EventArgs e)
        {
            pnlgenerateReceipt.Visible = false;
            pnlexporttoexcel.Visible = false;
            displayPassForApprovel();
        }

        protected void rbyearlypassdetail_CheckedChanged(object sender, EventArgs e)
        {
            pnlgenerateReceipt.Visible = true;
            pnlexporttoexcel.Visible = false;
            displayPassForApprovel();
        }

        protected void btnexporttoexcel_Click(object sender, EventArgs e)
        {
            try
            {
                bool ck = false;
                for (int i = 0; i < rptforPassapprovel.Items.Count; i++)
                {
                    Label refid = ((Label)rptforPassapprovel.Items[i].FindControl("lblApprove_id"));
                    CheckBox checkboc = ((CheckBox)rptforPassapprovel.Items[i].FindControl("cbcheck"));
                    if (checkboc.Checked == true)
                    {
                        ck = true;
                        selectexcel = selectexcel + refid.Text + ",";
                    }
                }
                if (ck == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Permanent AEP ');window.location ='#';", true);
                    return;
                }
                obj.Excelaepno = selectexcel.Substring(0, selectexcel.Length - 1);
                DataSet dt = bal.downloadexcel(obj);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    string filename = "AEP" + DateTime.Now.ToString("_dd/mm/yyyy_HH:mm:ss") + ".xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);

                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                selectexcel = string.Empty;
            }

        }

    }
}