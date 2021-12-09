using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class MedicineManager
    {
        MedicineDBGateway aMedicineDBGateway = new MedicineDBGateway();
        CenterDBGateway aCenterGateway = new CenterDBGateway();

        public List<Medicine> GetAllMedicines()
        {
            return aMedicineDBGateway.GetAllMedicines();
        }

        public string SendMedicineToCenter(MedicineStockInCenter aMedicineStockInCenter)
        {
            if (aMedicineStockInCenter.CenterId!=0)
            {
                MedicineStockInCenter medicineStockInCenter = aCenterGateway.FindMedicineInCenter(aMedicineStockInCenter);

                if (medicineStockInCenter == null)
                {
                    aMedicineDBGateway.InsertInCenter(aMedicineStockInCenter);
                    return "Successfully Sent.";
                }
                else
                {
                    medicineStockInCenter.Quantity = aMedicineStockInCenter.Quantity;
                    aMedicineDBGateway.AddMedicineToCenter(medicineStockInCenter);
                    return "Successfully Sent.";
                }
            }
            else
            {
                return "Failed to send.";
            }
        }

        public void DeductMedicineFromCenter(MedicineStockInCenter aMedicineStockInCenter)
        {
            aMedicineDBGateway.DeductMedicineFromCenter(aMedicineStockInCenter);
        }

        public string SaveMedicine(Medicine aMedicine)
        {
            Medicine medicineFound = aMedicineDBGateway.Find(aMedicine.Name);
            if (medicineFound == null)
            {
                aMedicineDBGateway.SaveMedicine(aMedicine);
                return "Medicine Successfully Saved...!!!";
            }
            else
            {
                return "This medicine already exist";
            }
        }

        public Medicine Find(string name)
        {
            return aMedicineDBGateway.Find(name);
        }

        public List<Medicine> GetSelectedMedicines(int centerId)
        {
            return aMedicineDBGateway.GetSelectedMedicines(centerId);
        }
    }
}
