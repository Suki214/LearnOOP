using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmCases
{
    class Program
    {
        //static void ThrowExceptionFunction()
        //{
        //    try
        //    {
        //        try
        //        {
        //            try
        //            {
        //                throw new Exception("模拟异常");
        //            }
        //            catch (Exception ex1)
        //            {
        //                throw;
        //            }
        //        }
        //        catch (Exception ex2)
        //        {
        //            throw;
        //        }
        //    }
        //    catch (Exception ex3)
        //    {
        //        throw;
        //    }

        //}


        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        ThrowExceptionFunction();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.StackTrace);//因为C#会为每个函数的异常记录一次堆栈信息，而本例中有两个函数分别为ThrowExceptionFunction和Main，所以这里堆栈捕捉到了两个异常一个是在函数ThrowExceptionFunction中32行，另一个是Main函数中42行，
        //    }

        //    Console.ReadLine();
        //}

        //static void ThrowExceptionFunction()
        //{
        //    try
        //    {
        //        try
        //        {
        //            try
        //            {
        //                throw new Exception("模拟异常1");
        //            }
        //            catch (Exception ex1)
        //            {
        //                throw new Exception("模拟异常2", ex1);
        //            }
        //        }
        //        catch (Exception ex2)
        //        {
        //            throw new Exception("模拟异常3", ex2);
        //        }
        //    }
        //    catch (Exception ex3)
        //    {
        //        throw new Exception("模拟异常4", ex3);
        //    }

        //}


        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        ThrowExceptionFunction();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());//要想输出函数ThrowExceptionFunction内抛出的所有异常，将ThrowExceptionFunction内部的异常都嵌套封装即可，然后在输出异常的时候使用ex.ToString()函数，就可以输出所有嵌套异常的堆栈信息
        //    }

        //    Console.ReadLine();
        //}


        //static void InnerException()
        //{
        //    throw new Exception("模拟异常");
        //}

        //static void OuterException()
        //{
        //    try
        //    {
        //        InnerException();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //        throw ;
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        OuterException();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.StackTrace);//由于代码24行使用throw ex重置了异常抛出点，所以这里异常堆栈只能捕捉到代码32行和24行抛出的异常，但是13行的异常在堆栈中无法捕捉到
        //    }

        //    Console.ReadLine();
        //}
      


        //public static ManualResetEvent mre = new ManualResetEvent(false);
        //public static void trmain()
        //{
        //    Thread tr = Thread.CurrentThread;
        //    Console.WriteLine("thread1: waiting for an event");
        //    mre.WaitOne();
        //    Console.WriteLine("thread1: got an event");
        //    for (int x = 0; x < 10; x++)
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine(tr.Name + ": " + x);
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    Class1 c = new Class1();
        //    Thread thrd1 = new Thread(new ThreadStart(trmain));
        //    thrd1.Name = "thread1";
        //    thrd1.Start();
        //    for (int x = 0; x < 10; x++)
        //    {
        //        Thread.Sleep(900);
        //        Console.WriteLine("Main    :" + x);
        //        if (5 == x) mre.Set();
        //    }
        //    while (thrd1.IsAlive)
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Main: waiting for thread1 to stop...");
        //    }
        //    Console.ReadKey();
        //}


    }

    public class A
    {
        public A()
        {
            Console.WriteLine("A");
        }
    }
    public class B
    {
        public B()
        {
            Console.WriteLine("B");
        }
    }
    public class C : A
    {
       
        
        public C()
        {
            Console.WriteLine("C");
        }
        B newb = new B();
    }
    class MainClass
    {
        public static void Main()
        {
            //C newc = new C();
            string s2;
            string s1 = s2 = "12345";
            s1 = "23456";
            Console.WriteLine(s2);


            Console.ReadLine();
        }
    }

}
