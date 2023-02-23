using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Abstraction_2
{
    public interface Interface1
    {
        // define behaviour for multiple types
        // an interface defines a contract, any class or struct that "contract" must implement the members defined in it.
        void Interface1Method1(); // declaration (signatures without any implementation)
    }

    public class Interface1DerivedClass1 : Interface1
    {
        public void Interface1Method1()
        {
            Console.WriteLine("This is: " + this.GetType().Name);
        }
    }

    public class Interface1DerivedClass2 : Interface1
    {
        public void Interface1Method1()
        {
            Console.WriteLine("This is: " + this.GetType().Name);
        }
    }
}
