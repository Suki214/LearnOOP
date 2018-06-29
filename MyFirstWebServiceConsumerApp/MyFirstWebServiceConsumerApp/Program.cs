using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstWebServiceConsumerApp.MyFirstWebServiceReference;

namespace MyFirstWebServiceConsumerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebService1 webService = new WebService1();
            Console.WriteLine(webService.Add(2,6));
            Console.ReadLine();
        }
    }
}
