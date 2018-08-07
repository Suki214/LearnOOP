using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandPatternDemo
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Receiver r = new Receiver();
        //    Command c = new ConcreteCommand(r);
        //    Invoke i = new Invoke(c);
        //    i.ExecuteCommand();
        //    Console.ReadKey();
        //}

        //public static void Main()
        //{
        //    try
        //    {
        //        new Thread(Go).Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        // 永远执行不到这儿！
        //        Console.WriteLine("Exception!");
        //    }
        //}

        //private static void Go()
        //{
        //    throw null;
        //}


        public static void Main()
        {
            new Thread(Go).Start();
            Console.ReadKey();
        }

        private static void Go()
        {
            try
            {
                throw null; // 该异常将会被捕获
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception!");
                // 异常日志记录，或者通知其他线程出现异常了
            }
        }        
    }

    public static class ThreadExecutor
    {
        public static bool Execute(System.Threading.WaitCallback callback, object state)
        {
            try
            {
                return System.Threading.ThreadPool.QueueUserWorkItem((data) =>
                {
                    try
                    {
                        callback(data);
                    }
                    catch (Exception ex)
                    {
                        // log the exception
                    }
                }, state);
            }
            catch (Exception e)
            {
                // log the exception
            }
            return false;
        }
    }
}
