using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DeadLockDemo
{
    class Program
    {
        private Resource mainRes = new Resource() { Data = "MainRes" };
        private Resource workerRes = new Resource() { Data = "WorkerRes" };
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Program p = new Program();
            Thread th = new Thread(p.T2);
            th.Name = "Worker";
            th.Start();
            T1(p);
            Console.ReadKey();
            //Result
            //Worker: tried three time, dealock
            //Main: tried three time, dealock
        }
        private static void T1(Program p)
        {
            lock (p.mainRes)
            {
                Thread.Sleep(10);//add this, 必然死锁
                lock (p.workerRes)
                {
                    Console.WriteLine(p.workerRes.Data);
                }

                //使用Monitor.TryEnter(),not like Monitor.Enter, it will not always waiting for that, it will return immediately
                //this demo will try triple, then it will return when failed.
                //Thread.Sleep(10);
                //int i = 0;
                //while (i < 3)
                //{
                //    if (Monitor.TryEnter(p.workerRes))
                //    {
                //        Console.WriteLine(p.workerRes.Data);
                //        Monitor.Exit(p.workerRes);
                //    }
                //    else
                //    {
                //        Thread.Sleep(1000);//try again 1 minute later
                //    }
                //    i++;
                //    if (i == 3)
                //    {
                //        Console.WriteLine("{0}: tried three time, dealock", Thread.CurrentThread.Name); ;
                //    }
                //}
            }
        }
        private void T2()
        {
            lock (mainRes)
            {
                Thread.Sleep(10);//add this, 必然死锁
                lock (workerRes)
                {
                    Console.WriteLine(mainRes.Data);
                }

                //int i = 0;
                //while (i < 3)
                //{
                //    if (Monitor.TryEnter(mainRes))
                //    {
                //        Console.WriteLine(mainRes.Data);
                //        Monitor.Exit(mainRes);
                //    }
                //    else
                //    {
                //        Thread.Sleep(1000);//try again 1 minute later
                //    }
                //    i++;
                //    if (i == 3)
                //    {
                //        Console.WriteLine("{0}: tried three time, dealock", Thread.CurrentThread.Name); ;
                //    }
                //}
            }
        }
    }
}
