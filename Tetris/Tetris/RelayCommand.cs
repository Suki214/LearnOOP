using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tetris
{
    class RelayCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _execute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
