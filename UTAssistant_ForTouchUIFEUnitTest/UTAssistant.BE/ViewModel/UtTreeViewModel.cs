using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using UTAssistant.BE.Model;

namespace UTAssistant.BE.ViewModel
{
    public class UtTreeViewModel
    {
        private readonly ReadOnlyCollection<UtItemViewModel> myUtProjects;
        private readonly ICommand mySearchCommand;

        private IEnumerator<UtItemViewModel> myMatchingEnumerator;
        private string mySearchText = String.Empty;
        private readonly UtItemViewModel myTreeRoot;

        public UtTreeViewModel( UtItem root )
        {
            myTreeRoot = new UtItemViewModel( root ) {IsExpanded = true};

            myUtProjects = new ReadOnlyCollection<UtItemViewModel>( new[] {myTreeRoot} );

            mySearchCommand = new SearchTreeCommand( this );
        }

        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<UtItemViewModel> UtProjects
        {
            get
            {
                return myUtProjects;
            }
        }

        /// <summary>
        /// Gets/sets a fragment of the name to search for.
        /// </summary>
        public string SearchText
        {
            get
            {
                return mySearchText;
            }
            set
            {
                if( value == mySearchText )
                {
                    return;
                }

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

        private void PerformSearch()
        {
            if( myMatchingEnumerator == null || !myMatchingEnumerator.MoveNext() )
            {
                VerifyMatchingEnumerator();
            }

            var itemViewModel = myMatchingEnumerator.Current;

            if( itemViewModel == null )
            {
                return;
            }

            // Ensure that this itemViewModel is in view.
            if( itemViewModel.Parent != null )
            {
                itemViewModel.Parent.IsExpanded = true;
            }

            itemViewModel.IsSelected = true;
        }

        private void VerifyMatchingEnumerator()
        {
            var matches = FindMatches( mySearchText, myTreeRoot );
            myMatchingEnumerator = matches.GetEnumerator();

            if( !myMatchingEnumerator.MoveNext() )
            {
                //"No matching names were found.",
            }
        }

        private IEnumerable<UtItemViewModel> FindMatches( string searchText, UtItemViewModel utItemViewModel )
        {
            if( DisplayNameMatch( utItemViewModel, searchText ) )
            {
                yield return utItemViewModel;
            }

            foreach( UtItemViewModel child in utItemViewModel.Children )
            {
                foreach( UtItemViewModel match in FindMatches( searchText, child ) )
                {
                    yield return match;
                }
            }
        }

        private bool DisplayNameMatch( UtItemViewModel itemViewModel, string text )
        {
            if( String.IsNullOrEmpty( text ) || String.IsNullOrEmpty( itemViewModel.DisplayName ) )
            {
                return false;
            }

            return itemViewModel.DisplayName.IndexOf( text, StringComparison.InvariantCultureIgnoreCase ) > -1;
        }

        private class SearchTreeCommand : ICommand
        {
            private readonly UtTreeViewModel myTree;

            public SearchTreeCommand( UtTreeViewModel tree )
            {
                myTree = tree;
            }

            public bool CanExecute( object parameter )
            {
                return true;
            }

            event EventHandler ICommand.CanExecuteChanged
            {
                add {}
                remove {}
            }

            public void Execute( object parameter )
            {
                myTree.PerformSearch();
            }
        }
    }
}