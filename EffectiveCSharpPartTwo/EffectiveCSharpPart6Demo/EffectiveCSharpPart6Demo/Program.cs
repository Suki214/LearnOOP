using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveCSharpPart6Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1= new Customer(){Revene = 3,Name = "C1"};
            Customer c2= new Customer(){Revene = 2,Name = "C2"};

            int resultc= c1.CompareTo( c2 );

            int resultr = c1.Revene.CompareTo( c2.Revene );

            Console.WriteLine(resultc.ToString() +resultr.ToString());
            Console.ReadKey();
        }
    }
}
