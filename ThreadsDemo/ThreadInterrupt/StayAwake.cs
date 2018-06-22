using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadInterrupt
{
    class StayAwake
    {
        bool sleepSwitch = false;

        public bool SleepSwitch
        {
            set { sleepSwitch = value; }
        }

        public StayAwake() { }

        public void ThreadMethod()
        {
            Console.WriteLine("newThread is executing ThreadMethod");

            while (!sleepSwitch)
            {
                Thread.SpinWait(10000000);
            }
            try
            {
                Console.WriteLine("newThread is going to sleep");
            }
            catch(ThreadInterruptedException ex)
            {
                Console.WriteLine("newThread cannot goto sleep - interruptted by main thread");
            }
        }
    }
}
