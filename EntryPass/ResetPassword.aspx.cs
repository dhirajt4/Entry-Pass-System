using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Business_Layer;
using Business_ObjectLayer;


namespace AirportAuthoritiesUI
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Reset Password";
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
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != string.Empty && txtNewPassword.Text != string.Empty && ddlBillPeriod.SelectedIndex != 0)
            {
               
                obj.ResetID = Convert.ToInt32(Session["id"].ToString());
                obj.Passwordtype = Convert.ToInt32(ddlBillPeriod.SelectedValue);
                obj.CurrentPassword1 = EncodePasswordToBase64(txtCurrendPassword.Text.Trim());
                obj.NewPassword1 = EncodePasswordToBase64(txtNewPassword.Text.Trim());
                int i = bal.changepassword(obj);
                if (i == 202)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Password Chnage Successfully...!!!');window.location ='#';", true);
                }
                else if (i == 303)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Current Password Do Not Match...!!!');window.location ='#';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Try Again ...!!!');window.location ='#';", true);
                }
            }
            else
            {

            }
        }

        protected void ddlBillPeriod_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBillPeriod.SelectedIndex == 2)
                {
                    txtCurrendPassword.Visible = false;
                    lblcurrentpassword.Visible = false;
                }
                else
                {
                    txtCurrendPassword.Visible = true;
                    lblcurrentpassword.Visible = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}