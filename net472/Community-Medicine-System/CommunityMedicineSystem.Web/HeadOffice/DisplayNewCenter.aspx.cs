using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineSystem.BLL;

namespace CommunityMedicineSystem.Web.HeadOffice
{
    public partial class DisplayNewCenter : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["Id"]);
            DAO.Center aCenter = aCenterManager.DisplayNewCenter(id);
            nameLabel.InnerText = aCenter.Name;
            codeLabel.InnerText = aCenter.Code;
            passwordLabel.InnerText = aCenter.Password;
        }
    }
}