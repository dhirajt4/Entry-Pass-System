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
    public partial class WebForm8 : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Entry | A E P Digital Signature";
                digitalsign();
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
        public static string CreateRandomKey()
        {
            string _allowedChars = "0123456789AFDVVBNGHJXCV5544841212DXDXDFX122524584758596552123DFWEDXJKNKBTMEDMWQIOJDOERJ";
            Random randNum = new Random((int)DateTime.Now.Ticks);
            char[] chars = new char[5];
            for (int i = 0; i < 5; i++)
            {
                chars[i] = _allowedChars[randNum.Next(_allowedChars.Length)];
            }
            return new string(chars);
        }
        public void digitalsign()
        {
            try
            {
                if (Session["CompanyID"] != null && Session["id"] != null)
                {
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.Signid = Convert.ToInt32(Session["id"].ToString());
                    DataSet i = bal.checkDigitalSign(obj);
                    if (i.Tables[0].Rows[0]["DigitalSign"].ToString() != "0" && i.Tables[0].Rows[0]["DigitalSign"].ToString() !=string.Empty)
                    {
                        pnlSignDetail.Visible = true;
                        pnlInsertSign.Visible = true;
                        byte[] bytes = (byte[])i.Tables[0].Rows[0]["DigitalSign"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        Image1.ImageUrl = "data:image/png;base64," + base64String;


                       // Image1.ImageUrl = "data:image/" + Convert.ToBase64String(img);
                        //Image1.ImageUrl = "/DigitalSign/" + i.Tables[0].Rows[0]["DigitalSign"].ToString();
                       
                    }
                    else 
                    {
                        pnlInsertSign.Visible = true;
                        pnlSignDetail.Visible = false;
                    }

                }
                else
                {
                    Response.Redirect("Login/Login.aspx");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        protected void btnDigitalSign_Click(object sender, EventArgs e)
        {
            try
            {
                    string exe;
                    string filename;
                    string key = CreateRandomKey();
                    obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                    obj.UserID = Convert.ToInt32(Session["id"]).ToString();
                    if (fuDigitalSign.HasFile)
                    {
                        exe = Path.GetExtension(fuDigitalSign.PostedFile.FileName);
                        if (exe == ".jpg" | exe == ".JPG" | exe == ".JPEG")
                        {


                            Stream fs = fuDigitalSign.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            obj.Userdigitalsign = bytes;
                            filename = fuDigitalSign.FileName;
                            obj.Password = EncodePasswordToBase64(txtPassword.Text.Trim());
                            //obj.Digitalsign1 = key + filename;
                            //obj.Password = EncodePasswordToBase64(txtPassword.Text.Trim());
                            //String root = HttpContext.Current.Server.MapPath("/DigitalSign/");
                            //fuDigitalSign.SaveAs(root + "/" + obj.Digitalsign1);
                            int i = bal.InsertDigitalSign(obj);
                            if (i == 606)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Your Digital Sign Upload Successfully');window.location ='#';", true);
                                digitalsign();
                            }
                            else if(i==404)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Insert Correct Password');window.location ='#';", true);
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Upload Only .jpg File or File Size Can Not Greater Then 100 KB');window.location ='#';", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Select Your Ditial Sign');window.location ='#';", true);
                    }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}