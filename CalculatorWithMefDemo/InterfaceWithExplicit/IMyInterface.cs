using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWithExplicit
{
    interface IMyInterface
    {
        void DoSomething();
        void DoElse();
    }

    public class MyClass : IMyInterface
    {
        void IMyInterface.DoElse()
        {
            Console.WriteLine("DoSomethingElse");
        }

        public void DoElse()
        {
            Console.WriteLine("DoSomethingElse in class");
        }

        public void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }
    }
}
