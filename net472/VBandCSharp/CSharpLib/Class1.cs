using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VBLib;

namespace CSharpLib
{
    public class Class1
    {
        public static void CSharpLib()
        {
            Console.WriteLine("Hello from C# Lib");
            Console.WriteLine("Json: " + JsonConvert.SerializeObject(new {Foo = "bar"}));

            new ClassVB().VBLib();

            Console.ReadLine();
        }
    }
}
