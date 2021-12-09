using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class DoctorManager
    {
        DoctorDBGateway aDoctorDbGateway = new DoctorDBGateway();
        public string SaveDoctor(Doctor aDoctor)
        {
            aDoctorDbGateway.SaveDoctor(aDoctor);
            return "Doctor Saved Successfully";
        }

        public List<Doctor> GetSelectedDoctors(int centerId)
        {
            return aDoctorDbGateway.GetSelectedDoctors(centerId);
        }
    }
}
