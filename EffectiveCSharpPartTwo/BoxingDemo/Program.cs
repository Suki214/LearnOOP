using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();

            Person p = new Person("OldName");

            arrayList.Add(p);

            Person p2 = (Person)arrayList[0];
            p2.Name = "NewName";
            //((Person)arrayList[0]).Name = "NewName";//Cannot modify the result of an unboxing conversion
            Console.WriteLine(p2.Name);//NewName
            Console.WriteLine(((Person)arrayList[0]).Name);//OldName

            //workaround
            arrayList.RemoveAt(0);
            arrayList.Insert(0, p2);
            Console.WriteLine(((Person)arrayList[0]).Name);//NewName

            Console.ReadKey();
        }
    }
    public struct Person
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Person(string _name)
        {
            name = _name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
