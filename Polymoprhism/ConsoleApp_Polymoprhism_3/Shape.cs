using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Polymoprhism_3
{
    // Classical "Shape" Abstract Class example on internet...
    public abstract class Shape
    {
        public abstract int Area();
    }

    public class Rectangle : Shape
    {
        private int length;
        private int width;

        public Rectangle(int length, int width   )
        {
            this.length = length;
            this.width = width;
        }

        public override int Area()
        {
            return length * width;
        }
    }

    public class Square : Shape
    {
        private int side;
        
        public Square(int side)
        {
            this.side = side;
        }

        public override int Area()
        {
            return side * side;
        }
    }


}
