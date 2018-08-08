using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCallback
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller(new CallBack());
            Controller controller2 = new Controller(new CallBackTwo());
            controller.Star();
            controller2.Star();
            Console.ReadKey();
        }
    }
}
