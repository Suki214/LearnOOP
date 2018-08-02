using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemontoPatternDemo
{
    public class Menento
    {
        public string PowerState { get; set; }
        public string DefenseState { get; set; }
        public Menento(string powerState, string defenseState)
        {
            PowerState = powerState;
            DefenseState = defenseState;
        }
    }
}
