namespace ConsoleApp_Abstraction_2
{
    internal class Program
    {
        private static String separatorLine = new String('-', 20);
        static void Main(string[] args)
        {
            // You cannot create an instance of an Abstract Class from an Abstract Class.
            //AbstractClass1 abstractClass1Obj = new AbstractClass1(); // --> Error: Cannot create an instance of the abstract type or interface.

            // Yet you can create an instance of an Abstract Class from a derived class, best explanation could be found in C++ pointer content.
            AbstractClass1 abstractClass1Obj1 = new AbstractClass1DerivedClass1();
            AbstractClass1 abstractClass1Obj2 = new AbstractClass1DerivedClass2();

            abstractClass1Obj1.AbstractClass1Method1();
            abstractClass1Obj2.AbstractClass1Method1();

            // ----------------------------------------------------------------------------------------------- //
            Console.WriteLine(separatorLine);

            // Also you can create a list with type an Abstract Class.
            List<AbstractClass1> abstractClass1List = new List<AbstractClass1>();

            abstractClass1List.Add(new AbstractClass1DerivedClass1());
            abstractClass1List.Add(new AbstractClass1DerivedClass2());

            foreach(AbstractClass1 abstractClass1Obj in abstractClass1List)
            {
                abstractClass1Obj.AbstractClass1Method1();
            }

            // ----------------------------------------------------------------------------------------------- //
            Console.WriteLine(separatorLine);

            // You cannot create an instance of an Interface from an Interface
            //Interface1 interface1Obj = new Interface1(); // --> Error: Cannot create an instance of the abstract type of interface.

            // Yet you can create an instance of an Interface from a derived class, best explanation could be found in C++ pointer content.
            Interface1 interface1Obj1 = new Interface1DerivedClass1();
            Interface1 interface1Obj2 = new Interface1DerivedClass2();

            interface1Obj1.Interface1Method1();
            interface1Obj2.Interface1Method1();

            // ----------------------------------------------------------------------------------------------- //
            Console.WriteLine(separatorLine);

            // Also you can create a list with type an Interface
            List<Interface1> interface1List = new List<Interface1>();

            interface1List.Add(new Interface1DerivedClass1());
            interface1List.Add(new Interface1DerivedClass2());

            foreach(Interface1 interface1Obj in interface1List)
            {
                interface1Obj.Interface1Method1();
            }
        }
    }
}