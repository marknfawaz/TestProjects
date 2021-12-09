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
    public partial class DoctorEntryUI : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        DoctorManager aDoctorManager = new DoctorManager();
        private Doctor aDoctor;
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
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../index.aspx");
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            aDoctor = new Doctor();
            DAO.Center aCenter = aCenterManager.GetCenter(Convert.ToInt32(Session["CenterId"]));
            aDoctor.Name = nameTextBox.Text;
            aDoctor.Degree = degreeTextBox.Text;
            aDoctor.Specialization = specializationTextBox.Text;
            aDoctor.CenterId = aCenter.Id;
            string msg = aDoctorManager.SaveDoctor(aDoctor);
            msgLabel.Text = msg;
        }
    }
}