using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicineSystem.DAO
{
    public class Medicine
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public decimal Power { set; get; }
        public string Type { set; get; }

        public override string ToString()
        {
            return Name + ", " +Power+ Type;
        }
    }
}
