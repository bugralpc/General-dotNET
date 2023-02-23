using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Polymoprhism_3
{
    public class Box
    {
        public double length;
        public double breadth;
        public double height;

        public Box() { }
        public Box(double length, double breadth, double height)
        {
            this.length = length;
            this.breadth = breadth;
            this.height = height;
        }

        public double GetVolume()
        {
            return (length * breadth * height);
        }

        // Overload + operator to add two Box objects // Static Polymorphism
        public static Box operator+(Box b1, Box b2)
        {
            Box box = new Box();
            
            box.length = b1.length + b2.length;
            box.breadth = b1.breadth + b2.breadth;
            box.height = b1.height + b2.height;
            return box;
        }
    }
}
