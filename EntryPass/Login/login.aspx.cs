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

namespace AirportAuthoritiesUI.Login
{
    public partial class login : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
           
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
        //protected void btnlogin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtemail.Text != string.Empty && txtpassword.Text != string.Empty)
        //        {
        //            obj.LoginEmailid = txtemail.Text.Trim();
        //            obj.LoginPassword = EncodePasswordToBase64(txtpassword.Text.Trim());
        //            obj.Login_status=Convert.ToBoolean("True");
        //            int i = bal.Ckeck_login(obj);
        //            if (i == 303)
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Unauthorised User');window.location ='#';", true);
        //            }
        //            else if (i == 202)
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Email ID and Password Wrong Combination');window.location ='#';", true);
        //            }
        //            else if (i == 101)
        //            {
        //                obj.LoginEmailid = txtemail.Text.Trim();
        //                obj.LoginPassword = EncodePasswordToBase64(txtpassword.Text.Trim());
        //                DataSet dt = bal.Ckeck_login1(obj);
        //                if (dt.Tables[0].Rows.Count > 0)
        //                {
        //                    Session["UserID"] = dt.Tables[0].Rows[0]["UserID"].ToString();
        //                    Session["CompanyID"] = dt.Tables[0].Rows[0]["CompanyID"].ToString();
        //                    Session["RoleID"] = dt.Tables[0].Rows[0]["RoleID"].ToString();
        //                    Session["id"] = dt.Tables[0].Rows[0]["ID"].ToString();
        //                    Application["logoutid"] = dt.Tables[0].Rows[0]["ID"].ToString();
        //                    Session["name"] = dt.Tables[0].Rows[0]["EmpName"].ToString();
        //                    Session["pic"] = dt.Tables[0].Rows[0]["ProfilePic"].ToString();
        //                    //  Response.Redirect("~/WebForm1.aspx");
        //                    if (txtpassword.Text == "Password1")
        //                    {
        //                       // Session["CompanyID"] = dt.Tables[0].Rows[0]["CompanyID"].ToString();
        //                        //Session["id"] = dt.Tables[0].Rows[0]["ID"].ToString();
        //                       // Session["name"] = dt.Tables[0].Rows[0]["EmpName"].ToString();
        //                       // Session["pic"] = dt.Tables[0].Rows[0]["ProfilePic"].ToString();
        //                        Session["default"] = 9026;
        //                       // Application["logoutid"] = dt.Tables[0].Rows[0]["ID"].ToString(); 
        //                        Response.Redirect("~/AccountActivation.aspx");
        //                    }
        //                    else
        //                    {
        //                       // Session["CompanyID"] = dt.Tables[0].Rows[0]["CompanyID"].ToString();
        //                        //Session["id"] = dt.Tables[0].Rows[0]["ID"].ToString();
        //                       // Application["logoutid"] = dt.Tables[0].Rows[0]["ID"].ToString(); 
        //                       // Session["name"] = dt.Tables[0].Rows[0]["EmpName"].ToString();
        //                       // Session["pic"] = dt.Tables[0].Rows[0]["ProfilePic"].ToString();
        //                        //HttpCookie _UserData = Request.Cookies["Info"];
        //                        //if (_UserData != null)
        //                        //{
        //                        //    string str = _UserData["Page"];
        //                        //    Response.Redirect(str);
        //                        //}
        //                        //else
        //                       // {
        //                        Response.Redirect("~/Dashboard.aspx");
        //                       // }
        //                    }
        //                }

        //            }
        //            else if(i==404)
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('You Are Already Login ');window.location ='#';", true);
        //            }
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('All Field Requierd');window.location ='#';", true);
        //        }
        //    }
        //    catch 
        //    {
        //        throw;
        //    }
        //    finally
        //    { 
        //    }
        //}
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            login123();
        }
        public void login123()
        {
            string myIP;
            try
            {
                if (Convert.ToInt32(ViewState["expire"]) == 100)
                {
                    txtpassword.Text =ViewState["pass"].ToString();
                }
                if (txtemail.Text != string.Empty && txtpassword.Text != string.Empty)
                {
                    obj.LoginEmailid = txtemail.Text.Trim();
                    ViewState["pass"] = txtpassword.Text.Trim();
                    obj.LoginPassword = EncodePasswordToBase64(ViewState["pass"].ToString());
                    obj.Login_status = Convert.ToBoolean("True");

                    string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                    // Get the IP
                     myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                    //obj.LogData = Session["name"].ToString() +","+ Session["UserID"].ToString() +","+ unique +","+ myIP + ","+Request.Url.AbsoluteUri;
                    obj.Id = Convert.ToInt32(Session["id"]);
                    obj.Ipaddress = myIP;
                    obj.Url = Request.Url.AbsoluteUri;
                    obj.Uid = txtemail.Text;
                    obj.Loginstatusid = Guid.NewGuid().ToString();
                    int i = bal.Ckeck_login(obj);
                    if (i == 303)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Unauthorised User');window.location ='#';", true);
                    }
                    else if (i == 202)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Email ID and Password Wrong Combination');window.location ='#';", true);
                    }
                    else if (i == 101)
                    {
                        obj.LoginEmailid = txtemail.Text.Trim();
                        obj.LoginPassword = EncodePasswordToBase64(txtpassword.Text.Trim());
                        DataSet dt = bal.Ckeck_login1(obj);
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                           
                            Application["logoutid"] = dt.Tables[0].Rows[0]["ID"].ToString();
                            Session["Login_Status"] = dt.Tables[0].Rows[0]["Login_Status"].ToString();
                            Session["id"] = dt.Tables[0].Rows[0]["ID"].ToString();
                            Session["name"] = dt.Tables[0].Rows[0]["EmpName"].ToString();
                            Session["RoleID"] = dt.Tables[0].Rows[0]["RoleID"].ToString();
                            Session["pic"] = dt.Tables[0].Rows[0]["ProfilePic"].ToString();
                            Session["UserID"] = dt.Tables[0].Rows[0]["UserID"].ToString();
                            Session["CompanyID"] = dt.Tables[0].Rows[0]["CompanyID"].ToString();
                            Session["CompanyLogo"] = new Uri(Server.MapPath(dt.Tables[0].Rows[0].Field<string>("CompanyLogo"))).AbsoluteUri;
                            if (txtpassword.Text == "Password1")
                            {
                                Session["default"] = 9026;
                                Response.Redirect("~/AccountActivation.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Dashboard.aspx");
                            }
                        }

                    }
                    else if (i == 404)
                    {
                        pnllogin.Visible = false;
                        pnlaltermessage.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('All Field Requierd');window.location ='#';", true);
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
        protected void btnyes_Click(object sender, EventArgs e)
        {
            try
            {
                obj.LoginEmailid = txtemail.Text.Trim();
                bal.sessionexpire(obj);
                pnllogin.Visible = true;
                pnlaltermessage.Visible = false;
                ViewState["expire"] = 100;
                login123();
            }
            catch (Exception)
            {

                // throw;
            }

        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            pnllogin.Visible = true;
            pnlaltermessage.Visible = false;
        }


    }
}