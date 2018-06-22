using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorDemo
{
    class Program
    {
        private Resource res = new Resource();
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Program p = new Program();
            Thread th = new Thread(p.ThreadEntry);
            th.Name = "Worker";
            th.Start();
            Thread.Sleep(100);
            lock (p.res)
            {
                //此IF语句相当重要，因为如果此时Data已经被赋值，并执行了Pulse()方法，
                //此时主线程再去执行Wait(),那他永远也等不到这个信号量

                //解决办法，使用Wait的重载方法，定一个超时时间
                //if(string.IsNullOrEmpty(p.res.Data))
                //{
                bool isTimeout = Monitor.Wait(p.res, 2000);//超时返回false
                //Monitor.Wait(p.res);
                ////}
                Console.WriteLine("IsTimeout={0}", isTimeout);
                Console.WriteLine("Data={0}", p.res.Data);
            }
            Console.ReadKey();
        }
        void ThreadEntry()
        {
            // this lock is neccessary, or it will raise error:
            //System.Threading.SynchronizationLockException: 
            //'Object synchronization method was called from an unsynchronized block of code.'
            lock (res)
            {
                res.Data = "Retrived";
                Monitor.Pulse(res);
                //Monitor.PulseAll(res);//用于多个线程等待同一个数据
            }
        }
    }
}
