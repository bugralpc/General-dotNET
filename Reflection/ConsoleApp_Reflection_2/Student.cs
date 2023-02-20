using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Reflection_2
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student()
        {
            Id = 0;
            Name = String.Empty;
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void DisplayData()
        {
            Console.WriteLine("Id : " + Id + " / Name : " + Name);
        }

        public string SayHello(string name)
        {
            return "Hello " + name;
        }

        public void MultiParameterMethod(string name, string surname, int age)
        {
            Console.WriteLine("OK");
        }
    }
}
