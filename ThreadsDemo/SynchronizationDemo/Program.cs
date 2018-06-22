using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationDemo
{
    class Program
    {
        //private Resource res = new Resource();
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Program p = new Program();
            Thread th = new Thread(p.ThreadEntry);
            th.Name = "Worker";
            th.Start();
            p.ThreadEntry();
            Console.ReadKey();
        }

        void ThreadEntry()
        {
            Resource.Record();
        }
    }
}
