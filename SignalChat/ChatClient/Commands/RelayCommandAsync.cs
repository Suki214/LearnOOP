using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.Commands
{
    public class RelayCommandAsync : ICommand
    {
        private Predicate<object> _canExecute;
        private Func<Task> _execute;
        private bool isExecuting;

        public RelayCommandAsync(Func<Task> execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        public RelayCommandAsync(Func<Task> execute) : this(execute, null) { }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null && !isExecuting) return true;
            return (_canExecute(parameter) && !isExecuting);
        }

        public async void Execute(object parameter)
        {
            isExecuting = true;
            try { await _execute(); }
            finally { isExecuting = false; }
        }
    }
}
