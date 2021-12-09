using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.Web.Center
{
    public partial class PatientHistoryUI : System.Web.UI.Page
    {
        PatientManager aPatientManager = new PatientManager();
        CenterManager aCenterManager = new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != "center")
            {
                Response.Redirect("../index.aspx");
            }
            else
            {
                int centerId = Convert.ToInt32(Session["CenterId"]);
                centerLabel.Text = aCenterManager.FindById(centerId).Name;
                voterIdTextBox.Text = Request.QueryString[0];
                Patient aPatient = aPatientManager.GetInfoFromWebService(voterIdTextBox.Text);
                
                nameTextBox.Text = aPatient.Name;
                addressTextBox.Text = aPatient.Address;

                patientHistoryGridView.DataSource = aPatientManager.GetPatient(Convert.ToInt64(voterIdTextBox.Text));
                patientHistoryGridView.DataBind();
                patientHistoryGridView.DataBind();
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../index.aspx");
        }
    }
}