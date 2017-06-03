using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Layer;
using Business_ObjectLayer;
using System.Data;


namespace EntryPass
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Setting";
            if (!IsPostBack)
            {
              
                settingfetch();
            }
        }
        private void settingfetch()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                DataSet ds = bal.fetchsetting(obj);
                if(ds.Tables[0].Rows.Count>0)
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["setting_signature"]) == true)
                    {
                        rbsigntrue.Checked = true;
                    }
                    else if (Convert.ToBoolean(ds.Tables[0].Rows[0]["setting_signature"]) == false)
                    {
                        rbsignfalse.Checked = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void rbsigntrue_CheckedChanged(object sender, EventArgs e)
        {
            signature();
        }

        protected void rbsignfalse_CheckedChanged(object sender, EventArgs e)
        {
            signature();
        }
        private void signature()
        {
            try
            {
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                if (rbsigntrue.Checked==true)
                {
                    obj.Setting_signature1 = true;
                }
                else if (rbsignfalse.Checked == true)
                {
                    obj.Setting_signature1 = false;
                }
                int i = bal.updatesetting_sign(obj);
                if(i==101)
                {
                    settingfetch();
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Setting Update Successfully..!');window.location ='#';", true);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}