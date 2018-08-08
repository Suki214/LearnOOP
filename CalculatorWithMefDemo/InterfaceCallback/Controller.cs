using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCallback
{
    public class Controller
    {
        public IBack callbackObj = null;
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
