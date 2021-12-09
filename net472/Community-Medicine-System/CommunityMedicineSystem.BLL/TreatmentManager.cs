using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class TreatmentManager
    {
        TreatmentDBGateway aTreatmentDbGateway = new TreatmentDBGateway();

        public void SaveTreatment(Treatment aTreatment)
        {
            aTreatmentDbGateway.SaveTreatment(aTreatment);
        }
    }
}
