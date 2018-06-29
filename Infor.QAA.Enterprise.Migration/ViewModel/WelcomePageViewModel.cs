using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    internal class WelcomePageViewModel : WizardPageViewModelBase
    {
        public override string DisplayName
        {
            get
            {
                return "Welcome";
            }
        }

        internal override bool IsValid()
        {
            return true;
        }
    }
}
