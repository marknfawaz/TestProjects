using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class DoctorDBGateway : CommonDBGateway
    {
        public void SaveDoctor(Doctor aDoctor)
        {
            ASqlConnection.Open();
            string query = "INSERT INTO tbl_doctor VALUES('" + aDoctor.Name + "','" + aDoctor.Degree + "','" + aDoctor.Specialization + "','" + aDoctor.CenterId + "') ";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
        }

        public List<Doctor> GetSelectedDoctors(int centerId)
        {
            List<Doctor> doctorList = new List<Doctor>();
            string query = "SELECT * FROM tbl_doctor WHERE center_id='" +centerId+ "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();
            Doctor aDoctor;

            while (ASqlDataReader.Read())
            {
                aDoctor = new Doctor();
                aDoctor.Id = (int) ASqlDataReader["id"];
                aDoctor.Name = ASqlDataReader["name"].ToString();
                aDoctor.Degree = ASqlDataReader["degree"].ToString();
                aDoctor.Specialization = ASqlDataReader["specialization"].ToString();
                aDoctor.CenterId = (int) ASqlDataReader["center_id"];

                doctorList.Add(aDoctor);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
            return doctorList;
        }
    }
}
