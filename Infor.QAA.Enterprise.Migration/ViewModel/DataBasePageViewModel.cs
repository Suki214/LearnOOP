using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    internal class DataBasePageViewModel : WizardPageViewModelBase
    {
        public override string DisplayName
        {
            get
            {
                return "DataBase Info";
            }
        }

        internal override bool IsValid()
        {
            return true;
        }
    }
}
