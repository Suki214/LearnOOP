using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemontoPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Caretaker caretaker = new Caretaker();
            Originator originator = new Originator();

            originator.State = "状态1";
            Menento menento1 = originator.CreateMenento();
            caretaker.AddMenentos(1, menento1);

            originator.State = "状态2";
            Menento menento2 = originator.CreateMenento();
            caretaker.AddMenentos(2, menento2);

            Console.WriteLine("The current state is: {0}", originator.State);

            originator.SetMenento(caretaker.GetMenento(1));
            Console.WriteLine("The current state turns back to: {0}", originator.State);

            originator.SetMenento(caretaker.GetMenento(2));
            Console.WriteLine("The current state turns back to: {0}", originator.State);

            Console.ReadKey();
        }
    }
}
