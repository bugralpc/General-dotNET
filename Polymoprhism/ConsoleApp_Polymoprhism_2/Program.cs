namespace ConsoleApp_Polymoprhism_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DerivedClass derivedClassObj = new DerivedClass();
            derivedClassObj.DoWork(); // Calls the overrided method.
            Console.WriteLine(derivedClassObj.WorkProperty); // Calls the overrided property

            BaseClass baseClassObj2 = derivedClassObj;
            baseClassObj2.DoWork(); // Calls the overrided method.
            Console.WriteLine(baseClassObj2.WorkProperty); // Calls the overrided property

            BaseClass baseClassObj1 = new BaseClass();
            baseClassObj1.DoWork();
            Console.WriteLine(baseClassObj1.WorkProperty);
        }
    }
}