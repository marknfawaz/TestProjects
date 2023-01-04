using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole
{
    public static class Shared
    {
        public static void Print(string s)
        {
            Console.WriteLine(new FSharpLib.Say().hello($"C# says '{s}'"));
        }
    }
}
