namespace ConsoleApp_Abstraction_1
{
    internal class Program
    {

        // Abstraction is the process of hiding certain details and showing only essential information to user.
        // Abstraction can be achieved with either abstract class or interfaces
        // Abstraction can also be achived by using interfaces

        // Abstract class can not be instantiated (you cannot create object), to access it, it must be inherited from another class
        // Abstract method can only be in abstract class, it does not have a body. Derived class must fill it.
        static void Main(string[] args)
        {
            // Animal animal = new Animal() // you cannot create an instance of abstract object

            Pig pig = new Pig();

            pig.AnimalSound();
            pig.Sleep();

            Console.WriteLine("-----------");

            Square square = new Square(9);

            Console.WriteLine("Area of square : {0}", square.GetArea());

        }
    }
}