using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWithExplicit
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.DoSomething();
            myClass.DoElse();
            IMyInterface myInterface = myClass;
            myInterface.DoElse();//this must be called with interface
            myInterface.DoSomething();
            Console.ReadKey();
        }
    }
}
