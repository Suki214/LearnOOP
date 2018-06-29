using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaterWithinConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alerter alerter = new Alerter();
            Display display = new Display();

            heater.TemperatrueWarning += alerter.MakeAlert;
            heater.TemperatrueWarning += display.ShowMsg;

            heater.BoilWater();

            Console.ReadKey();

        }
    }
}
