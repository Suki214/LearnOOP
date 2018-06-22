using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationDemo
{
    public static class Resource
    {
        public static string Called;
        //private readonly Object obj = new object();
        //public static void Record()
        //{
        //lock (typeof(Resource))
        //{
        //    Called += string.Format("{0}[{1}]", Thread.CurrentThread.Name, DateTime.Now.Millisecond);
        //    Console.WriteLine(Called);
        //}         
        //}

        //等价于以下代码：
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Record()
        {
            Called += string.Format("{0}[{1}]", Thread.CurrentThread.Name, DateTime.Now.Millisecond);
            Console.WriteLine(Called);
        }
    }
}
