using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //In this case ,build successed, but run with error: No overload for method 'Welcome' takes '0' arguments
            //dynamic obj = new DynamicTest();
            //obj.Welcome();

            //Need to correct as following way
            //dynamic obj = new DynamicTest();
            //string name = "name";
            //obj.Welcome(name);

            //If define as following, build is error
            //There is no argument given that corresponds to the required formal parameter 'name' of 'DynamicTest.Welcome(string)'
            //var v1 = new DynamicTest();
            //v1.Welcome();


            //var v1 = new DynamicTest();
            //string name = "Tom";
            //v1.Welcome(name);
            Console.ReadKey();
        }
    }

    class DynamicTest
    {
        public void Welcome(string name)
        {
            Console.WriteLine("Hello {0},welcome to dynamic world.", name);
        }
    }
}
