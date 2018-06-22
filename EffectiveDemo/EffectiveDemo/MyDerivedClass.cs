using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveDemo
{
    class MyDerivedClass:MyClass
    {
        public override void ShowMessage()
        {
            Console.WriteLine("MyDerivedClass");
        }
    }
}
