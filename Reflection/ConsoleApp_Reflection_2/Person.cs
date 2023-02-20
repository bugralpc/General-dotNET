using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Reflection_2
{
    public class Person
    {
        public string name = "";
        public int age;

        public Person() { } // Parameterless constructor

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Info()
        {
            Console.WriteLine(name + " is " + age + " years old.");
        }
    }
}
