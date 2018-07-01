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
            Customer c1= new Customer(){Revene = 1};
            Customer c2= new Customer(){Revene = 2};

            int result= c1.CompareTo( c2 );

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
