using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business_Layer;
using Business_ObjectLayer;
using Microsoft.Reporting.WebForms;

namespace EntryPass
{
    public partial class printpass : System.Web.UI.Page
    {
        string asd;
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Entry | A E P Print Pass";
            if (Session["receipt"] != null || Session["print"] != null)
            {
                if (Session["print"] == null)
                {
                    Session["print"] = 990;
                }
                if (Session["receipt"] == null)
                {
                    Session["receipt"] = 990000;
                }
                pnlerror.Visible = false;
                // rdlc.Visible = true;
                PrintPassAndReceipt();
            }
            else
            {
                //rdlc.Visible = false;
                pnlerror.Visible = true;
            }
        }
        public void PrintPassAndReceipt()
        {
            try
            {

                if (Session["print"].ToString() == "99" || Session["receipt"].ToString() == "202")
                {
                    obj.Active = 1;
                }
                else
                {
                    obj.Active = 2;
                }
                obj.Companyid = Convert.ToInt32(Session["CompanyID"]);
                obj.SelectPass = Request.QueryString[0];
                obj.Action = 202.ToString();
                DataSet ds = bal.areaZones(obj);

                DataSet dt = bal.Printpass(obj);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    ReportViewer1.Reset();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    if (Session["print"].ToString() == "303" || Session["print"].ToString() == "99")
                    {
                        ReportViewer1.LocalReport.ReportPath = "Copyofprintpass.rdlc";
                        string imagePath = new Uri(Server.MapPath("Applicant/" + dt.Tables[0].Rows[0]["photo"].ToString())).AbsoluteUri;
                        ReportParameter parameter = new ReportParameter("imagepath", imagePath);
                        string sign = new Uri(Server.MapPath("Applicant/" + dt.Tables[0].Rows[0]["sign"].ToString())).AbsoluteUri;
                        ReportParameter parametersign = new ReportParameter("sign", sign);
                        ReportViewer1.LocalReport.SetParameters(parameter);
                        ReportViewer1.LocalReport.SetParameters(parametersign);
                        string[] words = dt.Tables[0].Rows[0]["areazones"].ToString().Split(',');
                        for (int p = 0; ds.Tables[0].Rows.Count > p; p++)
                        {
                            asd = asd + ds.Tables[0].Rows[p]["ShortCut"].ToString() + ",";
                        }
                        asd = asd + "pp";
                        string[] words1 = asd.Split(',');
                        foreach (string word in words1)
                        {
                            var results = Array.FindAll(words, s => s.Equals(word));
                            if (results.Length != 0)
                            {
                                string dd = results[0].ToString();
                                string area = new Uri(Server.MapPath("img/Areazones/" + results[0].ToString() + ".png")).AbsoluteUri;
                                ReportParameter areazone = new ReportParameter(results[0].ToString().ToLower(), area);
                                ReportViewer1.LocalReport.SetParameters(areazone);
                            }
                            else
                            {
                                string area = new Uri(Server.MapPath("img/Areazones/mm.png")).AbsoluteUri;
                                ReportParameter areazone = new ReportParameter(word.ToLower(), area);
                                ReportViewer1.LocalReport.SetParameters(areazone);
                            }
                        }
                    }
                    else if (Session["receipt"].ToString() == "202")
                    {
                        ReportViewer1.LocalReport.ReportPath = "receipt.rdlc";
                    }
                    ReportDataSource report = new ReportDataSource("DataSet1", dt.Tables["table"]);
                    ReportDataSource rep = new ReportDataSource("DataSet2", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(rep);
                    ReportViewer1.LocalReport.DataSources.Add(report);
                    ReportViewer1.LocalReport.Refresh();

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Session["receipt"] = null;
                Session["print"] = null;
            }
        }
    }
}