using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CommunityMedicineSystem.BLL;
using CommunityMedicineSystem.DAO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace CommunityMedicineSystem.Web.HeadOffice
{
    public partial class PatientHistoryUI : System.Web.UI.Page
    {
        PatientManager aPatientManager = new PatientManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void generatePDFButton_Click(object sender, EventArgs e)
        {
            DataTable aDataTable = aPatientManager.GetData(Convert.ToInt64(voterIdTextBox.Text));

            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.ShowHeaderWhenEmpty = true;
            GridView1.DataSource = aDataTable;
            GridView1.DataBind();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=AllHistoryOfAPatient.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter aStringWriter = new StringWriter();
            HtmlTextWriter aHtmlTextWriter = new HtmlTextWriter(aStringWriter);
            GridView1.RenderControl(aHtmlTextWriter);
            StringReader aStringReader = new StringReader(aStringWriter.ToString());
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker aHtmlWorker = new HTMLWorker(pdfDocument);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            aHtmlWorker.Parse(aStringReader);
            pdfDocument.Close();
            Response.Write(pdfDocument);
            Response.End();
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            Patient aPatient = aPatientManager.GetInfoFromWebService(voterIdTextBox.Text);
            nameTextBox.Text = aPatient.Name;
            addressTextBox.Text = aPatient.Address;
            
            patientHistoryGridView.DataSource = aPatientManager.GetPatient(Convert.ToInt64(voterIdTextBox.Text));
            patientHistoryGridView.DataBind();
            patientHistoryGridView.DataBind();
            
        }
    }
}