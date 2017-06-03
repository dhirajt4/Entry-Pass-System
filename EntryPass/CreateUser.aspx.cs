using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Layer;
using Business_ObjectLayer;
using System.Data;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace AirportAuthoritiesUI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //static int staticid;
         //static string key;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Add User";
            if (Session["UserID"] != null && Session["CompanyID"] != null)
            {
                if (!IsPostBack)
                {
                    online.Checked = true;
                    displayAllUser();
                    displayRole();
                }
            }
        }
        public void displayRole()
        {
            try
            {
                obj.Roleid = Convert.ToInt32(Session["RoleID"]);
                DataSet ds = bal.FetchRoleForCreateUser(obj);
                ddlrole.DataSource = ds;
                ddlrole.DataTextField = "RoleName";
                ddlrole.DataValueField = "RoleLevel";
                ddlrole.DataBind();
                ddlrole.Items.Insert(0, new ListItem("Select User Type", "0"));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void displayAllUser()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                DataSet dt = bal.FetchAllRegisterUsers(obj);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    pnlAllUsers.Visible = true;
                    rptShowUser.DataSource = dt;
                    rptShowUser.DataBind();
                }
                else
                {
                    pnlAllUsers.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
      

        public static string CreateRandomKey()
        {
            string _allowedChars = "0123456789AFDVVBNGHJXCV55448412121scfsdnvjsd123456789njfnjknbhjbvccxrzswezwrcxxXDXDXDFX122524584758596552123asasasasDFWEDXJKNKBTMEDMWQIOJDOERJ";
            Random randNum = new Random((int)DateTime.Now.Ticks);
            char[] chars = new char[50];
            for (int i = 0; i < 50; i++)
            {
                chars[i] = _allowedChars[randNum.Next(_allowedChars.Length)];
            }
            return new string(chars);
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
        protected void btnregister_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtemail.Text != string.Empty && txtfullname.Text != string.Empty )
                {
                    obj.Txtfullname = txtfullname.Text.Trim();
                    obj.Txtemail = txtemail.Text.Trim();
                    //obj.DdlUserType = Convert.ToInt32(ddlUserType.SelectedValue);
                    //if (ddlSubParty.SelectedIndex != 0)
                    //{
                    //    obj.DdlSubParty = Convert.ToInt32(ddlSubParty.SelectedValue);
                    //}
                    if (online.Checked == true)
                    {
                         ViewState["key"] = CreateRandomKey().ToString();
                         obj.Systempassword = ViewState["key"].ToString();
                    }
                    else
                    {
                        obj.Password = EncodePasswordToBase64("Password1");
                    }
                    obj.Roleid =Convert.ToInt32 (ddlrole.SelectedValue);
                        obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                        int i = bal.UserRegister(obj);
                        if (i == 101)
                        {

                            if (online.Checked == true)
                            {

                                DataSet dt = bal.sendinformation(Convert.ToInt32(Session["CompanyID"]));
                                if (dt.Tables[0].Rows.Count > 0)
                                {
                                    obj.Systempassword = ViewState["key"].ToString();
                                string fromaddr = dt.Tables[0].Rows[0]["smtp_username"].ToString();
                                string toaddr = txtemail.Text;//TO ADDRESS HERE
                                string password = dt.Tables[0].Rows[0]["smtp_password"].ToString();
                                MailMessage msg = new MailMessage();
                                msg.Subject = "Account Detail";
                                msg.From = new MailAddress(fromaddr);
                                msg.Body = " Hi-" + txtemail.Text + "<br/><br/>Activate your Account - http://" + Request.Url.Authority + "/AccountActivation.aspx?" + ViewState["key"].ToString();
                                msg.IsBodyHtml = true;
                                msg.To.Add(new MailAddress(txtemail.Text));
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = dt.Tables[0].Rows[0]["smtp"].ToString();
                                smtp.Port =Convert.ToInt32 (dt.Tables[0].Rows[0]["smtp_port"].ToString());
                                smtp.UseDefaultCredentials = true;
                                smtp.EnableSsl = true;
                                NetworkCredential nc = new NetworkCredential(fromaddr, password);
                                smtp.Credentials = nc;
                               int p= bal.insertforgotrequest(obj);
                               if (p == 202)
                               {
                                    smtp.Send(msg);
                                  ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('User Register Successfully');window.location ='#';", true);
                                    displayAllUser();
                                    txtemail.Text = "";
                                    txtfullname.Text = "";
                                  
                               }
                                    //   using (MailMessage mm = new MailMessage("info@sambhavhcp.co.in", txtemail.Text))
                                    //{
                                    //    string ActivationUrl;

                                    //  //  ActivationUrl = Server.HtmlEncode("http://localhost:51015/ActivationPage.aspx?name=" + Encrypt(Convert.ToString(userId)) + "");

                                    //    mm.Subject = "Account Activation";
                                    //    string body = "Hello " + txtemail.Text + ",";
                                    //    body += "<br />Greetings from Sambhav Online Health Care Portal,</br>Please FindYour Password.</br></br>";
                                    //    body += "<br />Your Password :'" + txtemail.Text + "'";
                                    //    body += "<br /><br />Thanks";
                                    //    mm.Body = body;
                                    //    mm.IsBodyHtml = true;
                                    //    SmtpClient smtp = new SmtpClient();
                                    //    smtp.Host = "sambhavhcp.co.in";
                                    //    smtp.EnableSsl = false;
                                    //    NetworkCredential NetworkCred = new NetworkCredential("info@sambhavhcp.co.in", "sambhav@123");
                                    //    smtp.UseDefaultCredentials = false;
                                    //    smtp.Credentials = NetworkCred;

                                    //    smtp.Send(mm);
                                    


                                    //mailaddress = dt.Tables[0].Rows[0]["mailaddress"].ToString().Trim();
                                    //smtp = dt.Tables[0].Rows[0]["smtp"].ToString().Trim();
                                    //username = dt.Tables[0].Rows[0]["smtp_username"].ToString().Trim();
                                    //password = dt.Tables[0].Rows[0]["smtp_password"].ToString().Trim();
                                    //port = dt.Tables[0].Rows[0]["smtp_port"].ToString().Trim();
                                    //MailMessage ml = new MailMessage();
                                    //ml.To.Add(txtemail.Text.Trim());
                                    //ml.From = new MailAddress(mailaddress.Trim());
                                    //ml.Subject = "Account Activation Key";
                                    //ml.Body += "<html>";
                                    //ml.Body += "<body>";
                                    //ml.Body += "<table>";
                                    //ml.Body += "<tr>";
                                    //ml.Body += "<td>Hi</td><td>" + txtfullname.Text.Trim() + "</td>";
                                    //ml.Body += "</tr>";
                                    //ml.Body += "<tr>";

                                    //ml.Body += "<td>Your Account Activation Link :-</td><td>http://HttpContext.Current.Request.Url.Host/AccountActivation.aspx?" + key + "</td>";
                                    ////
                                    //ml.Body += "</tr>";
                                    //ml.Body += "</table>";
                                    //ml.Body += "</body>";
                                    //ml.Body += "</html>";
                                    //ml.IsBodyHtml = true;
                                    //SmtpClient smtpclnt = new SmtpClient(smtp.Trim());
                                    // smtpclnt.EnableSsl = true;
                                    //smtpclnt.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    //smtpclnt.UseDefaultCredentials = false;
                                    //smtpclnt.Credentials = new NetworkCredential(username.Trim(), password.Trim());
                                    //smtpclnt.Send(ml);
                                    
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('User Register Successfully');window.location ='#';", true);
                                displayAllUser();
                                txtemail.Text = "";
                                txtfullname.Text = "";
                                ddlrole.SelectedIndex = 0;
                            }
                        }

                        else if (i == 202)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('This Email ID Already Register');window.location ='#';", true);
                        }

                    }
                
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('All Field Requierd');window.location ='#';", true);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        protected void rptShowUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    obj.Edituserid1 = Convert.ToInt32(e.CommandArgument.ToString());
                    DataSet dt = bal.EditRegisterUser(obj);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        pnlRegister.Visible = false;
                        pnlUpdate.Visible = true;
                        usermode.Visible = false;
                        ddlrole.SelectedValue = dt.Tables[0].Rows[0]["RoleID"].ToString();
                        ViewState["staticid"] = Convert.ToInt32(dt.Tables[0].Rows[0]["ID"]);
                        txtemail.Text = dt.Tables[0].Rows[0]["UserID"].ToString();
                        txtfullname.Text = dt.Tables[0].Rows[0]["EmpName"].ToString();
                        //if(Convert.ToInt32(dt.Tables[0].Rows[0]["Sub_party_code"])>0)
                        //{
                        //ddlSubParty.SelectedValue = Convert.ToInt32(dt.Tables[0].Rows[0]["Sub_party_code"]).ToString();
                        //}
                        //ddlUserType.SelectedValue = Convert.ToInt32(dt.Tables[0].Rows[0]["UserTypeID"]).ToString();
                    }
                    else
                    {

                    }
                }
               else if (e.CommandName == "Delete")
                {

                    obj.Deleteuserid = Convert.ToInt32(e.CommandArgument.ToString());
                    int i = bal.DeleteRegisterUser(obj);
                    if (i == 505)
                    {
                        displayAllUser();
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Successfully Change User Status');window.location ='#';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Try Again Later');window.location ='#';", true);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtemail.Text != string.Empty && txtfullname.Text != string.Empty)
                {
                    obj.Edituserid1 = Convert.ToInt32(ViewState["staticid"]);
                    obj.Txtfullname = txtfullname.Text.Trim();
                    obj.Txtemail = txtemail.Text.Trim();
                    obj.Roleid = Convert.ToInt32(ddlrole.SelectedValue);
                   // obj.DdlUserType = Convert.ToInt32(ddlUserType.SelectedValue);
                    //obj.DdlSubParty = Convert.ToInt32(ddlSubParty.SelectedValue);
                    int i = bal.updateRegisterUser(obj);
                    if (i == 101)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Successfully Update');window.location ='#';", true);
                        displayAllUser();
                        txtemail.Text = "";
                        txtfullname.Text = "";
                        ddlrole.SelectedIndex = 0;
                        pnlRegister.Visible = true;
                        pnlUpdate.Visible = false;
                        usermode.Visible = true;
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('All Field Requierd');window.location ='#';", true);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
    }
}