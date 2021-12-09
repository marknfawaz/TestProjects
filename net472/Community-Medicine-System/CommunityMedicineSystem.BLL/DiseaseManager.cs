using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class DiseaseManager
    {
        DiseaseDBGateway aDiseaseDbGateway = new DiseaseDBGateway();
        DistrictAndThanaDBGateway aDistrictAndThanaDbGateway = new DistrictAndThanaDBGateway();
        public int Save(Disease aDisease)
        {
            if (aDiseaseDbGateway.Find(aDisease.Name) == null)
            {
                return aDiseaseDbGateway.Save(aDisease);
            }
            else
            {
                return 0;
            }
        }

        public List<Disease> GetAllDiseases()
        {
            return aDiseaseDbGateway.GetAllDiseases();
        }

        public Disease Find(string name)
        {
            return aDiseaseDbGateway.Find(name);
        }

        public List<DiseaseReport> GetTotalPatientList(DateTime startDateTime, DateTime endDateTime, int diseaseId)
        {
            DiseaseReport aDiseaseReport = new DiseaseReport();
            List<DiseaseReport> diseaseReports = new List<DiseaseReport>();
            List<Patient> patients = aDiseaseDbGateway.GetTotalPatientList(startDateTime, endDateTime, diseaseId);
            int totalPatient = patients.Count;
            foreach (Patient aPatient in patients)
            {

                int population = aDistrictAndThanaDbGateway.GetDistrict(aPatient.DistrictId).Population;
                aDiseaseReport.TotalPatient = totalPatient;
                aDiseaseReport.PercentagePatient = GetPercentageOfPatient(totalPatient, population);
                aDiseaseReport.DistrictName = aDistrictAndThanaDbGateway.GetDistrict(aPatient.DistrictId).Name;
                diseaseReports.Add(aDiseaseReport);

            }
            return diseaseReports;
        }

        public double GetPercentageOfPatient(int totalPatient, int totalPopulation)
        {
            double a = ((totalPatient * 100) / totalPopulation);
            return a;
        }
    }
}
