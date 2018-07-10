using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWithMefDemo
{
    public interface IOperation
    {
        int Operate(int x, int y);
    }
}
