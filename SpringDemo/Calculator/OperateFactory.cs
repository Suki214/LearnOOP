using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class OperateFactory
    {
        public static Operation CreateOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper= new  OperateAdd();
                    break;
                case "-":
                    oper = new OperateDelete();
                    break;
                case "*":
                    oper = new OperateMultiple();
                    break;
                case "/":
                    oper = new OperateDevide();
                    break;
            }
            return oper;
        }
    }
}
