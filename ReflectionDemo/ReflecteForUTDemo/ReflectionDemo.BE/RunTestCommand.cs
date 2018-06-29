using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReflecteForUTDemo.ReflectionDemo.BE
{
    public class RunTestCommand : ICommand
    {
        private UtItemViewModel myUtItemViewModel;

        public RunTestCommand(UtItemViewModel itemViewModel)
        {
            myUtItemViewModel = itemViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ExecuteTestRecusively(myUtItemViewModel);
        }

        private void ExecuteTestRecusively(UtItemViewModel vm)
        {
            if (vm.ItemType == ItemType.TestMethod)
            {
                var instance = vm.Parent.ClassInstance;
                var methodInfo = vm.TestMethod;
                var arguments = vm.InnerItem.Arguments;

                try
                {
                    methodInfo.Invoke(instance, arguments);
                    vm.TestPassed = TestResult.Passed;
                }
                catch(Exception e)
                {
                    vm.TestPassed = TestResult.Failed;
                    vm.FailedStackTrace = e.InnerException.StackTrace;
                }

                foreach(var child in vm.Children)
                {
                    ExecuteTestRecusively(child);
                }
            }
        }
    }
}
