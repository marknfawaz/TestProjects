using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new FSharpLib.Say().hello("from C#"));

            Console.ReadLine();
        }
    }
}
