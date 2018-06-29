using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Subscriber3
    {
        public void OnNumberChanged(int number)
        {
            Console.WriteLine("Count is {0}", number);
        }
    }
}
