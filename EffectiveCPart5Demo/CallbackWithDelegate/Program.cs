using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackWithDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }

    public delegate void HelloDelegate(string hello);
}
