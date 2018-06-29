using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreSystem
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action myAction;

        private bool myIsExecutable=true;

        public bool IsExecutable
        {
            get
            {
                return myIsExecutable;
            }
            set
            {
                myIsExecutable = value;
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public RelayCommand( Action action)
        {
            myAction = action;
           // myIsExecutable = isExecutable;
        }
        public bool CanExecute(object parameter)
        {
            return myIsExecutable;
        }

        public void Execute(object parameter)
        {
            myAction();
        }
    }
}
