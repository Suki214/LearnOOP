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

            originator.PowerState = "武力值100";
            originator.DefenseState = "防御力200";
            Menento menento1 = originator.CreateMenento();
            caretaker.AddMenentos(1, menento1);

            originator.PowerState = "武力值90";
            originator.DefenseState = "防御力150";
            Menento menento2 = originator.CreateMenento();
            caretaker.AddMenentos(2, menento2);

            Console.WriteLine("The current state is: {0}，{1}", originator.PowerState,originator.DefenseState);

            originator.SetMenento(caretaker.GetMenento(1));
            Console.WriteLine("The current state revert back to: {0}，{1}", originator.PowerState, originator.DefenseState);

            originator.SetMenento(caretaker.GetMenento(2));
            Console.WriteLine("The current state revert back to: {0}，{1}", originator.PowerState, originator.DefenseState);

            Console.ReadKey();
        }
    }
}
