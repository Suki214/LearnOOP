using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Turn on light");
        }

        public void TurnOff()
        {
            Console.WriteLine("Turn off light");
        }

        public void ChangeBulb()
        {
            Console.WriteLine("Changing the light-bulb");
        }
    }
}
