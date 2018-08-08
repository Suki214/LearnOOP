using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCallback
{
    public interface IBack
    {
        void Run();
    }

    public class CallBack : IBack
    {
        public void Run()
        {
            Console.WriteLine("Current Date Time is {0}", DateTime.Now);
        }
    }

    public class CallBackTwo : IBack
    {
        public void Run()
        {
            Console.WriteLine("Current Date Time is greater than {0}", DateTime.Now);
        }
    }
}
