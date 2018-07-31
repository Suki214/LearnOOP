using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SecurityFacade sf = new SecurityFacade();
            sf.Active();
            Console.ReadKey();
        }
    }
}
