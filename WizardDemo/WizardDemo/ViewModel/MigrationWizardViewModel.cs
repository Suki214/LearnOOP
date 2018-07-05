using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WizardDemo.ViewModel
{
    public class MigrationWizardViewModel:BaseViewModel
    {
        private ReadOnlyCollection<WizardBaseViewModel> myPages;
        private WizardBaseViewModel myCurrentPage;

        public MigrationWizardViewModel()
        {
            CurrentPage = Pages[0];
        }

        public ReadOnlyCollection<WizardBaseViewModel> Pages
        {
            get
            {
                if (myPages == null)
                {
                    this.CreatePages();
                }
                return myPages;
            }
        }

        private void CreatePages()
        {
            var pageList = new List<WizardBaseViewModel>();
            var WelcomeVM = new WelcomePageViewModel();
            var DataVM = new DatabaseInfoPageViewModel();
            var SumVM = new SummaryPageViewModel();
            var MigVM = new MigratingPageViewModel();

            pageList.Add(WelcomeVM);
            pageList.Add(DataVM);
            pageList.Add(SumVM);
            pageList.Add(MigVM);

            myPages = new ReadOnlyCollection<WizardBaseViewModel>(pageList);
        }

        public WizardBaseViewModel CurrentPage
        {
            get
            {
                return myCurrentPage;
            }
            set
            {
                if (myCurrentPage == value)
                    return;
                if (myCurrentPage != null)
                    myCurrentPage.IsCurrentPage = false;
                myCurrentPage = value;

                if (myCurrentPage != null)
                    myCurrentPage.IsCurrentPage = true;
                OnPropertyChanged("CurrentPage");
                OnPropertyChanged("IsLastPage");
            }
        }

        int CurrentPageIndex
        {
            get
            {
                if (myCurrentPage == null)
                    return -1;
                return this.Pages.IndexOf(CurrentPage);
            }
        }

        public bool IsLastPage
        {
            get
            {
                return CurrentPageIndex == Pages.Count - 1;
            }
        }


        private RelayCommand moveNextCommand;
        public ICommand MoveNextCommand
        {
            get
            {
                if(moveNextCommand == null)
                {
                    moveNextCommand = new RelayCommand(parm=>MoveNextPage(), parm=>canMoveNext);
                }
                return moveNextCommand;
            }
        }
        private void MoveNextPage()
        {
            if (canMoveNext)
            {
                if(CurrentPageIndex <Pages.Count-1)
                {
                    CurrentPage = Pages[CurrentPageIndex + 1];
                }
            }
        }
        private bool canMoveNext
        {
            get
            {
                return CurrentPageIndex < Pages.Count - 1;
            }
        }
        private RelayCommand movePreviousCommand;
        private bool canMovePrevious
        {
            get
            {
                //return CurrentPageIndex > 0;
                return true;
            }
        }
        public ICommand MovePreviousCommand
        {
            get
            {
                if (movePreviousCommand==null)
                {
                    movePreviousCommand = new RelayCommand(parm=>MovePreviousPage(),parm=>canMovePrevious);
                }
                return movePreviousCommand;
            }            
        }
        private void MovePreviousPage()
        {
            if (canMovePrevious)
            {
                CurrentPage = Pages[CurrentPageIndex - 1];
            }
        }
    }
}
