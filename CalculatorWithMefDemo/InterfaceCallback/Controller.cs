using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCallback
{
    public class Controller
    {
        public IBack callbackObj = null;//使用IBack作为接口的好处就是，所有实现了IBack的callback object都可以实现回调，而不用修改controller类
        public Controller(IBack back)
        {
            callbackObj = back;
        }

        public void Star()
        {
            Console.WriteLine("Click keybord to show current time, until user key in Esc button");
            while (Console.ReadKey(true).Key!=ConsoleKey.Escape){
                callbackObj.Run();
            }
        }

    }
}
