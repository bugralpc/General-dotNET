using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Polymoprhism_2
{
    public class BaseClass
    {
        public virtual void DoWork()
        {
            Console.WriteLine("DoWork from Base Class");
        }

        public virtual int WorkProperty
        {
            get { return 0; }
        }
    }

    public class DerivedClass : BaseClass
    {
        public override void DoWork()
        {
            Console.WriteLine("DoWork from Derived Class");
        }

        public override int WorkProperty
        {
            get { return 1; }
        }
    }
}
