using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Data;
using Business_Layer;
using Business_ObjectLayer;



namespace EntryPass
{
    public partial class test : System.Web.UI.Page
    {

        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pp = Image1.ImageUrl;
                
                //permanentpassdetails();
            }
        }
        public void permanentpassdetails()
        {
            obj.Companyid = 1;
            obj.Active = 4;
            DataSet dt = bal.DisplayApprovePass(obj);
            if (dt.Tables[0].Rows.Count > 0)
            {
                // rptpermanentAEPUpdate.Visible = true;
                //rptpermanentAEPUpdate.DataSource = dt.Tables[0];
                //rptpermanentAEPUpdate.DataBind();
                GridView1.Visible = true;
                GridView1.DataSource = dt.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                //rptpermanentAEPUpdate.Visible = false;
            }
        }

        protected void dgvpermanentpass_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvpermanentpass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            permanentpassdetails();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            permanentpassdetails();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;


            permanentpassdetails();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

            //Label lblID = (Label)row.FindControl("lblID");

            //TextBox txtname=(TextBox)gr.cell[].control[];

            TextBox textName = (TextBox)row.Cells[0].Controls[0];

            // TextBox textadd = (TextBox)row.Cells[1].Controls[0];

            // TextBox textc = (TextBox)row.Cells[2].Controls[0];

            //TextBox textadd = (TextBox)row.FindControl("txtadd");

            //TextBox textc = (TextBox)row.FindControl("txtc");

            GridView1.EditIndex = -1;
            string aa = textName.Text;
        }



        protected void Button1_Click(object sender, EventArgs e)
        {


            Label1.Text = txt.Text;
            //plBarCode.Font = new Font("IDAutomation Uni L", 12, FontStyle.Regular); 



        //old code 

        //     string barCode =txt.Text;
        //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        //using (Bitmap bitMap = new Bitmap(barCode.Length * 21, 80))
        //{
        //    using (Graphics graphics = Graphics.FromImage(bitMap))
        //    {
        //        Font oFont = new Font("IDAutomationHC39M", 15);
        //        PointF point = new PointF(2f, 2f);
        //        SolidBrush blackBrush = new SolidBrush(Color.Black);
        //        SolidBrush whiteBrush = new SolidBrush(Color.White);
        //        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
        //        graphics.DrawString(barCode, oFont, blackBrush, point);
        //    }
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //        byte[] byteImage = ms.ToArray();
        //        Convert.ToBase64String(byteImage);
        //        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        //       // Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        //    }
        //     plBarCode.Controls.Add(imgBarCode);
        //    //Image1.Controls.Add(imgBarCode);
            

        //}



            //string bar = barcode_text.InnerText;
            //Bitmap bit = new Bitmap(bar.Length * 40, 150);
            //using (Graphics grap = Graphics.FromImage(bit))
            //{
            //    Font font = new System.Drawing.Font("IDAutomationHC39M", 20);

            //   // Bitmap bit = new Bitmap(bar.Length * 40, 150);
            //    PointF point = new PointF(2f, 2f);
            //    SolidBrush black = new SolidBrush(Color.Black);
            //    SolidBrush White = new SolidBrush(Color.White);
            //    grap.FillRectangle(White, 0, 0, bit.Width, bit.Height);
            //    grap.DrawString("*" + bar + "*", font, black, point);
            //}
            //using(MemoryStream ms=new MemoryStream())
            //{
            //    bit.Save(ms, ImageFormat.png);
            //    Image1.ImageUrl = bit;
            //}
        }

        protected void Linkbutton1_Click(object sender, EventArgs e)
        {

        }
    }
}