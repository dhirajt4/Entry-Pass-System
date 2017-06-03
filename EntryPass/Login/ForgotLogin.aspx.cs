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


namespace AirportAuthoritiesUI.Login
{
    public partial class ForgotLogin : System.Web.UI.Page
    {

         int p;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {           

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
        protected void btnforgot_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtemail.Text != "")
                {
                
                    obj.Forgotemail = txtemail.Text.Trim();
                     p = bal.forgotlogin(obj);
                    if (p > 0)
                    {
  
                       string key = CreateRandomKey();
                            DataSet dt = bal.sendinformation(p);
                            if (dt.Tables[0].Rows.Count > 0)
                            {
                                obj.Systempassword = key;
                                string fromaddr = dt.Tables[0].Rows[0]["smtp_username"].ToString();
                                string toaddr = txtemail.Text;//TO ADDRESS HERE
                                string password = dt.Tables[0].Rows[0]["smtp_password"].ToString();
                                MailMessage msg = new MailMessage();
                                msg.Subject = "Reset Password";
                                msg.From = new MailAddress(fromaddr);
                                msg.Body = "http://" + Request.Url.Authority + "/Login/ResetLoginPassword.aspx?" + key ;
                                msg.To.Add(new MailAddress(txtemail.Text));
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = dt.Tables[0].Rows[0]["smtp"].ToString();
                                smtp.Port =Convert.ToInt32 (dt.Tables[0].Rows[0]["smtp_port"].ToString());
                                smtp.UseDefaultCredentials = true;
                                smtp.EnableSsl = true;
                                NetworkCredential nc = new NetworkCredential(fromaddr, password);
                                smtp.Credentials = nc;
                               int i= bal.insertforgotrequest(obj);
                               if (i == 202)
                               {
                                   ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Check Your Email ID');window.location ='../login/login.aspx';", true);
                                   txtemail.Text = "";
                                   smtp.Send(msg);
                               }



             //                     MailMessage ml = new MailMessage();
             //                   ml.To.Add(txtemail.Text.Trim());
             //                   ml.From = new MailAddress("manojcomsoft@gmail.com");
             //                   ml.Subject = "Account Activation Key";
             //                   ml.Body += "<html>";
             //                   ml.Body += "<body>";
             //                   ml.Body += "<table>";
             //                   ml.Body += "<tr>";
             //                   ml.Body += "<td>Hi</td><td>" + txtemail.Text.Trim() + "</td>";
             //                   ml.Body += "</tr>";
             //                   ml.Body += "<tr>";

             //                   ml.Body += "<td>Reset Password Link :-</td><td>http://" + Request.Url.Authority + "/Login/ResetLoginPassword.aspx?" + key + "</td>";
             //                   //
             //                   ml.Body += "</tr>";
             //                   ml.Body += "</table>";
             //                   ml.Body += "</body>";
             //                   ml.Body += "</html>";
             //                   ml.IsBodyHtml = true;
             //                   SmtpClient smtpclnt = new SmtpClient();
             //                   smtpclnt.Host = "smtp.gmail.com";
             //                   smtpclnt.Port = 587;
                                
             //                   smtpclnt.DeliveryMethod = SmtpDeliveryMethod.Network;
             //                   //smtpclnt.UseDefaultCredentials = true;
             //                   smtpclnt.Credentials = new NetworkCredential("manojcomsoft@gmail.com", "comsoftconsultancy");
             //                   smtpclnt.EnableSsl = false;

             //                   System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
             //System.Security.Cryptography.X509Certificates.X509Certificate certificate,
             //System.Security.Cryptography.X509Certificates.X509Chain chain,
             //System.Net.Security.SslPolicyErrors sslPolicyErrors)
             //                   {
             //                       return true;
             //                   };

             //                   smtpclnt.Send(ml);

                              
                              
                            }
                       // }
                    }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Incorrect Email ID');window.location ='#';", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Email ID Not black');window.location ='#';", true);
                        txtemail.Focus();
                    }
               
            }
            catch  (Exception)
            {

                throw;
            }
        }
    }
}