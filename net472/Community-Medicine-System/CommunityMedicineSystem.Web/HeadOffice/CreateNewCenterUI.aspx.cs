using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;

namespace CommunityMedicineSystem.Web.HeadOffice
{
    public partial class CreateNewCenterUI : System.Web.UI.Page
    {
        DistrictAndThanaManager aDistrictAndThanaManager = new DistrictAndThanaManager();
        CenterManager aCenterManager = new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                districtDropDownList.DataSource = aDistrictAndThanaManager.GetAllDistricts();
                districtDropDownList.DataTextField = "Name";
                districtDropDownList.DataValueField = "Id";
                districtDropDownList.DataBind();
                GetThanas();
            }
        }
        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetThanas();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            DAO.Center aCenter = new DAO.Center();
            aCenter.Name = nameTextBox.Text;
            aCenter.DistrictId = Convert.ToInt16(districtDropDownList.SelectedValue);
            aCenter.ThanaId = Convert.ToInt16(thanaDropDownList.SelectedValue);
            int centerId = aCenterManager.Save(aCenter);
            if (centerId > 0)
            {
                Response.Redirect("DisplayNewCenter.aspx?Id=" + centerId);
            }
            else
            {
                msgLabel.Text = "error";
            }
        }

        private void GetThanas()
        {
            int districtId = Convert.ToInt32(districtDropDownList.SelectedValue);
            thanaDropDownList.DataSource = aDistrictAndThanaManager.GetSelectedThanas(districtId);
            thanaDropDownList.DataTextField = "Name";
            thanaDropDownList.DataValueField = "Id";
            thanaDropDownList.DataBind();
        }
    }
}