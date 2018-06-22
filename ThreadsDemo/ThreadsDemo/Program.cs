using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Main";
            Thread.CurrentThread.Name = name;
            Thread th = new Thread(ThreadEntry);
            th.Name = "Worker";
            th.Start();
            th.Interrupt();
            //th.Join(); //等待th结束以后执行后面的代码
            Console.WriteLine("{0} ended", name);

            //Console.WriteLine("------------Interrupt方法执行情况---------------");
            //Thread t1 = new Thread(DoWork);
            //t1.Start();
            //Thread.Sleep(1000);
            //t1.Interrupt();

            //t1.Join();

            //Console.WriteLine("------------Abort方法执行情况---------------");
            //Thread t2 = new Thread(DoWork);
            //t2.Start();
            //Thread.Sleep(1000);
            //t2.Abort();

            Console.ReadKey();

        }

        private static void ThreadEntry()
        {
            string name = Thread.CurrentThread.Name;
            try
            {
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} catch {1}", name, ex.GetType());
            }
            Console.WriteLine("{0} ended", name);
        }

        static void DoWork()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine("第 {0} 循环。", i);
                    Thread.Sleep(500);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine("第 {0} 循环中，线程被中断，下次循环线程将继续运行。", i);
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine("第 {0} 循环中，线程被终止，线程将不再继续运行", i);
                }
            }
        }
    }
}