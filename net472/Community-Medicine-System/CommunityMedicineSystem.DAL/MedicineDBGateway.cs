using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class MedicineDBGateway:CommonDBGateway
    {
        CenterDBGateway aCenterDbGateway = new CenterDBGateway();
        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicineList = new List<Medicine>();
            string query = "SELECT * FROM tbl_medicine";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            while (ASqlDataReader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int)ASqlDataReader["id"];
                aMedicine.Name = ASqlDataReader["name"].ToString();
                aMedicine.Power = Convert.ToDecimal(ASqlDataReader["power"]);
                aMedicine.Type = ASqlDataReader["type"].ToString();

                medicineList.Add(aMedicine);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
            return medicineList;
        }

        public void InsertInCenter(MedicineStockInCenter aMedicineStockInCenter)
        {
            string query = "INSERT INTO tbl_medicine_stock_center VALUES('" + aMedicineStockInCenter.CenterId + "', '" + aMedicineStockInCenter.MedicineId + "', '" + aMedicineStockInCenter.Quantity + "')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);

            ASqlCommand.ExecuteNonQuery();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
        }

        public List<Medicine> GetSelectedMedicines(int centerId)
        {
            List<Medicine> medicineList = new List<Medicine>();
            string query = "SELECT * FROM tbl_medicine med JOIN tbl_medicine_stock_center med_stock ON med.id = med_stock.medicine_id WHERE med_stock.center_id='" +centerId+ "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            while (ASqlDataReader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int)ASqlDataReader["id"];
                aMedicine.Name = ASqlDataReader["name"].ToString();
                aMedicine.Power = Convert.ToDecimal(ASqlDataReader["power"]);
                aMedicine.Type = ASqlDataReader["type"].ToString();

                medicineList.Add(aMedicine);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
            return medicineList;
        }

        public void AddMedicineToCenter(MedicineStockInCenter aMedicineStockInCenter)
        {
            string query = "UPDATE tbl_medicine_stock_center SET quantity +='" + aMedicineStockInCenter.Quantity + "' WHERE id='" + aMedicineStockInCenter.Id + "'";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);

            ASqlCommand.ExecuteNonQuery();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
        }

        public void DeductMedicineFromCenter(MedicineStockInCenter aMedicineStockInCenter)
        {
            MedicineStockInCenter medicineStockInCenter = aCenterDbGateway.FindMedicineInCenter(aMedicineStockInCenter);
            if (medicineStockInCenter.Quantity >= aMedicineStockInCenter.Quantity)
            {
                string query = "UPDATE tbl_medicine_stock_center SET quantity -='" + aMedicineStockInCenter.Quantity +
                               "' WHERE center_id='" + aMedicineStockInCenter.CenterId + "' AND medicine_id='" +
                               aMedicineStockInCenter.MedicineId + "'";
                ASqlConnection.Open();
                ASqlCommand = new SqlCommand(query, ASqlConnection);

                ASqlCommand.ExecuteNonQuery();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
            }
        }

        public void SaveMedicine(Medicine aMedicine)
        {
            ASqlConnection.Open();
            string query = "INSERT INTO tbl_medicine VALUES('" + aMedicine.Name + "','" + aMedicine.Power + "','" + aMedicine.Type + "')";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
        }

        public Medicine Find(string name)
        {
            string query = "SELECT * FROM tbl_medicine WHERE name='" + name + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                Medicine aMedicine = new Medicine();
                ASqlDataReader.Read();
                aMedicine.Id = (int)ASqlDataReader["id"];
                aMedicine.Name = ASqlDataReader["name"].ToString();
                aMedicine.Power = Convert.ToDecimal(ASqlDataReader["power"]);
                aMedicine.Type = ASqlDataReader["type"].ToString();

                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return aMedicine;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return null;
            }
        }
    }
}
