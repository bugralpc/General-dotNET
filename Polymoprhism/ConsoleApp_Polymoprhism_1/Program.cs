namespace ConsoleApp_Polymoprhism_1
{
    // URLs
    // https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/polymorphism
    internal class Program
    {
        // In C#, every type is polymorphic because all types, including user-defined types, inherit from Object.

        // Polymorphism is third-pillar of oop after encapsulation and inheritance

        // At run time, objects of a derived class may be treated as objects of a base class in places such as
        // method parameters and collections or arrays.
        static void Main(string[] args)
        {
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            // the virtual method Draw is invoked on each of the derived class, not the base class.
            foreach(var shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}