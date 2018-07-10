using CalculatorWithMefDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbal", '%')]
    public class Mod : IOperation
    {
        public int Operate(int x, int y)
        {
            return x % y;
        }
    }
}
