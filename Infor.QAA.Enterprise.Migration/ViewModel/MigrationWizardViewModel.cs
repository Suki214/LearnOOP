using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Infor.QAA.Enterprise.Migration.ViewModel
{
    public class MigrationWizardViewModel : BaseDialogViewModel
    {
        private RelayCommand moveNextCommand;
        private RelayCommand movePreviousCommand;
        private ReadOnlyCollection<WizardPageViewModelBase> pages;
        private WizardPageViewModelBase currentPage;


        public MigrationWizardViewModel()
        {
            this.CurrentPage = this.Pages[0];
        }

        /// <summary>
        /// Returns a read-only collection of all page ViewModels.
        /// </summary>
        public ReadOnlyCollection<WizardPageViewModelBase> Pages
        {
            get
            {
                if (pages == null)
                    this.CreatePages();

                return pages;
            }
        }

        int CurrentPageIndex
        {
            get
            {

                if (this.CurrentPage == null)
                {
                    return -1;
                }

                return this.Pages.IndexOf(this.CurrentPage);
            }
        }

        /// <summary>
        /// Returns the page ViewModel that the user is currently viewing.
        /// </summary>
        public WizardPageViewModelBase CurrentPage
        {
            get { return currentPage; }
            private set
            {
                if (value == currentPage)
                    return;

                if (currentPage != null)
                    currentPage.IsCurrentPage = false;

                currentPage = value;

                if (currentPage != null)
                    currentPage.IsCurrentPage = true;

                NotifyPropertyChange("CurrentPage");
                NotifyPropertyChange("IsOnLastPage");
            }
        }

        /// <summary>
        /// Returns true if the user is currently viewing the last page 
        /// in the workflow.  This property is used by CoffeeWizardView
        /// to switch the Next button's text to "Finish" when the user
        /// has reached the final page.
        /// </summary>
        public bool IsOnLastPage
        {
            get { return this.CurrentPageIndex == this.Pages.Count - 1; }
        }

        void CreatePages()
        {
            var welcomeVM = new WelcomePageViewModel();
            var databaseVM = new DataBasePageViewModel();
            var summaryVM = new SummaryPageViewModel();
            var migratingVM = new MigratingPageViewModel();
            var pageList = new List<WizardPageViewModelBase>();

            pageList.Add(welcomeVM);
            pageList.Add(databaseVM);
            pageList.Add(summaryVM);
            pageList.Add(migratingVM);

            pages = new ReadOnlyCollection<WizardPageViewModelBase>(pageList);
        }

        #region MovePreviousCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the previous page in the workflow.
        /// </summary>
        public ICommand MovePreviousCommand
        {
            get
            {
                if (movePreviousCommand == null)
                    movePreviousCommand = new RelayCommand(
                       param => this.MoveToPreviousPage(),
                        param => this.CanMoveToPreviousPage);

                return movePreviousCommand;
            }
        }

        bool CanMoveToPreviousPage
        {
            get { return 0 < this.CurrentPageIndex; }
        }

        void MoveToPreviousPage()
        {
            if (this.CanMoveToPreviousPage)
                this.CurrentPage = this.Pages[this.CurrentPageIndex - 1];
        }

        #endregion // MovePreviousCommand

        #region MoveNextCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the next page in the workflow.  If the user
        /// is viewing the last page in the workflow, this causes the Wizard
        /// to finish and be removed from the user interface.
        /// </summary>
        public ICommand MoveNextCommand
        {
            get
            {
                if (moveNextCommand == null)
                    moveNextCommand = new RelayCommand(
                        param => this.MoveToNextPage(),
                       param => this.CanMoveToNextPage);

                return moveNextCommand;
            }
        }

        bool CanMoveToNextPage
        {
            get { return this.CurrentPage != null && this.CurrentPage.IsValid(); }
        }

        void MoveToNextPage()
        {
            if (this.CanMoveToNextPage)
            {
                if (this.CurrentPageIndex < this.Pages.Count - 1)
                    this.CurrentPage = this.Pages[this.CurrentPageIndex + 1];
                else
                    DialogResult = true;
            }
        }

        #endregion // MoveNextCommand

    }
}
