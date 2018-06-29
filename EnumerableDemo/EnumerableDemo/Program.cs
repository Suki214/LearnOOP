using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableDemo
{
    class Program
    {
        static void Main(string[] args)
        {         
            Person[] persons = new Person[]
            {
                new Person{Name="Mike", Age=19},
                new Person{Name="MIckey",Age=18},
                new Person{Name="Candy", Age=20}
            };
            PeopleEnum pe = new PeopleEnum(persons);
            People peopleList = new People(persons);
            foreach(Person p in peopleList)
            {
                Console.WriteLine(p);
            }
            while(pe.MoveNext())
            {
                Console.WriteLine("Welcome...{0}", pe.Current.ToString());
            }
            while (peopleList.GetEnumerator().MoveNext())
            {
                Console.WriteLine("Welcome.....{0}", peopleList.GetEnumerator().Current.ToString());
            }
            Console.ReadKey();
        }
    }
}
