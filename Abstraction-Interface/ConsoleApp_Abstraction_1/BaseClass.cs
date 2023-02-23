using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Abstraction_1
{
    abstract class BaseAbstractClass
    {
        // abstract class field
        protected int _x = 50;
        protected int _y = 51;

        // abstract method
        public abstract void AbstractMethod1();

        // abstract properties, properties shoudl have get or set methods, or both
        public abstract int X { get; }
        public abstract int Y { get; }
    }

    class DerivedClass1 : BaseAbstractClass
    {
        public override void AbstractMethod1()
        {
            _x++;
            _y++;
        }
        public override int X
        { 
            get 
            { 
                return _x; 
            } 
        }

        public override int Y
        { 
            get 
            { 
                return _y; 
            } 
        }
    }
}
