using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Web.Models
{
    public struct ValuesStruct
    {
        public int Id;
        public string Value;
        public void MyMethod()
        {
            Console.Write("This method doesnt do anything");
        }
    }
}
