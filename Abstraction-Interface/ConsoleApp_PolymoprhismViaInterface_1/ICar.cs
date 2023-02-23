using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_PolymoprhismViaInterface_1
{
    public interface ICar
    {
        void Accelerate();
    }

    public class ElectricCarFromICar : ICar
    {
        public void Accelerate()
        {
            Console.WriteLine("Accelerating an electric car");
        }
    }

    public class PetrolCarFromICar : ICar
    {
        public void Accelerate()
        {
            Console.WriteLine("Accelerating a petrol car");
        }
    }
}
