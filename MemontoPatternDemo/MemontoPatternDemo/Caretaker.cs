using System.Collections.Generic;

namespace MemontoPatternDemo
{
    public class Caretaker
    {
        Dictionary<int, Menento> numberAndMenentos = new Dictionary<int, Menento>();

        public void AddMenentos(int number, Menento menento)
        {
            if (!numberAndMenentos.ContainsKey(number))
            {
                numberAndMenentos.Add(number, menento);
            }
        }

        public Menento GetMenento(int number)
        {
            if (numberAndMenentos.ContainsKey(number))
            {
                return numberAndMenentos[number];
            }
            else
            {
                return null;
            }
        }
    }
}
