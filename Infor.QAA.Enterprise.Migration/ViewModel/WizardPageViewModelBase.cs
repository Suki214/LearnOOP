using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    /// <summary>
    /// Abstract base class for all pages shown in the wizard.
    /// </summary>
    public abstract class WizardPageViewModelBase : BaseDialogViewModel
    {

        public abstract string DisplayName { get; }

        bool isCurrentPage;
        public bool IsCurrentPage
        {
            get { return isCurrentPage; }
            set
            {
                if (value == isCurrentPage)
                    return;

                isCurrentPage = value;
                NotifyPropertyChange("IsCurrentPage");
            }
        }

        /// <summary>
        /// Returns true if the user has filled in this page properly
        /// and the wizard should allow the user to progress to the 
        /// next page in the workflow.
        /// </summary>
        internal abstract bool IsValid();

    }
}
