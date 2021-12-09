using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicineSystem.DAO
{
    public class Patient
    {
        public int Id { set; get; }
        public long VoterId { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public int Age { set; get; }
        public int DistrictId { set; get; }
    }
}
