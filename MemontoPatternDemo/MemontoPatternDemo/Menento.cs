using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemontoPatternDemo
{
    public class Menento
    {
        public string State { get; set; }
        public Menento(string state)
        {
            State = state;
        }
    }
}
