using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    internal class MigratingPageViewModel : WizardPageViewModelBase
    {
        public override string DisplayName
        {
            get
            {
                return "Migrating...";
            }
        }

        internal override bool IsValid()
        {
            return true;
        }
    }
}
