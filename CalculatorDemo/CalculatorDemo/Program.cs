using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = 2;
            double numberB = 5;

            Add add = new Add(numberA, numberB);
            double addResult = add.Result();

            Delete delete = new Delete(numberA, numberB);
            double deleteResult = delete.Result();

            Multiply multiply = new Multiply(numberA, numberB);
            double multiplyResult = multiply.Result();

            Devide devide = new Devide(numberA, numberB);
            double devideResult = devide.Result();


            Console.WriteLine("Add Result is {0}", addResult.ToString());
            Console.WriteLine("Delete Result is {0}", deleteResult.ToString());
            Console.WriteLine("Multiply Result is {0}", multiplyResult.ToString());
            Console.WriteLine("Devide Result is {0}", devideResult.ToString());

            Console.ReadKey();
        }
    }
}
