using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaterWithinConsole
{
    class Display
    {
        public void ShowMsg(object sender, BoiledEventArgs e )
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("{0} - {1}", heater.harea, heater.htype);
            Console.WriteLine("Display：水快开了，当前温度：{0}度。", e.temperature);
        }
    }
}
