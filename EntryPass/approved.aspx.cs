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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbAllpass.Checked = true;
                Page.Title = "Entry | A E P Approval";
                DisplayApprovedList();
                DisplayApproveList();
            }
        }
        public void DisplayApprovedList()
        {
            obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
            obj.Active = 22;
            //dt = bal.DisplayApprovedPass(obj);
            DataSet dt = bal.DisplayApprovePass(obj);
            if (dt.Tables[0].Rows.Count > 0)
            {
                dgvPassDetails.Visible = true;
                dgvPassDetails.DataSource = dt.Tables[0];
                dgvPassDetails.DataBind();
                //dgvPassDetails.Columns[2].Visible = false;
            }
            else
            {
                dgvPassDetails.Visible = false;
            }
        }
        public void DisplayApproveList()
        {
            btnCancelBill.Visible = true;
            btnapproveBill.Visible = true;
            if (rbAllpass.Checked == true)
            {
                obj.Action = "100";
            }
            else if (rbYearlyPass.Checked == true)
            {
                obj.Action = "200";
            }
            else if (rbissuedpass.Checked == true)
            {
                obj.Action = "333";
                btnCancelBill.Visible = false;
                btnapproveBill.Visible = false;
            }
            obj.Roleid = Convert.ToInt32(Session["RoleID"].ToString());
            obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
            obj.Active = 10;
            DataSet dt = bal.DisplayApprovePass(obj);
            if (dt.Tables[0].Rows.Count > 0)
            {
                rptpassDetails.Visible = true;
                rptpassDetails.DataSource = dt.Tables[0];
                rptpassDetails.DataBind();
            }
            else
            {
                rptpassDetails.Visible = false;
                btnCancelBill.Visible = false;
                btnapproveBill.Visible = false;
            }
        }
        protected void btnapproveBill_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = false;
            mask.Visible = true;
            ViewState["k"] = 101;

        }
        protected void btnCancelBill_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = false;
            mask.Visible = true;
            ViewState["k"] = 404;

        }
        public void passconfirmAndReject()
        {
            try
            {
                Boolean ck = false;
                for (int i = 0; i < rptpassDetails.Items.Count; i++)
                {
                    CheckBox checkboc = ((CheckBox)rptpassDetails.Items[i].FindControl("cbSelectPartName"));
                    CheckBox exemption = ((CheckBox)rptpassDetails.Items[i].FindControl("cbFeeExemption"));
                    TextBox remark = ((TextBox)rptpassDetails.Items[i].FindControl("txtremark"));
                    Label refid = ((Label)rptpassDetails.Items[i].FindControl("lblApprove_id"));
                    Label passfee = ((Label)rptpassDetails.Items[i].FindControl("lblpassfee"));
                    if (checkboc.Checked == true)
                    {
                        if (exemption.Checked)
                        {
                            if (remark.Text == String.Empty)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Fill Remark Detail');window.location ='#';", true);
                                Panel1.Enabled = true;
                                mask.Visible = false;
                                return;
                            }
                            passfee.Text = 0.ToString();

                        }
                        else
                        {
                            remark.Text = "";
                            exemption.Checked = false;
                        }
                        ck = true;
                        obj.Transactionpasswotd1 = EncodePasswordToBase64(txttranspwd.Text);
                        obj.Selectapssno = refid.Text;
                        obj.FeeExemption1 = Convert.ToBoolean(exemption.Checked);
                        obj.Selectremark = remark.Text;
                        obj.Passfee = Convert.ToDecimal(passfee.Text);
                        obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                        obj.Approveid = Convert.ToInt32(Session["id"]);
                        obj.Selectprocess = Convert.ToInt32(ViewState["k"]);
                        obj.Reject_remark = txtrejectRemark.Text;
                        ViewState["m"] = bal.Approvepass(obj);
                    }
                }
                if (ck == true)
                {
                    if (Convert.ToInt32(ViewState["m"]) == 505)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Correct Transaction Password');window.location ='#';", true);
                    }
                    else if (Convert.ToInt32(ViewState["m"]) == 202)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass Approved Successfully');window.location ='#';", true);

                    }
                    else if (Convert.ToInt32(ViewState["m"]) == 303)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass Reject Successfully');window.location ='#';", true);

                    }
                    else if (Convert.ToInt32(ViewState["m"]) == 500)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again Later..!');window.location ='#';", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Pass');window.location ='#';", true);
                }


            }
            catch (Exception)
            {

                // throw;
            }
            finally
            {
                DisplayApproveList();
                DisplayApprovedList();
                Panel1.Enabled = true;
                mask.Visible = false;
                ViewState["k"] = 0;
                ViewState["m"] = 0;
            }

        }
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        protected void cbAllPassno_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbAllPassno.Checked == true)
                {
                    for (int i = 0; i < rptpassDetails.Items.Count; i++)
                    {
                        CheckBox checkboc = ((CheckBox)rptpassDetails.Items[i].FindControl("cbSelectPartName"));
                        checkboc.Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < rptpassDetails.Items.Count; i++)
                    {
                        CheckBox checkboc = ((CheckBox)rptpassDetails.Items[i].FindControl("cbSelectPartName"));
                        checkboc.Checked = false;
                    }
                }
            }
            catch
            {
                // throw;
            }
            finally
            {
            }
        }

        protected void btncloseapprovepop_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = true;
            mask.Visible = false;
            ViewState["k"] = 0;
        }

        protected void btnapprovePass_Click(object sender, EventArgs e)
        {

            passconfirmAndReject();
        }

        protected void rptpassDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View")
                {
                    Session["approved"] = Convert.ToInt64(e.CommandArgument);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "openInNewTab('entrypass.aspx')", true);

                }
                else if (e.CommandName == "issuepass")
                {
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Passno = Convert.ToInt64(e.CommandArgument);
                    int i = bal.passissue(obj);
                    if (i == 101)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('AEP Issue Update Successfully');window.location ='#';", true);
                        DisplayApproveList();
                        DisplayApprovedList();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again Later');window.location ='#';", true);
                    }
                }
                else if (e.CommandName == "doc")
                {
                    string path = "Doc" + e.CommandArgument + ".pdf";
                    FileInfo file2 = new FileInfo(Server.MapPath("Physical//" + path));
                    if (file2.Exists)
                    {
                        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + path);
                        //Response.TransmitFile(Server.MapPath("Physical//" + path));
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "openInNewTab('Physical/'" + path + ")", true);

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
                        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + path);
                        //Response.TransmitFile(Server.MapPath("Physical//" + path));
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "openInNewTab('Physical/'" + path + ")", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('File Not Found');window.location ='#';", true);
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void rptpassDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            try
            {
                CheckBox remark = e.Item.FindControl("cbFeeExemption") as CheckBox;
                TextBox remarkDetails = e.Item.FindControl("txtremark") as TextBox;
                LinkButton view = e.Item.FindControl("LinkButton1") as LinkButton;
                LinkButton issuepass = e.Item.FindControl("linkissuepass") as LinkButton;
                Label from = e.Item.FindControl("lblpassfrom") as Label;
                Label to = e.Item.FindControl("lblpassto") as Label;
                int day = Convert.ToInt32((Convert.ToDateTime(to.Text) - Convert.ToDateTime(from.Text)).TotalDays);
                if (remark.Checked)
                {
                    remarkDetails.Visible = true;
                }
                else
                {
                    remarkDetails.Visible = false;
                }
                if (day > 90)
                {
                    remark.Visible = false;
                    view.Visible = false;
                    remarkDetails.Visible = false;
                }
                if (rbissuedpass.Checked == true)
                {
                    issuepass.Visible = true;
                    view.Visible = false;
                    remark.Visible = false;
                }
                else
                {
                    issuepass.Visible = false;
                    view.Visible = true;
                }
            }
            catch (Exception)
            {

                // throw;
            }

        }

        protected void GDVPassDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(dgvPassDetails, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
                    // when mouse leaves the row, change the bg color to its original value   
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                }
            }
            catch (Exception)
            {

                // throw;
            }

        }

        protected void GDVPassDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["print"] = 303;
            ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "SelectName('" + dgvPassDetails.SelectedRow.Cells[0].Text + " ');", true);
        }

        protected void cbFeeExemption_CheckedChanged(object sender, EventArgs e)
        {
            //Control header_control = rptpassDetails.Controls[0].Controls[0];   // Find header Template's Items

            try
            {
                foreach (RepeaterItem item in rptpassDetails.Items)
                {
                    CheckBox remark = item.FindControl("cbFeeExemption") as CheckBox;
                    TextBox remarkdetail = item.FindControl("txtremark") as TextBox;
                    if (remark.Checked)
                    {
                        remarkdetail.Visible = true;
                    }
                    else
                    {
                        remarkdetail.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

                // throw;
            }

        }

        protected void rbAllpass_CheckedChanged(object sender, EventArgs e)
        {
            DisplayApproveList();
        }

        protected void rbYearlyPass_CheckedChanged(object sender, EventArgs e)
        {
            DisplayApproveList();
        }

        protected void rbissuedpass_CheckedChanged(object sender, EventArgs e)
        {
            DisplayApproveList();
        }
    }
}