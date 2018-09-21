using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndexDemo
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Team t1 = new Team();
    //        //t1[1] = "B";
    //        //for(int i = 0; i < 5; i++)
    //        //{
    //        //    Console.WriteLine(t1[i]);
    //        //}


    //        //B b = new B(); //x = 1,y = 0
    //        //b.PrintFields(); //x = 1,y = -1    

    //        //string strTmp = "abcdefg某某某";
    //        //int i = System.Text.Encoding.Default.GetBytes(strTmp).Length;
    //        //int j = strTmp.Length;
    //        //Console.WriteLine(i);
    //        //Console.WriteLine(j);

    //        //List<A> lists = new List<A>();
    //        //lists.GetEnumerator();

    //        Console.WriteLine("please enter in an array with int");
    //        int[] intArray= new int[6];
    //        for (int i = 0; i < intArray.Length; i++)
    //        {
    //            intArray[i]= int.Parse(Console.ReadLine());
    //        }
    //        Console.WriteLine("the input array is:");
    //        for (int i = 0; i < intArray.Length; i++)
    //        {
    //            Console.Write(intArray[i]+" ");
    //        }

    //        int[] result = GetResult(int[] intArr);
    //        Console.ReadKey();
    //    }

    //    private static int[] GetResult(Array array, object intArr)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private static int[] GetResult(object p, object intArr)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine(
                  "Press <ENTER> to fork another thread...");
                Console.ReadLine();
                Thread t = new Thread(new ThreadStart(ThreadProc));
                t.Start();
            }
        }

        static void ThreadProc()
        {
            Console.WriteLine("Thread #{0} started...",
              Thread.CurrentThread.ManagedThreadId);
            // Block until current thread terminates - i.e. wait forever
            Thread.CurrentThread.Join();
        }
    }
}
