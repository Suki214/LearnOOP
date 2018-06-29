using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaterWithinConsole
{
    
    public delegate void TemperatrueWarningEventHandler(object sender, BoiledEventArgs eventArgs);

    public class BoiledEventArgs:EventArgs
    {
        public int temperature;
        public BoiledEventArgs (int _temperature)
        {
            temperature = _temperature;
        }
    }

    class Heater
    {
        public event TemperatrueWarningEventHandler TemperatrueWarning;
        private int temperature;
        public string htype = "RealFire 001";
        public string harea = "China Xian";

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
            }
        }

        public void BoilWater()
        {
            for (int i = 1; i <= 100; i++)
            {
                temperature = i;
                if (i > 95)
                {
                    BoiledEventArgs e = new BoiledEventArgs(i);
                    OnTemperatrueWarning(e);
                  
                }
            }
        }

        private void OnTemperatrueWarning(BoiledEventArgs e)
        {
            if (TemperatrueWarning != null)
            {
                TemperatrueWarning(this, e);
            }
        }
    }



    public delegate void GeneralEventHandler();
    // 定义事件发布者
    public class Publishser
    {
        private event GeneralEventHandler NumberChanged; // 声明一个私有事件
                                                         // 注册事件
        public void Register(GeneralEventHandler method)
        {
            NumberChanged = method;//使用“+”而不是“+=”，就避免了多个方法注册
        }
        // 取消注册
        public void UnRegister(GeneralEventHandler method)
        {
            NumberChanged -= method;
        }
        public void DoSomething()
        {
            // 做某些其余的事情
            if (NumberChanged != null)
            { // 触发事件
                string rtn = NumberChanged();
                Console.WriteLine("Return: {0}", rtn); // 打印返回的字符串，输出为}
            }
        }
    }
