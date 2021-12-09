using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.Web.HeadOffice
{
    public partial class DiseaseSetupUI : System.Web.UI.Page
    {
        DiseaseManager aDiseaseManager = new DiseaseManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Disease aDisease = new Disease();
            aDisease.Name = nameTextBox.Text;
            aDisease.Description = descriptionTextBox.Text;
            aDisease.TreatmentProcedure = treatementProcedureTextBox.Text;
            aDisease.PreferredDrug = preferredDrugTextBox.Text;
            int rowAffected = aDiseaseManager.Save(aDisease);
            if (rowAffected > 0)
            {
                msgLabel.Text = "Disease Saved...";
            }
            else
            {
                msgLabel.Text = "Error in saving or duplicate name of disease...";
            }
        }
    }
}