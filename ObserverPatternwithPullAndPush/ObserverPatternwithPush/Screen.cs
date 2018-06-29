using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternwithPush
{
    class Screen : IObserver
    {
        private bool isDisplayed = false;
        public void Update(SubjectEventArgs e)
        {
            if (!isDisplayed)
            {
                Console.WriteLine("Area is {0}", e.Area);
                isDisplayed = true;
            }

            if (e.Temperature<100)
            {
                Console.WriteLine("Alarm: 当前水温{0}，快开了",e.Temperature);
            }
            else
            {
                Console.WriteLine("Alarm: 当前水温{0}，水开了", e.Temperature);
            }
        }
    }
}
