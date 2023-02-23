using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Abstraction_1
{
    public abstract class Shape
    {
        public abstract int GetArea();
    }

    public class Square : Shape
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
