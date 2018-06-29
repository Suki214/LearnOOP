using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
   public class OperateDevide:Operation
    {
        public override double GetResult()
        {
            if (NumB == 0)
            {
                throw new DivideByZeroException("The devided number should not be zero");
            }
            else
            { 
                return NumA / NumB;
            }
        }
    }
}
