using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternDemo
{
    class Accessories:Decorator
    {
        public Accessories (Phone p) : base(p) { }

        public override void Print()
        {
            base.Print();
            AddAccessories();
        }

        private void AddAccessories()
        {
            Console.WriteLine("Now there is an Accessories for this phone");
        }
    }
}
