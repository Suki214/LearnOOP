using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableDemo
{
    [Serializable]
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DisplayInfo()
        {
             return "Id is "+ StudentId.ToString()+ "Name is "+ Name + "Age is "+Age.ToString();
        }
    }
}
