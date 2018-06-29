using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    internal class SummaryPageViewModel : WizardPageViewModelBase
    {
        public override string DisplayName
        {
            get
            {
                return "Preview";
            }
        }

        internal override bool IsValid()
        {
            return true;
        }
    }
}
