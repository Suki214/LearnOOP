using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternDemo
{
    class Sticker : Decorator
    {
        public Sticker(Phone p) : base(p){}

        public override void Print()
        {
            base.Print();
            AddSticker();
        }

        private void AddSticker()
        {
            Console.WriteLine("There is now a sticker for this phone");
        }
    }
}
