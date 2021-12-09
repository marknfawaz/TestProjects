using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class DiseaseDBGateway : CommonDBGateway
    {
        public int Save(Disease aDisease)
        {
            string query = "INSERT INTO tbl_disease VALUES ('" + aDisease.Name + "','" + aDisease.Description + "','" +
                           aDisease.TreatmentProcedure + "','" + aDisease.PreferredDrug + "')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            int rowAffected = ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
            return rowAffected;
        }

        public Disease Find(string name)
        {
            string query = "SELECT * FROM tbl_disease WHERE name= '" + name + "' ";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();
            if (ASqlDataReader.HasRows)
            {
                ASqlDataReader.Read();
                Disease aDisease = new Disease();
                aDisease.Id = (int)ASqlDataReader["id"];
                aDisease.Name = ASqlDataReader["name"].ToString();
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return aDisease;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return null;
            }
        }

        public List<Disease> GetAllDiseases()
        {
            List<Disease> diseaseList = new List<Disease>();
            string query = "SELECT * FROM tbl_disease";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();
            Disease aDisease;

            while (ASqlDataReader.Read())
            {
                aDisease = new Disease();
                aDisease.Id = (int)ASqlDataReader["id"];
                aDisease.Name = ASqlDataReader["name"].ToString();
                aDisease.Description = ASqlDataReader["description"].ToString();
                aDisease.TreatmentProcedure = ASqlDataReader["treatment_procedure"].ToString();
                aDisease.PreferredDrug = ASqlDataReader["preferred_drug"].ToString();

                diseaseList.Add(aDisease);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
            return diseaseList;
        }

        public List<Patient> GetTotalPatientList(DateTime startDateTime, DateTime endDateTime, int diseaseId)
        {
            string query = "SELECT district_id AS districtId,patient_id AS patientId from v_disease_report WHERE disease_id='" + diseaseId + "' and date between '" + startDateTime + "' and '" + endDateTime + "'";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();
            List<Patient> patients = new List<Patient>();
            while (ASqlDataReader.Read())
            {
                Patient aPatient = new Patient();
                aPatient.Id = Convert.ToInt16(ASqlDataReader["patientId"]);
                aPatient.DistrictId = Convert.ToInt16(ASqlDataReader["districtId"]);
                patients.Add(aPatient);
            }
            ASqlDataReader.Close();
            ASqlConnection.Close();
            return patients;
        }
    }
}
