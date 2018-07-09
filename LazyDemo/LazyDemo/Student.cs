using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyDemo
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student()
        {
            Name = "Default Name";
            Age = 0;
            Console.WriteLine("This student is initial");
        }
    }
}
