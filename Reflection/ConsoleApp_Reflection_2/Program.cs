using System.Reflection;

namespace ConsoleApp_Reflection_2
{
    public class Program
    {
        private static string line = "------------------------------------------------------------------------------";

        static void Main(string[] args)
        {

            // How to get type of an Class
            Type t = typeof(String);

            Console.WriteLine("Type info of String class");
            Console.WriteLine("Type of object : {0}", t);
            Console.WriteLine("Name : {0}", t.Name);
            Console.WriteLine("Full Name : {0}", t.FullName);
            Console.WriteLine("Namespace : {0}", t.Namespace);
            Console.WriteLine("Base Type : {0}", t.BaseType);
            Console.WriteLine();

            // How to get Details loaded assembly
            Assembly info = typeof(String).Assembly;

            Console.WriteLine("Assembly info of String class");
            Console.WriteLine(info);

            Console.WriteLine(line);

            // You can create objects from type of class.

            // Create instance of class Person with parameterless constructor
            Type type1 = typeof(Person);

            Person person1 = (Person)Activator.CreateInstance(type1);

            // Create instance of class Person with constructor by Reflection
            Person person2 = (Person)Activator.CreateInstance(type1, "Sauron", 2000);

            person2.Info();

            Console.WriteLine(line);

            // We use reflection to show all the metadata related to the program which includes classes, methods and properties
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Store types in assembly
            Type[] types = assembly.GetTypes();

            for(int i = 3; i < types.Length; i++)   
            //foreach(Type type in types)
            {
                Type type = types[i];
                // Display each type
                Console.WriteLine("Class : {0}", type.Name);

                // Store methods of each type(class)
                MethodInfo[] methods = type.GetMethods();

                foreach(MethodInfo method in methods)
                {
                    Console.WriteLine("--> Method : {0}", method.Name);

                    // Store parameters of each method
                    ParameterInfo[] parameters = method.GetParameters();

                    foreach(ParameterInfo param in parameters)
                    {
                        Console.WriteLine("----> Parameter : {0} Type : {1}", param.Name, param.ParameterType);
                    }
                }

            }


        }
    }
}