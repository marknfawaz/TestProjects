using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace CommunityMedicineSystem.DAL
{
    public class CommonDBGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["CommunityMedicine"].ConnectionString;
        public SqlConnection ASqlConnection { set; get; }
        public SqlCommand ASqlCommand { set; get; }
        public SqlDataReader ASqlDataReader { set; get; }

        public CommonDBGateway()
        {
            ASqlConnection = new SqlConnection(connectionString);
        }
    }
}
