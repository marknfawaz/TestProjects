using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class DistrictAndThanaManager
    {
        DistrictAndThanaDBGateway aDistrictAndThanaGateway = new DistrictAndThanaDBGateway();

        public List<District> GetAllDistricts()
        {
            return aDistrictAndThanaGateway.GetAllDistricts();
        }

        public List<Thana> GetSelectedThanas(int districtId)
        {
            return aDistrictAndThanaGateway.GetSelectedThanas(districtId);
        }

        public District FindDistrict(string name)
        {
            return aDistrictAndThanaGateway.FindDistrict(name);
        }
    }
}
