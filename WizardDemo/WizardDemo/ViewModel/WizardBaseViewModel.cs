using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardDemo.ViewModel
{
    public abstract class WizardBaseViewModel:BaseViewModel
    {
        public abstract string DisplayName { get; }

        bool isCurrentPage;

        public bool IsCurrentPage
        {
            get
            {
                return isCurrentPage;
            }
            set
            {
                if (isCurrentPage != value)
                    isCurrentPage = value;
                OnPropertyChanged("IsCurrentPage");
            }
        }
    }
}
