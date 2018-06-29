using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaterWithinConsole
{
    class Alerter
    {
        public void MakeAlert( object sender, BoiledEventArgs e)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", e.temperature);
        }
    }
}
