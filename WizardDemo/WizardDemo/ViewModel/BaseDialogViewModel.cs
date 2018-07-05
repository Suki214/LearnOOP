using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WizardDemo.ViewModel
{
    public class BaseDialogViewModel:BaseViewModel
    {
        private RelayCommand cancelCommand;
        private bool? dialogResult;

        public bool? DialogResult
        {
            get
            {
                return dialogResult;
            }
            set
            {
                if (dialogResult != value)
                {
                    dialogResult = value;
                    OnPropertyChanged("DialogResult");   
                }                                 
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if(cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(
                        parm=>DialogClose(false));
                }
                return cancelCommand;
            }
        }

        protected virtual void DialogClose(bool v)
        {
            DialogResult = v;
        }
    }
}
