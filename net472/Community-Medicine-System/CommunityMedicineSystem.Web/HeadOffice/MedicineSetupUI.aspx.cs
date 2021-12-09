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
    public partial class MedicineSetupUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            MedicineManager aMedicineManager = new MedicineManager();
            Medicine aMedicine = new Medicine();
            aMedicine.Name = nameTextBox.Text;
            aMedicine.Power = Convert.ToInt32(powerTextBox.Text);
            aMedicine.Type = mgMlDropDownList.SelectedItem.ToString();

            string msg = aMedicineManager.SaveMedicine(aMedicine);
            msgLabel.Text = msg;
        }
    }
}