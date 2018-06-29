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
            MyDelegate del = new MyDelegate( CallbackWithDelegate );
            del();
            Console.ReadKey();
        }

        static void CallbackWithDelegate()
        {
            Console.WriteLine("Calling back");
        }
    }
}
