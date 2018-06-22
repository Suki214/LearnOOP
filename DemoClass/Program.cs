using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordAttributeDemo;

namespace DemoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoClass demo = new DemoClass();
            Console.WriteLine(demo.ToString());

            Type t = typeof(DemoClass);
            Console.WriteLine("List the attribute property of {0}", t);

            object[] records = t.GetCustomAttributes(typeof(RecordAttribute), false);
            foreach (RecordAttribute o in records)
            {
                Console.WriteLine(o);
                Console.WriteLine(o.RecordType);
                Console.WriteLine(o.Author);
                Console.WriteLine(o.Date);
                if (!string.IsNullOrEmpty(o.Memo))
                {
                    Console.WriteLine(o.Memo);
                }
            }

            //object[] methods = t.GetMethods();
            //var stratupmethod = methods.FirstOrDefault(x => x.GetCustomAttribute().OfType<SetUpAttribute>().Any());
            //foreach(var method in methods)
            //{
            //    var attribute = method.GetCustomAttribute();
            //    //Console.WriteLine(record.Author);
            //}


            Console.ReadKey();
        }
    }
}
