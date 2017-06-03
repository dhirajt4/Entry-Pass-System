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
    public partial class WebForm10 : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Upload Pic";
        }

        protected void btnUploadProfilePic_Click(object sender, EventArgs e)
        {
            string exe;
            string filename;
            string key = CreateRandomKey();
            if (fuProfilePic.HasFile)
            {
                exe = Path.GetExtension(fuProfilePic.PostedFile.FileName);
                if (exe == ".jpg" || exe == ".JPG" || exe == ".png")
                {
                    obj.UploadUserID = Convert.ToInt32(Session["id"].ToString());
                    filename = fuProfilePic.FileName;
                    obj.Uploadfilename = key + filename;
                    int i = bal.profilepicUpload(obj);
                    if (i == 404)
                    {
                        String root =Server.MapPath("ProfileImage/");
                        fuProfilePic.SaveAs(root + "/" + obj.Uploadfilename);
                        Session["pic"] = obj.Uploadfilename;
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Profilr Pic Successfully Update...!!!');window.location ='UploadPic.aspx';", true);
                       
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Try Again.....!!!!');window.location ='#';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Profile Pic Only .jpg , .png Format');window.location ='#';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Upload Profile Image');window.location ='#';", true);
            }
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
    }
}