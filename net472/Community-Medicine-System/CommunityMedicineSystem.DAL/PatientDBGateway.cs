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
    public class PatientDBGateway : CommonDBGateway
    {
        public int Save(Patient aPatient)
        {
            string query = "INSERT INTO tbl_patient VALUES ('" + aPatient.VoterId + "', '" + aPatient.DistrictId + "')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            int rowAffected = ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
            return rowAffected;
        }

        public Patient Find(long voterId)
        {
            string query = "SELECT * FROM tbl_patient WHERE voter_id='" + voterId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                Patient aPatient = new Patient();
                ASqlDataReader.Read();
                aPatient.Id = (int)ASqlDataReader["id"];
                aPatient.VoterId = (long)ASqlDataReader["voter_id"];

                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return aPatient;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return null;
            }
        }

        public void SaveService(Patient aPatient)
        {
            int patientId;
            Patient patient = Find(aPatient.VoterId);
            if (patient == null)
            {
                Save(aPatient);
                patientId = Find(aPatient.VoterId).Id;
            }
            else
            {
                patientId = patient.Id;
            }

            string query = "INSERT INTO tbl_service_taken VALUES ('" + patientId + "')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
        }

        public int GetServiceTakenId()
        {
            string query = "SELECT MAX(id) FROM tbl_service_taken";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();
            ASqlDataReader.Read();
            int serviceTakenId = (int)ASqlDataReader[0];
            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
            return serviceTakenId;
        }

        public int GetTotalNumberOfService(long voterId)
        {
            string query = "SELECT COUNT(patient.voter_id) FROM tbl_service_taken serviceTaken" +
                           " JOIN tbl_patient patient ON patient.id = serviceTaken.patient_id" +
                           " WHERE patient.voter_id='" + voterId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();
            ASqlDataReader.Read();
            int totalNumberOfService = (int)ASqlDataReader[0];
            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
            return totalNumberOfService;
        }

        public DataTable GetData(long voterId)
        {
            DataTable aDataTable = new DataTable();
            string query = "SELECT * FROM v_patient_history WHERE voter_id = '" + voterId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);

            SqlDataAdapter aSqlDataAdapter = new SqlDataAdapter();
            ASqlCommand.CommandType = CommandType.Text;


            try
            {
                ASqlConnection.Open();
                aSqlDataAdapter.SelectCommand = ASqlCommand;
                aSqlDataAdapter.Fill(aDataTable);
                return aDataTable;
            }

            catch (Exception aException)
            {
                throw aException;
            }

            finally
            {
                ASqlConnection.Close();
                aSqlDataAdapter.Dispose();
                ASqlConnection.Dispose();
            }
        }

        public List<ViewPatientHistory> GetPatient(long voterId)
        {
            ASqlConnection.Open();
            string query = "SELECT * FROM v_patient_history WHERE voter_id = '" + voterId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlCommand.CommandType = CommandType.Text;
            ASqlDataReader = ASqlCommand.ExecuteReader();

            List<ViewPatientHistory> aViewPatientHistoryList = new List<ViewPatientHistory>();
            while (ASqlDataReader.Read())
            {
                ViewPatientHistory aViewPatientHistory = new ViewPatientHistory();
                aViewPatientHistory.VoterId = (long)ASqlDataReader["voter_id"];
                aViewPatientHistory.PatientId = (int)ASqlDataReader["patient_id"];
                aViewPatientHistory.CenterName = ASqlDataReader["name"].ToString();

                aViewPatientHistoryList.Add(aViewPatientHistory);
            }
            ASqlDataReader.Close();
            ASqlConnection.Close();
            return aViewPatientHistoryList;
        }
    }
}
