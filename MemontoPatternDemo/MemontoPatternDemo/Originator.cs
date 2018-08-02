using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemontoPatternDemo
{
    public class Originator
    {
        public string State { get; set; }

        public Menento CreateMenento()
        {
            return new Menento(State);
        }

        public void SetMenento(Menento menento)
        {
            State = menento.State;
        }
    }
}
