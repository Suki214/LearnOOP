using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflector4DynamicInstance
{
    class Calculator
    {
        int x;
        int y;
        public Calculator()
        {
             x = 0;
             y = 0;
            Console.WriteLine("Calculator() invoked without params");
        }

        public Calculator(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("Calculator invoked with params x & y");
        }

        public int Add()
        {
            int total = x + y;
            Console.WriteLine("instance method: {0} plus {1} equals to {2}", x, y, total);
            return total;
        }

        public static void Add(int x, int y)
        {
            int total = x + y;
            Console.WriteLine("static method: {0} plus {1} equals to {2}", x, y, total);
        }
    }
}
