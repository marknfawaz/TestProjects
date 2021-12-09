using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class DistrictAndThanaDBGateway : CommonDBGateway
    {
        public List<District> GetAllDistricts()
        {
            List<District> districtList = new List<District>();

            string query = "SELECT * FROM tbl_district";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            while (ASqlDataReader.Read())
            {
                District aDistrict = new District();
                aDistrict.Id = (int)ASqlDataReader["id"];
                aDistrict.Name = ASqlDataReader["name"].ToString();

                districtList.Add(aDistrict);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();

            return districtList;
        }

        public List<Thana> GetSelectedThanas(int districtId)
        {
            List<Thana> thanaList = new List<Thana>();

            string query = "SELECT * FROM tbl_thana WHERE district_id='" + districtId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();
            Thana aThana;

            while (ASqlDataReader.Read())
            {
                aThana = new Thana();
                aThana.Id = (int)ASqlDataReader["id"];
                aThana.Name = ASqlDataReader["name"].ToString();
                aThana.DistrictId = (int)ASqlDataReader["district_id"];

                thanaList.Add(aThana);
            }

            ASqlDataReader.Close();
            ASqlCommand.Dispose();
            ASqlConnection.Close();
            return thanaList;
        }

        public District FindDistrict(string name)
        {
            string query = "SELECT * FROM tbl_district WHERE name='" + name + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                District aDistrict = new District();
                ASqlDataReader.Read();
                aDistrict.Id = (int) ASqlDataReader["id"];
                aDistrict.Name = ASqlDataReader["name"].ToString();
                aDistrict.Population = (int) ASqlDataReader["population"];

                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return aDistrict;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlCommand.Dispose();
                ASqlConnection.Close();
                return null;
            }
        }

        public District GetDistrict(int districtId)
        {
            string query = "SELECT * FROM tbl_district WHERE id='" + districtId + "'";
            ASqlCommand = new SqlCommand(query, ASqlConnection);
            ASqlConnection.Open();
            ASqlDataReader = ASqlCommand.ExecuteReader();

            if (ASqlDataReader.HasRows)
            {
                ASqlDataReader.Read();
                District aDistrict = new District();
                aDistrict.Id = Convert.ToInt16(ASqlDataReader["id"]);
                aDistrict.Population = Convert.ToInt32(ASqlDataReader["population"]);
                aDistrict.Name = ASqlDataReader["name"].ToString();
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return aDistrict;
            }
            else
            {
                ASqlDataReader.Close();
                ASqlConnection.Close();
                return null;
            }

        }
    }
}
