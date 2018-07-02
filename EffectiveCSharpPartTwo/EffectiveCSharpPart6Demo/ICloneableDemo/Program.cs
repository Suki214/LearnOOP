using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICloneableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedType dt= new DerivedType();
            DerivedType d2 = dt.Clone() as DerivedType;//clone return the base type
            var d3 = dt.Clone();//clone return the base type
            Console.WriteLine(d2);
            Console.WriteLine(d3);
            if ( d2 is null )
            {
                Console.WriteLine("d2 is null");
            }

            Console.ReadKey();

        }
    }
}
