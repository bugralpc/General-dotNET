using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Abstraction_2
{
    public abstract class AbstractClass1
    {
        public abstract void AbstractClass1Method1(); // declaration (signatures without any implementation)
    }

    public class AbstractClass1DerivedClass1 : AbstractClass1
    {
        public override void AbstractClass1Method1()
        {
            Console.WriteLine("This is DerivedClass1 ");
        }
    }

    public class AbstractClass1DerivedClass2 : AbstractClass1
    {
        public override void AbstractClass1Method1()
        {
            Console.WriteLine("This is DerivedClass2 ");
        }
    }

}
