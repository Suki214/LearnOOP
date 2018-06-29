using ReflecteForUTDemo;
using ReflecteForUTDemo.ReflectionDemo.BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ReflectionDemo
{
    public class UtTreeViewModel
    {
        private readonly ReadOnlyCollection<UtItemViewModel> myUtProjects;
        private readonly UtItemViewModel myTreeRoot;
        private readonly ICommand mySearchCommand;

        private IEnumerator<UtItemViewModel> myMatchingEnumerator;
        private string mySearchText = string.Empty;

        public UtTreeViewModel(UtItem root)
        {
            myTreeRoot = new UtItemViewModel(root) {IsExpanded = true };
            myUtProjects = new ReadOnlyCollection<UtItemViewModel>(new[] { myTreeRoot });
            mySearchCommand = new SearchTreeCommand(this);
        }

        public ReadOnlyCollection<UtItemViewModel> UtProjects
        {
            get
            {
                return myUtProjects;
            }
        }

        public string SearchText
        {
            get
            {
                return mySearchText;
            }
            set
            {
                if (value == mySearchText)
                    return;
                mySearchText = value;
                PerformSearch();
                myMatchingEnumerator = null;
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return mySearchCommand;
            }
        }
        public void PerformSearch()
        {
            if(myMatchingEnumerator ==null||!myMatchingEnumerator.MoveNext())
            {
                VerifyMatchingEnumerator();
            }

            var itemViewModel = myMatchingEnumerator.Current;

            if(itemViewModel == null)
            {
                return;
            }

            if(itemViewModel.Parent != null)
            {
                itemViewModel.Parent.IsExpanded = true;
            }
            itemViewModel.IsSelected = true;
        }

        public void VerifyMatchingEnumerator()
        {
            var matches = FindMatches(mySearchText, myTreeRoot);
            myMatchingEnumerator = matches.GetEnumerator();
            if (!myMatchingEnumerator.MoveNext())
            {
                //No matching names wre found
            }
        }

        public IEnumerable<UtItemViewModel> FindMatches(string searchText, UtItemViewModel treeRoot)
        {
            if(DisplayNameMatch(treeRoot, searchText))
            {
                yield return treeRoot;
            }
            foreach(var child in treeRoot.Children)
            {
                foreach(var match in FindMatches(searchText, child))
                {
                    yield return match;
                }
            }
        }

        public bool DisplayNameMatch(UtItemViewModel treeRoot, string text)
        {
            if(string.IsNullOrEmpty(text)||string.IsNullOrEmpty(treeRoot.DisplayName))
            {
                return false;
            }
            return treeRoot.DisplayName.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
    }
}