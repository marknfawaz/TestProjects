using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;

namespace CommunityMedicineSystem.Web.Center
{
    public partial class MedicineStockReportUI : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != "center")
            {
                Response.Redirect("../index.aspx");
            }
            else
            {
                //DAO.Center aCenter = aCenterManager.GetCenter(Convert.ToInt32(Session["CenterId"]));
                int centerId = Convert.ToInt32(Session["CenterId"]);
                centerLabel.Text = aCenterManager.FindById(centerId).Name;
                stockReportGridView.DataSource = aCenterManager.GetMedicineStockInCenters(centerId);
                stockReportGridView.DataBind();
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../index.aspx");
        }
    }
}