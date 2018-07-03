using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMachine.ViewModel
{
    public class OperateFactory
    {
        private Operation operation;
        public Operation CreateOperation(string operate)
        {
            switch (operate)
            { 
                case "Plus":
                operation = new AddOperate();
                break;
                case "Delete":
                    operation = new AddOperate();
                    break;
                case "Multiply":
                    operation = new AddOperate();
                    break;
                case "Devide":
                    operation = new AddOperate();
                    break;
            }
            return operation;
        }            
    }

}
