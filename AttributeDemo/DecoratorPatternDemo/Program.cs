using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone ap = new Applephone();
            Decorator decorator = new Sticker(ap);
            decorator.Print();

            Decorator apa = new Accessories(ap);
            apa.Print();

            Sticker s = new Sticker(ap);
            Accessories accessories = new Accessories(s);
            accessories.Print();

            Console.ReadKey();
        }
    }
}
