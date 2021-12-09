using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicineSystem.DAO
{
    public class MedicineStockInCenter
    {
        public int Id { set; get; }
        public int CenterId { set; get; }
        public int MedicineId { set; get; }
        public int Quantity { set; get; }
    }
}
