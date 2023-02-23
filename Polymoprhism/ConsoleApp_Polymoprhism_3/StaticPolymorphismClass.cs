using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Polymoprhism_3
{
    public class StaticPolymorphismClass
    {
        public void Print(int i)
        {
            Console.WriteLine("Printing int: " + i);
        }

        public void Print(double f)
        {
            Console.WriteLine("Printing float: " + f);
        }

        public void Print(string s)
        {
            Console.WriteLine("Printing string: " + s);
        }
    }
}
