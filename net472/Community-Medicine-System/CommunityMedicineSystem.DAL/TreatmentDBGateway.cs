using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class TreatmentDBGateway : CommonDBGateway
    {
        public int SaveTreatment(Treatment aTreatment)
        {
            string query = "INSERT INTO tbl_treatment VALUES ('" + aTreatment.Observation + "','" +aTreatment.ServiceDate+ "','" +
                aTreatment.DoctorId + "','" + aTreatment.DiseaseId + "', '" +aTreatment.MedicineId+ "', '" +
                aTreatment.Dose+ "', '" +aTreatment.Quantity+ "', '" +aTreatment.Note+ "', '" +aTreatment.DoseType+ "', '" +
                aTreatment.CenterId+ "', '" +aTreatment.ServiceTakenId+ "')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            //ASqlCommand.Parameters.Add("@serviceDate", SqlDbType.DateTime).Value = aTreatment.ServiceDate;
            int rowAffected = ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
            return rowAffected;
        }
    }
}
