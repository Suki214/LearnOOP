using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackWithDelegate
{
    class Program
    {
        public delegate void MyDelegate();
        static void Main(string[] args)
        {
<<<<<<< HEAD
            HelloDelegate sayHi = new HelloDelegate(SayEnglishHello);
            sayHi += new HelloDelegate(SayChineseHello);
            sayHi(" World!");
            Console.ReadKey();
        }

        public static void SayEnglishHello(string english)
        {
            Console.WriteLine("Hi {0}",english);
        }

        public static void SayChineseHello(string chinese)
        {
            Console.WriteLine("你好 {0}", chinese);
=======
            MyDelegate del = new MyDelegate( CallbackWithDelegate );
            del();
            Console.ReadKey();
        }

        static void CallbackWithDelegate()
        {
            Console.WriteLine("Calling back");
>>>>>>> 772577405f156619f63cf5d56af0dc4fe7731c06
        }
    }

    public delegate void HelloDelegate(string hello);
}
