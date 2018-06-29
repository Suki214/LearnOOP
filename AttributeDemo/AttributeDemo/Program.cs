using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethodDemo;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ErrorMsg errorMsg = new ErrorMsg();
            //ERROR_CODE rrror = new ERROR_CODE();
            //Console.WriteLine("{0}", rrror);//0

            string s = "h ello er.t _e?";
            int i = s.WordCount();
            Console.WriteLine("{0}",i);//5
            Console.ReadKey();


        }

        public struct ErrorMsg
        {
            private ERROR_CODE error;
            private string msg;
        }

        [Flags]
        public enum ERROR_CODE
        {
            //noError = 0,//增加0的有效定义
            invalid = 101,
            cannot = 102
        }
    }
}
