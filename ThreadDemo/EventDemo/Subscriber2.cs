using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Subscriber2
    {
        public void OnNumberChanged(int number)
        {
            throw new Exception("Subscriber 2 failed");
        }
    }
}
