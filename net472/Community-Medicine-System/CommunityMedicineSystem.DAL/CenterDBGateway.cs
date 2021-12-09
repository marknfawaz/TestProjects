using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class CenterDBGateway:CommonDBGateway
    {
        public List<Center> GetSelectedCenters(int thanaId)
        {
            List<Center> centerList = new List<Center>();
            string query = "SELECT * FROM tbl_center WHERE thana_id='" + thanaId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            while (ASqlDataReader.Read())
            {
                Center aCenter = new Center();
                aCenter.Id = (int)ASqlDataReader["id"];
                aCenter.Name = ASqlDataReader["name"].ToString();
                aCenter.DistrictId = (int)ASqlDataReader["district_id"];
                aCenter.ThanaId = (int)ASqlDataReader["thana_Id"];

                centerList.Add(aCenter);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();

            return centerList;
        }
        public Center GetCenter(int id)
        {
            ASqlConnection.Open();
            string query = "SELECT * FROM tbl_center where id = '" + id + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                Center aCenter = new Center();
                ASqlDataReader.Read();
                aCenter.Id = Convert.ToInt32(ASqlDataReader["id"]);
                aCenter.Name = ASqlDataReader["name"].ToString();
                aCenter.DistrictId = Convert.ToInt32(ASqlDataReader["district_id"]);
                aCenter.ThanaId = Convert.ToInt32(ASqlDataReader["thana_id"]);
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return aCenter;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return null;
            }
        }
        public List<ViewMedicineStockInCenter> GetMedicineStockInCenters(int centerId)
        {
            List<ViewMedicineStockInCenter> stockMedicineList = new List<ViewMedicineStockInCenter>();
            string query = "SELECT * FROM v_medicine_stock_report WHERE center_id='" + centerId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();
            

            while (ASqlDataReader.Read())
            {
                ViewMedicineStockInCenter aStockInCenter = new ViewMedicineStockInCenter();
                aStockInCenter.CenterId = (int)ASqlDataReader["center_id"];
                aStockInCenter.Name = ASqlDataReader["name"].ToString();
                aStockInCenter.Quantity = (int)ASqlDataReader["quantity"];


                stockMedicineList.Add(aStockInCenter);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();

            return stockMedicineList;
        }
        
        public MedicineStockInCenter FindMedicineInCenter(MedicineStockInCenter aMedicineStockInCenter)
        {
            string query = "SELECT * FROM tbl_medicine_stock_center WHERE medicine_id = '" + aMedicineStockInCenter.MedicineId + "' AND center_id='" + aMedicineStockInCenter.CenterId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                MedicineStockInCenter medicineStockInCenter = new MedicineStockInCenter();
                ASqlDataReader.Read();
                medicineStockInCenter.Id = (int)ASqlDataReader["id"];
                medicineStockInCenter.CenterId = (int)ASqlDataReader["center_id"];
                medicineStockInCenter.MedicineId = (int)ASqlDataReader["medicine_id"];
                medicineStockInCenter.Quantity = (int)ASqlDataReader["quantity"];

                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return medicineStockInCenter;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return null;
            }
        }

        public Center CheckCodePassword(Center aCenter)
        {
            string query = "SELECT * FROM tbl_center_login WHERE center_code = '" + aCenter.Code + "' AND password='" + aCenter.Password + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                Center bCenter = new Center();
                ASqlDataReader.Read();
                bCenter.Id = (int)ASqlDataReader["center_id"];
                bCenter.Code = ASqlDataReader["center_code"].ToString();
                bCenter.Password = ASqlDataReader["password"].ToString();


                ASqlDataReader.Close();
                ASqlConnection.Close();
                return bCenter;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return null;
            }
        }

        public int Save(Center aCenter)
        {
            string query = "INSERT INTO tbl_center VALUES ('" + aCenter.Name + "','" + aCenter.DistrictId + "','" +
                           aCenter.ThanaId + "')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            int rowAffected = ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
            return rowAffected;
        }

        public Center UniqueChecker(Center centerToBeChecked)
        {
            string query = "SELECT * FROM tbl_center WHERE name= '" + centerToBeChecked.Name + "' AND district_id='" +
                           centerToBeChecked.DistrictId + "'";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();
            if (ASqlDataReader.HasRows)
            {
                ASqlDataReader.Read();
                Center aCenter = new Center();
                aCenter.Name = ASqlDataReader["name"].ToString();
                aCenter.DistrictId = Convert.ToInt16(ASqlDataReader["district_id"]);
                aCenter.ThanaId = Convert.ToInt16(ASqlDataReader["thana_id"]);
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return aCenter;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return null;
            }
        }

        public List<Center> GetAllCenters()
        {
            string query = "SELECT * FROM tbl_center";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();
            List<Center> centers = new List<Center>();

            while (ASqlDataReader.Read())
            {
                Center aCenter = new Center();
                aCenter.Id = Convert.ToInt16(ASqlDataReader["id"]);
                aCenter.Name = ASqlDataReader["name"].ToString();
                aCenter.DistrictId = Convert.ToInt16(ASqlDataReader["district_id"]);
                aCenter.ThanaId = Convert.ToInt16(ASqlDataReader["thana_id"]);
                centers.Add(aCenter);
            }
            ASqlDataReader.Close();
            ASqlConnection.Close();
            return centers;
        }

        public void SaveCodeAndPassword(Center aCenter)
        {
            string query = "INSERT INTO tbl_center_login VALUES('" + aCenter.Id + "','" + aCenter.Code + "','" + aCenter.Password + "')";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlCommand.ExecuteNonQuery();
            ASqlConnection.Close();
        }

        public int Find(string name)
        {
            foreach (Center center in GetAllCenters())
            {
                if (center.Name == name)
                {
                    return center.Id;
                }
            }
            return 0;
        }

        public Center DisplayNewCenter(int id)
        {
            string query = "SELECT * FROM v_display_new_center WHERE id ='" + id + "'";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();
            if (ASqlDataReader.Read())
            {
                Center newCenter = new Center();
                newCenter.Name = ASqlDataReader["name"].ToString();
                newCenter.Code = ASqlDataReader["code"].ToString();
                newCenter.Password = ASqlDataReader["password"].ToString();
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return newCenter;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return null;
            }
        }

        public int FindCode(string code)
        {
            string query = "SELECT * FROM tbl_center_login WHERE center_code= '" + code + "'";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();
            if (ASqlDataReader.Read())
            {
                ASqlDataReader["center_code"].ToString();
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return 1;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return 0;
            }
        }

        public Center FindById(int centerId)
        {
            string query = "SELECT * FROM tbl_center WHERE id='" +centerId+ "'";
            ASqlConnection.Open();
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                Center aCenter =new Center();
                ASqlDataReader.Read();
                aCenter.Id = (int) ASqlDataReader["id"];
                aCenter.Name = ASqlDataReader["name"].ToString();
                aCenter.DistrictId = Convert.ToInt16(ASqlDataReader["district_id"]);
                aCenter.ThanaId = Convert.ToInt16(ASqlDataReader["thana_id"]);

                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return aCenter;
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
