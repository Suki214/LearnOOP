using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    public class Alarm
    {
        public void Activate()
        {
            Console.WriteLine("Activating the alarm");
        }

        public void Deactivate()
        {
            Console.WriteLine("Deactivating the alarm");
        }

        public void Ring()
        {
            Console.WriteLine("Ringing the alarm");
        }

        public void StopRing()
        {
            Console.WriteLine("Stop the alarm");
        }
    }
}
