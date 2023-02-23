using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Abstraction_1
{
    public abstract class Shape
    {
        // use the abstract "modifier" to declare abstract class.
        // the abstract "modifier" in a class declaration to indicate that a class is intended only to be a base class of other class.
        // the abstract class can not be instantiated on its own.
        // "sealed" modifier prevents a class from being inherited. "sealed" and "abstract" are opposite to each other.

        public abstract int GetArea(); // abstract method does not have body. abstract method is implicity a virtual method. 
    }

    public class Square : Shape // Square is a Shape relationship.
    {
        private int side;

        public Square(int side)
        {
            this.side = side;
        }

        // GetArea method is required
        public override int GetArea()
        {
            return side * side;
        }
    }

    
}
