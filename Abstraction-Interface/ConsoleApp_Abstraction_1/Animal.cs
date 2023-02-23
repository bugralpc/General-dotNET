using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Abstraction_1
{
    public abstract class Animal
    {
        public abstract void AnimalSound();

        // Abstract classes can have method which has body, Interface methods cannot have body
        public void Sleep()
        {
            Console.WriteLine("Zzzz...");
        }
    }


    public interface IAnimal
    {
        // interface is an abstract class, which can only has abstract methods and properties (with empty bodies)
        void Speed();
    }

    class Pig : Animal, IAnimal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("I am the Pig");
        }

        public void Speed()
        {
            Console.WriteLine("I am slow..");
        }
    }
}
