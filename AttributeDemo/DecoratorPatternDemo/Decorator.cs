using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternDemo
{
    class Decorator : Phone
    {
        private Phone myPhone;
        public Decorator(Phone p)
        {
            myPhone = p;
        }
        public override void Print()
        {
            if(myPhone != null)
            {
                myPhone.Print();
            }
        }
    }
}
