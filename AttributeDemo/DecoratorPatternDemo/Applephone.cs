using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternDemo
{
    class Applephone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("This is an Iphone");
        }
    }
}
