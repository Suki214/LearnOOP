using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass d = new MyDerivedClass();
            d.Message();
            IMsg m = d as IMsg;
            m.Message();
            MyClass myClass = d;
            myClass.Message();
            Console.ReadKey();
            //Result:
            //MyDerivedClass
            //MyDerivedClass
            //MyDerivedClass
        }
    }
}
