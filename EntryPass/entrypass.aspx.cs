using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Layer;
using Business_ObjectLayer;
using System.IO;
using System.Data;
using System.Drawing;
using System.Net;
using System.Collections;

namespace AirportAuthoritiesUI
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            btninsertPass.Visible = true;
            btnforapprove.Visible = true;
            Page.Title = "Entry | A E P Pass Registration";
            if (Session["uniqueid"] != null || Session["approved"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.UrlReferrer != null)
                    ViewState["url"] = Request.UrlReferrer.ToString();
                    fillDropdown();
                    updatepassdetail();                 
                }
                Session["uniqueid"] = null;
                Session["approved"] = null;
            }
            else
            {
                if (!IsPostBack)
                {
                    fillDropdown();
                    selectagency();
                    sign.ImageUrl = "applicant/signature.jpg";
                    pic.ImageUrl = "applicant/photo.png";  
                }
            }
    
        }

        public void updatepassdetail()
        {
            try
            {
                if (Session["uniqueid"] != null)
                {
                   // btnclear.Text = "Back";
                    btninsertPass.Text = "Update";
                    btnforapprove.Text = "Update & Send For approve";
                    obj.Oldpassno = Convert.ToInt64(Session["uniqueid"].ToString());
                    //Session["uniqueid"] = null;
                }
               else if (Session["approved"] != null)
                {
                    btnclear.Text = "Back";
                    btninsertPass.Visible = false;
                    btnforapprove.Visible = false;
                    obj.Oldpassno = Convert.ToInt64(Session["approved"].ToString());
                }
                else
                {
                   
                }
          
             DataSet dt = bal.ShowSelectOldpassDetail(obj);
            if (dt.Tables[0].Rows.Count > 0)
            {
                
               // pnloldpass.Visible = true;
                ViewState["id"] = dt.Tables[0].Rows[0]["id"].ToString();
                txtRemark.Text = dt.Tables[0].Rows[0]["remark_detail"].ToString();
                cbRemark.Checked =Convert.ToBoolean(dt.Tables[0].Rows[0]["remark"].ToString());
               // lblamount.Text = dt.Tables[0].Rows[0]["passfee"].ToString();
                txtpassno.Text = dt.Tables[0].Rows[0]["uniqueid"].ToString();
                ddlagency.SelectedValue = dt.Tables[0].Rows[0]["agency"].ToString();
                selectagency();
                ddlagencylist.SelectedValue = dt.Tables[0].Rows[0]["nameofagency"].ToString();
                txtAddress.Text = dt.Tables[0].Rows[0]["address"].ToString();
                txtApplicantName.Text = dt.Tables[0].Rows[0]["applicantname"].ToString();
                txtBirthdate.Text = dt.Tables[0].Rows[0]["dob"].ToString();
                pic.ImageUrl = "~/Applicant/" + dt.Tables[0].Rows[0]["photo"].ToString();
                sign.ImageUrl = "~/Applicant/" + dt.Tables[0].Rows[0]["sign"].ToString();
               ViewState["photo"] = dt.Tables[0].Rows[0]["photo"].ToString();
               ViewState["sign1"] = dt.Tables[0].Rows[0]["sign"].ToString();
                ddlPass.SelectedIndex = 1;
                cbselfesct.Checked =Convert.ToBoolean(dt.Tables[0].Rows[0]["selfesct"].ToString());
                txtapplicantmobile.Text = dt.Tables[0].Rows[0]["applicantmobile"].ToString();
               ViewState["doc"] = dt.Tables[0].Rows[0]["policeverificationdocument"].ToString();
                txtDesignation.Text = dt.Tables[0].Rows[0]["designation"].ToString();
                txtNameAsPerPoliceVerification.Text = dt.Tables[0].Rows[0]["policeverificationname"].ToString();
                txtPoliceVerificationdate.Text = dt.Tables[0].Rows[0]["policeverficationdate"].ToString();
                txtPresentAddress.Text = dt.Tables[0].Rows[0]["presentaddress"].ToString();
                txtPurpaseOfvisit.Text = dt.Tables[0].Rows[0]["purposeofvisit"].ToString();
                txtSon.Text = dt.Tables[0].Rows[0]["wife"].ToString();
                txtValidFromDateTime.Text = dt.Tables[0].Rows[0]["periodfrom"].ToString();
                txtValidToDateTime.Text = dt.Tables[0].Rows[0]["periodto"].ToString();
              
                ddlAirport.SelectedValue = dt.Tables[0].Rows[0]["airport"].ToString();
                ddlPassType.SelectedValue = dt.Tables[0].Rows[0]["passtype"].ToString();
                if (dt.Tables[0].Rows[0]["policevarificationtype"].ToString() != "0")
                {
                    ddlPoliceVerificationType.SelectedValue = dt.Tables[0].Rows[0]["policevarificationtype"].ToString();
                }
                ddlTerminals.SelectedValue = dt.Tables[0].Rows[0]["terminal"].ToString();
                string[] words = dt.Tables[0].Rows[0]["areazones"].ToString().Split(',');
                txt.Text= dt.Tables[0].Rows[0]["esct_by_passno"].ToString();
                txt.Enabled = false;
                TextBox1.Text = dt.Tables[0].Rows[0]["esctbyname"].ToString();
                txtidentityname.Text = dt.Tables[0].Rows[0]["identityproofname"].ToString();
                txtidentityno.Text = dt.Tables[0].Rows[0]["identityproofNo"].ToString();
                ckbcas.Checked = Convert.ToBoolean(dt.Tables[0].Rows[0]["bcasapproval"].ToString());
                    foreach (string word in words)
                    {
                        foreach (GridViewRow row in DGVareazone.Rows)
                        {
                            if (word == row.Cells[1].Text)
                            {
                                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                                chkRow.Checked = true;
                            }
                        }
                    }
                    days();
                    setpassfee();
                    verification();
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
        protected void btninsertPass_Click(object sender, EventArgs e)
        {
            entrypassform();
        }
        public void entrypassform()
        {
            try
            {
           if (txtAddress.Text == "" )
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Applicant Address..!!');window.location ='#';", true);
               txtAddress.Focus();
               txtAddress.Attributes.Add("style", "border-color:red;");
           }
          else if(txtApplicantName.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Applicant Name..!!');window.location ='#';", true);
               txtApplicantName.Focus();
           }
         else if(txtBirthdate.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Applicant DOB..!!');window.location ='#';", true);
               txtBirthdate.Focus();
           }
         else if(txtDesignation.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Designation..!!');window.location ='#';", true);
               txtDesignation.Focus();
           }
         else if(txtPresentAddress.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Can not Black Applicant Present Address..!!');window.location ='#';", true);
               txtPresentAddress.Focus();
           }
         else if(txtPurpaseOfvisit.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Purpase Of Visit..!!');window.location ='#';", true);
               txtPurpaseOfvisit.Focus();
           }
         else if(txtSon.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Mother's Name of Applicant..!!');window.location ='#';", true);
               txtSon.Focus();
           }
           else if (txtapplicantmobile.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Applicant Mobile No..!!');window.location ='#';", true);
               txtapplicantmobile.Focus();
           }
         else if(txtValidFromDateTime.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Pass From Valid Date..!!');window.location ='#';", true);
               txtValidFromDateTime.Focus();
           }
         else if(txtValidToDateTime.Text == "")
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Pass To Valid Date..!!');window.location ='#';", true);
               txtValidToDateTime.Focus();
           }
           else if (ddlagencylist.SelectedIndex < 1)
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Org. Name..!!');window.location ='#';", true);
               ddlagencylist.Focus();
               ddlagencylist.Attributes.Add("style", "background-color:red;");
           }
           else if (ddlagency.SelectedIndex < 1)
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Org. Type..!!');window.location ='#';", true);
               ddlagency.Focus();
               ddlagency.Attributes.Add("style", "background-color:red;");
           }
           else if (ddlTerminals.SelectedIndex < 1)
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Access Building/s..!!');window.location ='#';", true);
               ddlTerminals.Focus();
           }
           else if (ddlPassType.SelectedIndex < 1)
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select Pass Type..!!');window.location ='#';", true);
               ddlPassType.Focus();
           }
           else if (ddlAirport.SelectedIndex < 1)
           {
               ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Area/s..!!');window.location ='#';", true);
               ddlAirport.Focus();
           }
        else
        {
                 
        if (Convert.ToDateTime(txtValidFromDateTime.Text) > Convert.ToDateTime(txtValidToDateTime.Text))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Correct Date/s ..!!');window.location ='#';", true);
            txtValidToDateTime.Focus();
            return;
        }
        else if(  Convert.ToDateTime(DateTime.Now.ToShortDateString()) > Convert.ToDateTime(txtValidFromDateTime.Text))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Correct Date/s..!!');window.location ='#';", true);
            txtValidFromDateTime.Focus();
            return;
        }
        else if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) > Convert.ToDateTime(txtValidToDateTime.Text))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Correct Date/s ..!!');window.location ='#';", true);
            txtValidToDateTime.Focus();
            return;
        }
        if (pnlverification.Visible == true)
            {
            if (txtNameAsPerPoliceVerification.Text == "")    
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Name As Per Verification Documents ....!!');window.location ='#';", true);
                txtNameAsPerPoliceVerification.Focus();
                return;
            }
            else if(txtPoliceVerificationdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Date of Verification Documents...!!');window.location ='#';", true);
                txtPoliceVerificationdate.Focus();
                return;
            }
            else if (ddlPoliceVerificationType.SelectedIndex < 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Police Verification Type...!!');window.location ='#';", true);
                ddlPoliceVerificationType.Focus();
                return;
            }
            else if (txtidentityname.Text== "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Identity Proof Document Name...!!');window.location ='#';", true);
                txtidentityname.Focus();
                return;
            }
            else if (txtidentityno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Number of Indentity Proof Document...!!');window.location ='#';", true);
                txtidentityno.Focus();
                return;
            }
            DateTime date = Convert.ToDateTime(txtPoliceVerificationdate.Text).AddDays(Convert.ToInt32(ViewState["varificationdays"].ToString()));
            if (Convert.ToDateTime(txtPoliceVerificationdate.Text) > Convert.ToDateTime(txtValidFromDateTime.Text) || date < Convert.ToDateTime(txtValidToDateTime.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass valid Date can not be Before of  Varification date ....!!');window.location ='#';", true);
                return;
            }
           // obj.Policeverficationdate = Convert.ToDateTime(txtPoliceVerificationdate.Text);
            obj.Policeverficationdate = txtPoliceVerificationdate.Text;
            obj.Policevarificationtype = Convert.ToInt32(ddlPoliceVerificationType.SelectedValue);
            obj.Identityproofno = txtidentityno.Text;
            obj.Identityproofname = txtidentityname.Text;
        }
        else
        {
            if (ddlPassType.SelectedIndex == 1)
            {
                double i = (Convert.ToDateTime((txtValidToDateTime.Text)) - Convert.ToDateTime((txtValidFromDateTime.Text))).TotalDays;
                if (i >= 3)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass Valid Days Can not used after select Pass Type Days...!!');window.location ='#';", true);
                    return;
                }
            }
            if(cbselfesct.Checked!=true)
            {
            if (txt.Text == "" || TextBox1.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Esct Pass No & Holder Name cannot Black...!!');window.location ='#';", true);
                return;
            }
            }
            obj.Selfesct = cbselfesct.Checked;
        }
             setpassfee();
                    if (cbRemark.Checked == true)
                    {
                        if (txtRemark.Text != "")
                        {
                            obj.RemarkDetail1 = txtRemark.Text;
                            obj.Remark = true;                       
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Fill Remark ..!!');window.location ='#';", true);
                            txtRemark.Focus();
                            return;
                        }
                    }
                    else
                    {
                        obj.Remark = false;
                    }
                    if (Convert.ToInt32(ViewState["approve"])== 202)
                    {
                        obj.Active=1;
                    }
                    else
                    {
                        obj.Active=0;
                    }
                    if (btninsertPass.Text != "Update" || btnforapprove.Text != "Update & Send For approval")
                    {
                        obj.Passno = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssf"));
                    }
                    obj.PassAmount =Convert.ToDecimal(ViewState["passamount"]);
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Address = txtAddress.Text;
                    obj.Applicantname = txtApplicantName.Text;
                    obj.Dob = Convert.ToDateTime(txtBirthdate.Text);
                    obj.Designation = txtDesignation.Text;
                    obj.Policeverificationname = txtNameAsPerPoliceVerification.Text;                 
                    obj.Presentaddress = txtPresentAddress.Text;
                    obj.Purposeofvisit = txtPurpaseOfvisit.Text;
                    obj.Wife = txtSon.Text;
                    obj.Applicantmobile = txtapplicantmobile.Text;
                    obj.Periodfrom = Convert.ToDateTime(txtValidFromDateTime.Text);
                    obj.Periodto = Convert.ToDateTime(txtValidToDateTime.Text);
                    obj.Agency = Convert.ToInt32(ddlagency.SelectedValue);
                    obj.Airport = Convert.ToInt32(ddlAirport.SelectedValue);
                    obj.Oldpassrenew = Convert.ToInt32(ddlPass.SelectedValue);
                    obj.Passtype = Convert.ToInt32(ddlPassType.SelectedValue);
                    obj.Bcasapproval = Convert.ToBoolean(ckbcas.Checked);
                    obj.Terminal = Convert.ToInt32(ddlTerminals.SelectedValue);
                    obj.NameofAgency1 = ddlagencylist.SelectedValue;
                    List<string> list = new List<string>();
                    ViewState["aa"] = "";
                    bool ck = false;
                    foreach (GridViewRow row in DGVareazone.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {
                                ViewState["aa"] = ViewState["aa"] + row.Cells[1].Text + ",";
                                ck = true;
                            }
                        }
                    }
                    if (ck == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Area Zone..!!');window.location ='#';", true);
                        return;
                    }
                    if (!string.IsNullOrEmpty(ViewState["aa"].ToString()))
                        ViewState["aa"] = ViewState["aa"].ToString().Remove(ViewState["aa"].ToString().Length - 1, 1);
                    obj.Areazones = ViewState["aa"].ToString();
                    if (ddlPass.SelectedIndex == 0)
                    {
                        if (fuPhotoPath.HasFile )
                        {
                            obj.Photo = "Photo" + obj.Passno + Path.GetExtension(fuPhotoPath.PostedFile.FileName);
                            string path = Server.MapPath("Applicant//" + obj.Photo);
                            FileInfo file = new FileInfo(path);
                            if (file.Exists)
                            {
                                file.Delete();
                                fuPhotoPath.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Photo);
                            }
                            else
                            {
                                fuPhotoPath.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Photo);
                            }
                           
                        }
                        else if (Session["CapturedImage"] != null)
                        {
                            string myFilePath = Session["CapturedImage"].ToString();
                            string filename = Path.GetFileName(myFilePath);
                            obj.Photo = filename;
                            Session["CapturedImage"] = null;
                            //if (fuSign.HasFile)
                            //{
                            //    obj.Sign = "Sign" + obj.Passno + Path.GetExtension(fuSign.PostedFile.FileName);
                            //    string path1 = Server.MapPath("Applicant//" + obj.Sign);
                            //    FileInfo file1 = new FileInfo(path1);
                            //    if (file1.Exists)
                            //    {
                            //        file1.Delete();
                            //        fuSign.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Sign);
                            //    }
                            //    else
                            //    {
                            //        fuSign.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Sign);
                            //    }
                            //}
                            //else
                            //{
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Add Applicant Sign....!!!');window.location ='#';", true);
                            //    fuSign.Focus();
                            //    return;
                            //}
                        }
                       
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Add Applicant Photo....!!!');window.location ='#';", true);
                            fuPhotoPath.Focus();
                            return;
                        }
                        if(fuSign.HasFile)
                        {
                             obj.Sign = "Sign" + obj.Passno + Path.GetExtension(fuSign.PostedFile.FileName);
                            string path1 = Server.MapPath("Applicant//" + obj.Sign);
                            FileInfo file1 = new FileInfo(path1);
                            if (file1.Exists)
                            {
                                file1.Delete();
                                fuSign.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Sign);
                            }
                            else
                            {
                                fuSign.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Sign);
                            }
                        }
                        if (pnlverification.Visible == true)
                        {
                            if (fuDocument.HasFile)
                            {
                                obj.Policeverificationdocument = "Doc" + obj.Passno + Path.GetExtension(fuDocument.PostedFile.FileName);
                                string path2 = Server.MapPath("Physical//" + obj.Policeverificationdocument);
                                FileInfo file2 = new FileInfo(path2);
                                if (file2.Exists)
                                {
                                    file2.Delete();
                                    fuDocument.SaveAs(Server.MapPath("Physical/") + "/" + obj.Policeverificationdocument);
                                }
                                else
                                {
                                    fuDocument.SaveAs(Server.MapPath("Physical/") + "/" + obj.Policeverificationdocument);
                                }
                            }
                            else
                            {
                                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Add Applicant Document....!!!');window.location ='#';", true);
                                //fuPhotoPath.Focus();
                                //return;
                            }
                        }
                        else if(pnl.Visible==true)
                        {
                            obj.Esctpassno1 = txt.Text;
                        }

                    }
                    else
                    {
                        obj.Oldpassno = Convert.ToInt64(txtpassno.Text);
                        if (fuPhotoPath.HasFile)
                        {
                            obj.Photo = "Photo" + obj.Oldpassno + Path.GetExtension(fuPhotoPath.PostedFile.FileName);
                            string path = Server.MapPath("Applicant//" + obj.Photo);
                            FileInfo file = new FileInfo(path);
                            if (file.Exists)
                            {
                                file.Delete();
                                fuPhotoPath.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Photo);
                            }
                            else
                            {
                                fuPhotoPath.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Photo);
                            }
                        }
                        else
                        {
                            obj.Photo = ViewState["photo"].ToString();
                        }
                        if (fuSign.HasFile)
                        {
                            obj.Sign = "Sign" + obj.Oldpassno + Path.GetExtension(fuSign.PostedFile.FileName);
                            string path1 = Server.MapPath("Applicant//" + obj.Sign);
                            FileInfo file1 = new FileInfo(path1);
                            if (file1.Exists)
                            {
                                file1.Delete();
                                fuSign.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Sign);
                            }
                            else
                            {
                                fuSign.SaveAs(Server.MapPath("Applicant/") + "/" + obj.Sign);
                            }
                        }
                        else
                        {
                            obj.Sign = ViewState["sign1"].ToString();
                        }
                        if (pnlverification.Visible == true)
                        {
                            if (fuDocument.HasFile)
                            {
                                obj.Policeverificationdocument = "Doc" + obj.Oldpassno + Path.GetExtension(fuDocument.PostedFile.FileName);
                                string path2 = Server.MapPath("Physical//" + obj.Policeverificationdocument);
                                FileInfo file2 = new FileInfo(path2);
                                if (file2.Exists)
                                {
                                    file2.Delete();
                                    fuDocument.SaveAs(Server.MapPath("Physical/") + "/" + obj.Policeverificationdocument);
                                }
                                else
                                {
                                    fuDocument.SaveAs(Server.MapPath("Physical/") + "/" + obj.Policeverificationdocument);
                                }
                            }
                            else
                            {
                                obj.Policeverificationdocument = ViewState["doc"].ToString();
                            }
                        }
                    }
                    if (btninsertPass.Text == "Update")
                    {
                        obj.Passno = Convert.ToInt64(txtpassno.Text);
                        int i = bal.Updatepass(obj);
                        if (i == 202)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass Updated Successfully....!!!');window.location ='" + ViewState["url"].ToString()+"';", true);
                            clear();
                            btninsertPass.Text = "Save";
                            btnforapprove.Text = "Save & Send For approve";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again....!!!');window.location ='#';", true);
                        }
                    }
                    else
                    {
                       
                        int i = bal.insertnewpass(obj);
                        if (i == 202)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Pass Created Successfully....!!!');window.location ='#';", true);
                            clear();
                        }
                        if (i == 203)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Applicant Pass Already Exists....!!!');window.location ='#';", true);
                            return;
                           // clear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again....!!!');window.location ='#';", true);
                        }
                    }

                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('All Field Required....!!!');window.location ='#';", true);
                //}
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again....!!!');window.location ='#';", true);
                // throw;
            }
          
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {

            clear();
        }

        public void clear()
        {
            try
            {
                if (btnclear.Text == "Back")
                {
                    if (!string.IsNullOrEmpty(ViewState["url"].ToString()))
                    Response.Redirect(ViewState["url"].ToString());
                    btninsertPass.Visible = true;
                    btnforapprove.Visible = true;
                    btnclear.Text = "Clear";
                }
                txtidentityname.Text = string.Empty;
                txtidentityno.Text = string.Empty;
                ckbcas.Checked = false;
                txt.Enabled = true;
                ddlagencylist.SelectedIndex = 0;
                txtmobile.Text = null;
                cbRemark.Checked = false;
                ViewState["passamount"] = 0;
                ViewState["varificationdays"] = 0;
                txtAddress.Text = "";
                txtApplicantName.Text = "";
                txtBirthdate.Text = "";
                txtDesignation.Text = "";
                txtNameAsPerPoliceVerification.Text = "";
                txtPoliceVerificationdate.Text = "";
                txtPresentAddress.Text = "";
                txtPurpaseOfvisit.Text = "";
                txtSon.Text = "";
                txtRemark.Text = "";
                txtValidFromDateTime.Text = "";
                txtValidToDateTime.Text = "";
                ddlagency.SelectedIndex = 0;
                ddlAirport.SelectedIndex = 0;
                ddlPass.SelectedIndex = 0;
                ddlPassType.SelectedIndex = 0;
                ViewState["approve"] = 0;
                txt.Text = "";
                TextBox1.Text = "";
                lblamount.Text = 0.ToString();
                ddlPoliceVerificationType.SelectedIndex = 0;
                ddlTerminals.SelectedIndex = 0;
                sign.ImageUrl = "applicant/signature.jpg";
                pic.ImageUrl = "applicant/photo.png";
                btninsertPass.Text = "Save";
                btnforapprove.Text = "Save & Send For approve";
                cbSameaddress.Checked = false;
                foreach (GridViewRow row in DGVareazone.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        chkRow.Checked = false;
                    }

                }
                pnloldpass.Visible = false;
            }
            catch (Exception)
            {
                
               // throw;
            }
           
        }

        public void fillDropdown()
        {
            try
            {
                obj.Pathurl = Path.GetFileName(Request.Path);
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                obj.DdlControlName = "ddlAirport";
                DataSet ds = bal.displayddl(obj);
                ddlAirport.DataSource = ds;
                ddlAirport.DataTextField = ds.Tables[0].Columns["Name"].Caption;
                ddlAirport.DataValueField = ds.Tables[0].Columns["RecordValueInt"].Caption;
                ddlAirport.DataBind();
                ddlAirport.Items.Insert(0, "---Please Select Access Building ---");

                obj.DdlControlName = "ddlPassType";
                DataSet ds1 = bal.displayddl(obj);
                ddlPassType.DataSource = ds1;
                ddlPassType.DataTextField = ds1.Tables[0].Columns["Name"].Caption;
                ddlPassType.DataValueField = ds1.Tables[0].Columns["RecordValueInt"].Caption;
                ddlPassType.DataBind();
                ddlPassType.Items.Insert(0, "---Please Select Pass ---");


                obj.DdlControlName = "ddlagency";
                DataSet ds6 = bal.displayddl(obj);
                ddlagency.DataSource = ds6;
                ddlagency.DataTextField = ds6.Tables[0].Columns["Name"].Caption;
                ddlagency.DataValueField = ds6.Tables[0].Columns["RecordValueInt"].Caption;
                ddlagency.DataBind();
                ddlagency.Items.Insert(0, "---Select Organization Type ---");


                obj.DdlControlName = "ddlPoliceVerificationType";
                DataSet ds2 = bal.displayddl(obj);
                ddlPoliceVerificationType.DataSource = ds2;
                ddlPoliceVerificationType.DataTextField = ds2.Tables[0].Columns["Name"].Caption;
                ddlPoliceVerificationType.DataValueField = ds2.Tables[0].Columns["RecordValueInt"].Caption;
                ddlPoliceVerificationType.DataBind();
                ddlPoliceVerificationType.Items.Insert(0, "---Please Select ---");


                obj.DdlControlName = "ddlTerminals";
                DataSet ds3 = bal.displayddl(obj);
                ddlTerminals.DataSource = ds3;
                ddlTerminals.DataTextField = ds3.Tables[0].Columns["Name"].Caption;
                ddlTerminals.DataValueField = ds3.Tables[0].Columns["RecordValueInt"].Caption;
                ddlTerminals.DataBind();
                ddlTerminals.Items.Insert(0, "---Please Select Access Area ---");


                obj.DdlControlName = "ddlPass";
                DataSet ds4 = bal.displayddl(obj);
                ddlPass.DataSource = ds4;
                ddlPass.DataTextField = ds4.Tables[0].Columns["Name"].Caption;
                ddlPass.DataValueField = ds4.Tables[0].Columns["RecordValueInt"].Caption;
                ddlPass.DataBind();



                obj.DdlControlName = "DGVareazone";
                DataSet ds5 = bal.displayddl(obj);
                DGVareazone.DataSource = ds5.Tables[0];

                DGVareazone.DataBind();
            }
            catch (Exception)
            {

                // throw;
            }

        }
        private void selectagency()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                if(ddlagency.SelectedIndex > 0)
                obj.Agency_Type_id = Convert.ToInt32(ddlagency.SelectedValue);
                DataSet ds = bal.selectagenytype(obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlagencylist.DataSource = ds.Tables[0];
                    ddlagencylist.DataTextField = "angency_name";
                    ddlagencylist.DataValueField= "id";
                    ddlagencylist.DataBind();
                    ddlagencylist.Items.Insert(0, "---Select Organization Name ---");
                }
                else
                {
                    ddlagencylist.DataSource = "";
                    ddlagencylist.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlesctagency.DataSource = ds.Tables[1];
                    ddlesctagency.DataTextField = "angency_name";
                    ddlesctagency.DataValueField = "id";
                    ddlesctagency.DataBind();
                    ddlesctagency.Items.Insert(0, "---Select oraganization Name ---");
                }
                else
                {
                    ddlesctagency.DataSource = "";
                    ddlesctagency.DataBind();
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtsearchdob.Text != "" | txtsearchname.Text != "" | txtOldPassNo.Text != "" | txtmobile.Text != "")
                {
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    if (txtsearchname.Text != "")
                    {
                        obj.Searchapplicantname = txtsearchname.Text;
                    }

                    if (txtsearchdob.Text != "")
                    {
                        obj.Searchdob = Convert.ToDateTime(txtsearchdob.Text);
                    }
                    else
                    {
                        obj.Searchdob = DateTime.Now;
                    }
                    if (txtOldPassNo.Text != "")
                    {
                        obj.Searcholdpassno = Convert.ToInt64(txtOldPassNo.Text);
                    }
                    if (txtmobile.Text != "")
                    {
                        obj.Searchmobile =(txtmobile.Text);
                    }
                    DataSet st = bal.searchOldPassDetail(obj);
                    if (st.Tables[0].Rows.Count > 0)
                    {
                        DGVOldPassDetails.Visible = true;
                        DGVOldPassDetails.DataSource = st.Tables[0];
                        DGVOldPassDetails.DataBind();
                    }
                    else
                    {
                        lblmessage.Text = "No Record Found";
                        DGVOldPassDetails.Visible = false;
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again....!!!');window.location ='#';", true);
                }
            }
            catch (Exception)
            {
                
               // throw;
            }
           
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            pnlMain.Enabled = true;
            pnlpopup.Visible = false;
            pnlesct.Visible = false;
            pnlMain.Attributes.CssStyle.Add("opacity", "1");
            ddlPass.SelectedIndex = 0;
        }

        protected void ddlPass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPass.SelectedIndex != 0)
            {
                pnlMain.Enabled = false;
                pnlpopup.Visible = true;
                pnlMain.Attributes.CssStyle.Add("opacity", "0.2");
                txtOldPassNo.Text = "";
                txtsearchdob.Text="";
                txtsearchname.Text="";
                DGVOldPassDetails.Visible=false;
                // divi.Attributes.CssStyle.Add("opacity", "0.5");
               // btninsertPass.Text = "Update Pass";
            }
            else
            {
                clear();
               // btninsertPass.Text = "Generate Pass";
            }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            pnlesct.Visible = false;
            pnlMain.Enabled = true;
            pnlpopup.Visible = false;
            pnlMain.Attributes.CssStyle.Add("opacity", "1");
            ddlPass.SelectedIndex = 0;
        }

        protected void DGVOldPassDetails_SelectedIndexChanged(object sender, EventArgs e)
        { 
         
        }

        protected void DGVOldPassDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                pnlMain.Enabled = true;
                pnlpopup.Visible = false;
                pnlMain.Attributes.CssStyle.Add("opacity", "1");
                obj.Oldpassno = 0;
                GridViewRow row = DGVOldPassDetails.Rows[e.NewSelectedIndex];
                obj.Oldpassno  = Convert.ToInt64(row.Cells[1].Text);
                updatepassdetail();

            }
            catch (Exception)
            {
                
               // throw;
            }
        }

        protected void DGVOldPassDetails_DataBound(object sender, EventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DGVOldPassDetails, "Select$" + e.Row.RowIndex);
            //    e.Row.ToolTip = "Click to select this row.";
            //}
          
        }

        protected void ddlagency_TextChanged(object sender, EventArgs e)
        {
            setpassfee();
            if(ddlagency.SelectedIndex>0)
            selectagency();
        }
        public void setpassfee()
        {
            try
            {
                 if (ddlPassType.SelectedIndex != 0)
            {
                
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Selectagency = Convert.ToInt32(ddlPassType.SelectedValue);
                    DataSet dt = bal.fetchpassamount(obj);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        if (ddlagency.SelectedIndex != 0)
                        {
                            if (Convert.ToInt32(ddlagency.SelectedValue) == 88 || cbRemark.Checked == true)
                            {
                                lblamount.Text = 0.00.ToString();
                                ViewState["passamount"] = 0;
                            }
                            else
                            {
                               ViewState["passmaxdays"] = Convert.ToDecimal(dt.Tables[0].Rows[0]["days"].ToString());
                                lblamount.Text = dt.Tables[0].Rows[0]["value"].ToString();
                                ViewState["passamount"] = Convert.ToDecimal(dt.Tables[0].Rows[0]["value"].ToString());
                            }
                        }
                        else
                        {
                            ViewState["passmaxdays"] = Convert.ToDecimal(dt.Tables[0].Rows[0]["days"].ToString());
                            lblamount.Text = dt.Tables[0].Rows[0]["value"].ToString();
                            ViewState["passamount"] = Convert.ToDecimal(dt.Tables[0].Rows[0]["value"].ToString());
                        }
                    }
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Pass Type...!!!');window.location ='#';", true);
                ddlagency.SelectedIndex = 0;
            }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        protected void btnforapprove_Click(object sender, EventArgs e)
        {
            ViewState["approve"] = 202;
            entrypassform();
        }

        protected void cbRemark_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRemark.Checked == true)
            {
                lblamount.Text = 0.00.ToString();
                ViewState["passamount"] = 0;
            }
            else
            {
                setpassfee();
            }
        }

        protected void ddlPoliceVerificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            days();
            txtNameAsPerPoliceVerification.Text = txtApplicantName.Text;
        }
        public void days()
        {
            try
            {
                if (ddlPoliceVerificationType.SelectedIndex != 0)
                {
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Verificationdays = Convert.ToInt32(ddlPoliceVerificationType.SelectedValue);
                    DataSet st = bal.fetchvarificationday(obj);
                    if (st.Tables[0].Rows.Count > 0)
                    {
                        ViewState["varificationdays"] = Convert.ToInt32(st.Tables[0].Rows[0]["verificationValidityDays"].ToString());
                    }
                }
            }
            catch (Exception)
            {

                // throw;
            }   
        }

        protected void cbSameaddress_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSameaddress.Checked)
                {
                    if (txtAddress.Text != "")
                    {
                        txtPresentAddress.Text = txtAddress.Text;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Fill Address...!!!');window.location ='#';", true);
                        cbSameaddress.Checked = false;
                    }
                }
                else
                {
                    txtPresentAddress.Text = "";
                    
                }
               
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }
        protected void DGVOldPassDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DGVOldPassDetails, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
                    // when mouse leaves the row, change the bg color to its original value   
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlPassType_TextChanged(object sender, EventArgs e)
        {
            setpassfee();
            verification();
        }
        public void verification()
        {
            try
            {
                 if (ddlPassType.SelectedValue == "64" || ddlPassType.SelectedValue == "102")
            {
                pnl.Visible = true;
                pnlverification.Visible = false;
            }
            else
            {
                pnlverification.Visible = true;
                pnl.Visible = false;
            }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        protected void btncheck_Click(object sender, EventArgs e)
        {
            passvalid();
        }

        public void passvalid()
        {
            try
            {
                if (txt.Text != "")
                {
                    obj.Checkpass = txt.Text;
                    DataSet st = bal.checkpassvalid(obj);
                    if (st.Tables[0].Rows.Count > 0)
                    {
                        TextBox1.Text = st.Tables[0].Rows[0]["applicantname"].ToString();
                        txt.Enabled = false;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert(' Record Not Found...!!!');window.location ='#';", true);
                        txt.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Pass No...!!!');window.location ='#';", true);
                }

            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                txt.Text = "";
                txt.Enabled = true;
                TextBox1.Text = "";
            }
            catch (Exception)
            {
                
               // throw;
            }
        }

        protected void btnaddesct_Click(object sender, EventArgs e)
        {
            pnlesct.Visible = true;
            pnlMain.Enabled = false;
            pnlMain.Attributes.CssStyle.Add("opacity", "0.2");
           // UpdatePanel4.Update();
        }

        protected void btninsertEsctby_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlesctagency.SelectedIndex<1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert(' Please Enter Organization Name...!!!');window.location ='#';", true);
                ddlesctagency.Focus();
            }
            else if(txtesctapplicantname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert(' Please Enter Applicant Name...!!!');window.location ='#';", true);
                txtesctapplicantname.Focus();
            }
            else if(txtesctdob.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Dob...!!!');window.location ='#';", true);
                txtesctdob.Focus();
            }
            else if(txtesctPassno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert(' Please Enter AEP No...!!!');window.location ='#';", true);
                txtesctPassno.Focus();
            }
            else if (txtEsctpassFromdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Pass Valid From Date...!!!');window.location ='#';", true);
                txtEsctpassFromdate.Focus();
            }
            else if (txtEsctpassTodate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Pass Valid To Date...!!!');window.location ='#';", true);
                txtEsctpassTodate.Focus();
            }
            else if (Convert.ToDateTime(txtEsctpassFromdate.Text) > Convert.ToDateTime(txtEsctpassTodate.Text))
                {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('From Date Can Not Greater Than To Date !! ')", true);
                }
            else
            {
                 double p= (Convert.ToDateTime(txtEsctpassTodate.Text) - Convert.ToDateTime(txtEsctpassFromdate.Text)).TotalDays;
                if (p < 90)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Permanent AEP Add in ESCT..!! ')", true);
                     return;
                }
                obj.Passno = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssf"));
                obj.Applicantname = txtesctapplicantname.Text;
                obj.Dob =Convert.ToDateTime( txtesctdob.Text);
                obj.NameofAgency1 = ddlesctagency.SelectedValue;
                obj.Esctpassno1 = txtesctPassno.Text;
                obj.Periodfrom = Convert.ToDateTime(txtEsctpassFromdate.Text);
                obj.Periodto = Convert.ToDateTime(txtEsctpassTodate.Text);
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                obj.Active = 1;
                int i = bal.insertnewpass(obj);
                if (i == 202)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Esct Pass Successfully Added ...!!!');window.location ='#';", true);
                    pnlMain.Enabled = true;
                    pnlesct.Visible = false;
                    pnlMain.Attributes.CssStyle.Add("opacity", "1");
                    ddlesctagency.SelectedIndex = 0; ;
                    txtesctapplicantname.Text = "";
                    txtesctdob.Text = "";
                    txtEsctpassFromdate.Text = "";
                    txtEsctpassFromdate.Text = "";
                    txtEsctpassTodate.Text = "";
                    txtesctPassno.Text = "";
                }
            }
            }
            catch (Exception)
            {
                
               // throw;
            }
        }

    }
}