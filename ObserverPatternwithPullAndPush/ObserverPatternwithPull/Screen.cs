using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternwithPull
{
    class Screen : IObserver
    {
        public void Update(IObservable observable)
        {
            //if(observable is Heater)
            //{
                Heater heater = (Heater)observable;
            //}

            if (heater.Temperature<100)
            {
                Console.WriteLine("Alarm: 当前水温{0}，快开了",heater.Temperature);
            }
            else
            {
                Console.WriteLine("Alarm: 当前水温{0}，水开了", heater.Temperature);
            }
        }
    }
}
