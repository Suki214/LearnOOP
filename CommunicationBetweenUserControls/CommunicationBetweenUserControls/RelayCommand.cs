using System;
using System.Windows.Input;

namespace CommunicationBetweenUserControls
{
    public class RelayCommand : ICommand
    {
        private Action<object> myExecute;
        private Predicate<object> myCanExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            myCanExecute = canExecute;
            myExecute = execute;
        }
        public RelayCommand(Action<object> execute) : this(execute,null) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myExecute(parameter);
        }
    }
}
