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
    public partial class CenterLoginUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == "center")
            {
                Response.Redirect("CenterMainUI.aspx");
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string msg = "";
            DAO.Center aCenter = new DAO.Center();
            aCenter.Code = codeTextBox.Text;
            aCenter.Password = passwordTextBox.Text;


            CenterManager aCenterManager = new CenterManager();
            aCenter = aCenterManager.CheckCodePassword(aCenter);
            if (aCenter == null)
            {
                msg = "Error code & password...!!!!";
            }
            else
            {
                Session["CenterId"] = aCenter.Id;
                Session["user"] = "center";
                Response.Redirect("CenterMainUI.aspx");
            }
        }
    }
}