using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_PolymoprhismViaInterface_1
{
    public class Car
    {
        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating an unknown car");
        }
    }

    public class ElectricCarFromCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating an electric car");
        }
    }

    public class PetrolCarFromCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a petrol car");
        }
    }
}
