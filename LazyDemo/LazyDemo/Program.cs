using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Lazy<Student> stu = new Lazy<Student>();
            if (!stu.IsValueCreated)
            {
                Console.WriteLine("The student is not initial");
                Console.WriteLine(stu.Value.Name);//执行此语句时，才转去构造函数，而不是在new class()的时候
            }

            stu.Value.Name = "Tom";
            stu.Value.Age = 18;
            Console.WriteLine(stu.Value.Name);
            Console.ReadKey();

            //Result:
            //The student is not initial
            //This student is initial
            //Default Name
            //Tom
        }
    }
}
