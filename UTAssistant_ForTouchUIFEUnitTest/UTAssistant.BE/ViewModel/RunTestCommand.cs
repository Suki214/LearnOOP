using System;
using System.Windows.Input;

using UTAssistant.BE.Model;

namespace UTAssistant.BE.ViewModel
{
    internal class RunTestCommand : ICommand
    {
        private readonly UtItemViewModel myUtItemViewModel;

        public RunTestCommand( UtItemViewModel utItemViewModel )
        {
            myUtItemViewModel = utItemViewModel;
        }

        public bool CanExecute( object parameter )
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute( object parameter )
        {
            ExecuteTestRecusively( myUtItemViewModel );
        }

        private void ExecuteTestRecusively( UtItemViewModel vm )
        {
            if( vm.ItemType == ItemType.TestMethod || vm.ItemType == ItemType.TestCaseMethod)
            {
                var instance = vm.Parent.ClassInstance;

                var methodInfo = vm.TestMethod;
                var arguments = vm.InnerItem.Arguments;
                var setupMethod = vm.InnerItem.SetUpMethod;
                var teardownMethod = vm.InnerItem.TearDownMethod;

                try
                {
                    if( setupMethod != null )
                    {
                        setupMethod.Invoke( instance, null );
                    }

                    methodInfo.Invoke( instance, arguments );

                    if( teardownMethod != null )
                    {
                        teardownMethod.Invoke( instance, null );
                    }

                    vm.TestPassed = TestResult.Passed;
                }
                catch( Exception e )
                {
                    vm.TestPassed = TestResult.Failed;
                    vm.FailedStackTrace = e.InnerException.StackTrace;
                }
            }

            foreach( var child in vm.Children )
            {
                ExecuteTestRecusively( child );
            }
        }
    }
}