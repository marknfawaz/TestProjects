using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TestFrameworkNPOIExcel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWorkbook workbook = new XSSFWorkbook();
            IWorkbook workbook2 = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("My sheet");
        }
    }
}
