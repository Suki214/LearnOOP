using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializableDemo
{
    //class Program
    //{
    //    //static void Main(string[] args)
    //    //{
    //    //    var me = new Student() { StudentId = 1, Name = "SX", Age = 18 };
    //    //    IFormatter formatter = new BinaryFormatter();
    //    //    IFormatter formatter1 = new SoapFormatter();
    //    //    XmlSerializer formatter2 = new XmlSerializer(typeof(Student));
    //    //    Stream stream = new FileStream("C:/data/studentInfo.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.None);
    //    //    formatter.Serialize(stream,me);
    //    //    stream.Close();

    //    //    Stream destream = new FileStream("C:/data/studentInfo.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
    //    //    var stillme= (Student)formatter.Deserialize(destream);
    //    //    destream.Close();
    //    //    Console.WriteLine( stillme.DisplayInfo());
    //    //    Console.ReadKey();
    //    //}


    //    //public static void Main()
    //    //{
    //    //    Task t = Task.Run(() => {
    //    //        Random rnd = new Random();
    //    //        long sum = 0;
    //    //        int n = 1000000;
    //    //        for (int ctr = 1; ctr <= n; ctr++)
    //    //        {
    //    //            int number = rnd.Next(0, 101);
    //    //            sum += number;
    //    //        }
    //    //        Console.WriteLine("Total: {0:N0}", sum);
    //    //        Console.WriteLine("Mean: {0:N2}", sum / n);
    //    //        Console.WriteLine("N: {0:N0}", n);
    //    //    });
    //    //    t.Wait();
    //    //}


    //}

    public class ThreadClass
    {
        public static ManualResetEvent mre = new ManualResetEvent(false);
        public static void trmain()
        {
            Thread tr = Thread.CurrentThread;
            Console.WriteLine("thread: waiting for an event");
            mre.WaitOne();
            Console.WriteLine("thread: got an event");
            for (int x = 0; x < 10; x++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(tr.Name + ": " + x);
            }
        }
        static void Main(string[] args)
        {
            //Thread thrd1 = new Thread(new ThreadStart(trmain));
            //thrd1.Name = "thread1";
            //thrd1.Start();

            //for (int x = 0; x < 10; x++)
            //{
            //    Thread.Sleep(900);
            //    Console.WriteLine("Main    :" + x);
            //    if (5 == x) mre.Set();
            //}
            //while (thrd1.IsAlive)
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Main: waiting for thread to stop...");
            //}
            int[] arr = { 1, 0, 3, 9, 2, 1, 5, 1 };
            Console.WriteLine(getMaxSum(arr).ToString());
            Console.ReadKey();
        }

        public static int getMaxSum(int[] arr)
        {
            if (arr.Length == 0) return 0;
            if (arr.Length == 1) return arr[0];
            if (arr.Length == 2) return Math.Max(arr[0], arr[1]);
            if (arr.Length == 3) return Math.Max(arr[1], arr[0] + arr[2]);
            int[] p = new int[arr.Length];
            p[0] = arr[0];
            p[1] = arr[1];
            p[2] = arr[0] + arr[2];
            for (int i = 3; i < arr.Length; i++)
            {
                p[i] = arr[i] + Math.Max(p[i - 2], p[i - 3]);
            }
            return Math.Max(p[arr.Length - 1], p[arr.Length - 2]);
        }
    }
}
