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
    public partial class WebForm2 : System.Web.UI.Page
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Pass Status";
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtapplicant.Text == "" && txtreg.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please Enter Applicant Name or Reg no ...!!');window.location ='#';", true);
                }
                else
                {
                    obj.Statusapplicant = txtapplicant.Text;
                    obj.Statusregno = txtreg.Text;
                    DataSet dt = bal.passstatus(obj);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        dgvsearchpass.DataSource = dt.Tables[0];
                        dgvsearchpass.DataBind();
                        dgvsearchpass.Visible = true;
                        pnlpassstatus.Visible = true;
                    }
                    else
                    {
                        pnlpassstatus.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No Record Found...!!');window.location ='#';", true);
                        dgvsearchpass.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtreg.Text = "";
            txtapplicant.Text = "";
            dgvsearchpass.Visible = false;
            pnlpassstatus.Visible = false;
        }

        protected void dgvsearchpass_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvsearchpass_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}