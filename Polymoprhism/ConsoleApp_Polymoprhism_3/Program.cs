namespace ConsoleApp_Polymoprhism_3
{
    internal class Program
    {
        // Polymorphisim can be static or dynamic.
        // In static polymorphism, the response to a function is determined at the compile time. 
        // In dynamic polymorphism, it is decided at run-time
         
        // Static Polymorphism
        // Method Overloading, Operator Overloading

        static void Main(string[] args)
        {
            // Static Polymorphism
            StaticPolymorphismClass staticPolymorphismClass = new StaticPolymorphismClass();

            // In here, a method Print() can be seen in many forms Int, Double, Float, String...
            // Method overloading is a static Polymorphism
            staticPolymorphismClass.Print(101);
            staticPolymorphismClass.Print(101.101);
            staticPolymorphismClass.Print("sauron");

            // Static Polymorphism
            // Operator overloading is a static Polymorphism
            Box b1 = new Box(10, 10, 10);
            Box b2 = new Box(10, 10, 10);

            Box b3 = b1 + b2;

            Console.WriteLine(b3.GetVolume());




            // Dynamic Polymorphism
            // Throughout Inheritance, when a class is declared as sealed, it cannot be inherited
            List<Shape> list = new List<Shape>()
            {
                new Rectangle(10, 50),
                new Square(10)
            };

            // In here shape object (from base class) can be seen in many forms Rectangle and Square
            foreach(Shape shape in list)
            {
                Console.WriteLine("Area: " + shape.Area());
            }

        }
    }
}