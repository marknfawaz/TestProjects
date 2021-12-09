using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.Web.HeadOffice
{
    public partial class DiseaseWiseReport : System.Web.UI.Page
    {
        DiseaseManager aDiseaseManager = new DiseaseManager();
       
        

        public void showButton_Click(object sender, EventArgs e)
        {
            int diseaseId= Convert.ToInt16(diseaseDropDownList.SelectedValue);
            DateTime startDateTime= Convert.ToDateTime(startTextBox.Value);
            DateTime endDateTime = Convert.ToDateTime(endTextBox.Value);
            showGridView.DataSource = aDiseaseManager.GetTotalPatientList(startDateTime, endDateTime, diseaseId);
            showGridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            diseaseDropDownList.DataSource = aDiseaseManager.GetAllDiseases();
            diseaseDropDownList.DataTextField = "Name";
            diseaseDropDownList.DataValueField ="Id";
            diseaseDropDownList.DataBind();
        }
    }
}