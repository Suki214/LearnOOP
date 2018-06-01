using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Alarm : IObserver
    {
        
        public void Update()
        {

            Console.WriteLine("The water is about boiled, watch out...");
        }
    }
}
