using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventDemo
{
    public delegate int AddDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client application start!\n");
            Thread.CurrentThread.Name = "Main thread";

            Calculator cal = new Calculator();
            AddDelegate addDelegate = new AddDelegate(cal.Add);
            IAsyncResult asyncResult = addDelegate.BeginInvoke(2, 5,null,null);//这里需要保留IAsyncResult，以便调用EndInvoke的时候进行传递
            //BeginInvoke(int x, int y, AsyncCallback callback, object @object)

            for (int i=1;i<=3; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Client executed {1} second(s).",Thread.CurrentThread.Name, i);
            }

            int rtn = addDelegate.EndInvoke(asyncResult);//调用EndInvoke，得到返回值
            Console.WriteLine("Result: {0}", rtn);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();            
        }
    }

    internal class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        
    }
}
