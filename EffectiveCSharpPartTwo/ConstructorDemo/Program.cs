using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //B a = new B();


            //Console.WriteLine(C.x.ToString());
            //Console.WriteLine(D.y.ToString());
            ////Result: 2 & 1


            //Console.WriteLine(D.y.ToString());
            //Console.WriteLine(C.x.ToString());
            //Console.WriteLine(D.y.ToString());
            ////Result: 2 & 1 & 2


            MyClass myClass = new MyClass("Prok");
            MyClass myClass1 = new MyClass("Peak",18);
            Console.ReadKey();
        }
    }

    class A
    {
        private static readonly string a = "A";

        static A()
        {
            Console.WriteLine(a);
            a = "a changed";
            Console.WriteLine(a);
            a = "a.static constructor";
            Console.WriteLine(a);
        }

        public A()
        {
            Console.WriteLine("a.ocnstructor");
        }
    }

    class B : A
    {
        private static readonly string b = "B";

        static B()
        {
            Console.WriteLine(b);
            b = "b changed";
            Console.WriteLine(b);
            b = "b.static constructor";
            Console.WriteLine(b);
        }

        public B():base()
        {
            Console.WriteLine("b.ocnstructor");
        }
    }

    /*Result:
    B
    b changed
    b.static constructor
    A
    a changed
    a.static constructor
    a.ocnstructor
    b.ocnstructor*/



    class C
    {
        public static int x = D.y;
        static C()
        {
            x++;
        }
    }

    class D
    {
        public static int y = C.x;

        static D()
        {
            y++;
        }
    }


    public class MyClass : BaseClass
    {
        private string _name;
        private int _age;

        public MyClass(string Name) : this(Name, 20) { }

        public MyClass(string Name, int Age) : base(Name, Age)
        {
            _age = Age;
            _name = Name;
        }
    }
}
