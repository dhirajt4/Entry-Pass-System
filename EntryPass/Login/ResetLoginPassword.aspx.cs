using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Layer;
using Business_ObjectLayer;
using System.Data;

namespace AirportAuthoritiesUI.Login
{
    public partial class ResetLoginPassword : System.Web.UI.Page
    {
        // static int resetid;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadpage();
            }
        }
        public void loadpage()
        {
            try
            {

                if (Request.QueryString.ToString().Trim().Length > 0)
                {

                    obj.Key = Request.QueryString.ToString().Trim();

                    DataSet dt = bal.checklink(obj);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        ViewState["resetid"] = Convert.ToInt32(dt.Tables[0].Rows[0]["ID"]);
                        lblusername.Text = dt.Tables[0].Rows[0]["EmpName"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Link Expire');window.location ='login.aspx';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Unauthorised User');window.location ='login.aspx';", true);
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnewpassword.Text != string.Empty && txtrepassword.Text.Trim() != string.Empty)
                {
                    if (txtnewpassword.Text.Trim() == txtrepassword.Text.Trim())
                    {

                            obj.ResetPassworduserid1 = Convert.ToInt32(ViewState["resetid"]);
                            obj.Newpassword = EncodePasswordToBase64(txtnewpassword.Text.Trim());
                            obj.Logout_status = Convert.ToBoolean("False");
                            int i = bal.ResetPassword(obj);
                            if (i == 101)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Password Successfully Change...!!!');window.location ='Login/login.aspx';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Try Again Later....!!!');window.location ='#';", true);
                            }
                      
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Both Password Can Not Same');window.location ='#';", true);
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