using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.Web.HeadOffice
{
    public partial class SendMedicineToCenterUI : System.Web.UI.Page
    {
        DistrictAndThanaManager aDistrictAndThanaManager = new DistrictAndThanaManager();
        CenterManager aCenterManager = new CenterManager();
        MedicineManager aMedicineManager = new MedicineManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                districtDropDownList.DataSource = aDistrictAndThanaManager.GetAllDistricts();
                districtDropDownList.DataTextField = "Name";
                districtDropDownList.DataValueField = "Id";
                districtDropDownList.DataBind();

                GetThanas();
                GetCenters();

                medicineDropDownList.DataSource = aMedicineManager.GetAllMedicines();
                //medicineDropDownList.DataTextField = "NamePowerType";
                //medicineDropDownList.DataValueField = "Name";
                medicineDropDownList.DataBind();
            }
        }

        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetThanas();
            GetCenters();
        }

        protected void thanaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCenters();
        }

        protected void centerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetThanas()
        {
            int districtId = Convert.ToInt32(districtDropDownList.SelectedValue);
            thanaDropDownList.DataSource = aDistrictAndThanaManager.GetSelectedThanas(districtId);
            thanaDropDownList.DataTextField = "Name";
            thanaDropDownList.DataValueField = "Id";
            thanaDropDownList.DataBind();
        }

        private void GetCenters()
        {
            int thanaId = Convert.ToInt32(thanaDropDownList.SelectedValue);
            centerDropDownList.DataSource = aCenterManager.GetSelectedCenters(thanaId);
            centerDropDownList.DataTextField = "Name";
            centerDropDownList.DataValueField = "Id";
            centerDropDownList.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string msg = "";

            var nameList = medicineName.Value;
            medicineName.Value = "";
            string[] name = nameList.Split(',');

            var quantityList = medicineQuantity.Value;
            medicineQuantity.Value = "";
            string[] quantity = quantityList.Split(',');

            for (int i = 0; i < name.Length-1; i++)
            {
                Medicine aMedicine = aMedicineManager.Find(name[i]);
                MedicineStockInCenter aMedicineStockInCenter = new MedicineStockInCenter();
                aMedicineStockInCenter.MedicineId = aMedicine.Id;
                aMedicineStockInCenter.CenterId = Convert.ToInt32(centerDropDownList.SelectedValue);
                aMedicineStockInCenter.Quantity = Convert.ToInt32(quantity[i]);

                msg = aMedicineManager.SendMedicineToCenter(aMedicineStockInCenter);
            }

            infoLabel.Text = msg;
        }
    }
}