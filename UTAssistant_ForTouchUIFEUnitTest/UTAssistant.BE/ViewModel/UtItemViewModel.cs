using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

using UTAssistant.BE.Model;

namespace UTAssistant.BE.ViewModel
{
    public class UtItemViewModel : INotifyPropertyChanged
    {
        #region Data

        private readonly ReadOnlyCollection<UtItemViewModel> myChildren;
        private readonly UtItemViewModel myParent;
        private readonly UtItem myItem;

        private bool myIsExpanded;
        private bool myIsSelected;

        private ICommand myRunTestCommand;

        private object myClassInstance;

        #endregion // Data

        #region Constructors

        public UtItemViewModel( UtItem root )
                : this( root, null ) {}

        private UtItemViewModel( UtItem item, UtItemViewModel parent )
        {
            myItem = item;
            myParent = parent;

            myChildren = new ReadOnlyCollection<UtItemViewModel>(
                    (from child in myItem.Children
                     select new UtItemViewModel( child, this ))
                            .ToList<UtItemViewModel>() );

            myRunTestCommand = new RunTestCommand( this );
        }

        public ReadOnlyCollection<UtItemViewModel> Children
        {
            get
            {
                return myChildren;
            }
        }

        public string DisplayName
        {
            get
            {
                return myItem.DisplayName;
            }
        }

        public ItemType ItemType
        {
            get
            {
                return myItem.ItemType;
            }
        }

        #endregion

        private TestResult myTestPassed;

        public TestResult TestPassed
        {
            get
            {
                return myTestPassed;
            }
            set
            {
                if( value != myTestPassed )
                {
                    myTestPassed = value;
                    OnPropertyChanged( "TestPassed" );
                }
            }
        }

        private string myFailedStackTrace;

        public string FailedStackTrace
        {
            get
            {
                return myFailedStackTrace;
            }
            set
            {
                if( value != myFailedStackTrace )
                {
                    myFailedStackTrace = value;
                    OnPropertyChanged( "FailedStackTrace" );
                }
            }
        }

        public UtItem InnerItem
        {
            get
            {
                return myItem;
            }
        }

        public UtItemViewModel Parent
        {
            get
            {
                return myParent;
            }
        }

        public Type TestClass
        {
            get
            {
                return myItem.TestClass;
            }
        }

        public MethodInfo TestMethod
        {
            get
            {
                return myItem.TestMethod;
            }
        }

        public object ClassInstance
        {
            get
            {
                if( myClassInstance == null )
                {
                    myClassInstance = Activator.CreateInstance( TestClass );
                }

                return myClassInstance;
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return myIsExpanded;
            }
            set
            {
                if( value != myIsExpanded )
                {
                    myIsExpanded = value;
                    OnPropertyChanged( "IsExpanded" );
                }

                // Expand all the way up to the root.
                if( myIsExpanded && myParent != null )
                {
                    myParent.IsExpanded = true;
                }
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return myIsSelected;
            }
            set
            {
                if( value != myIsSelected )
                {
                    myIsSelected = value;

                    OnPropertyChanged( "IsSelected" );
                }
            }
        }

        public ICommand RunTestCommand
        {
            get
            {
                return myRunTestCommand;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( string propertyName )
        {
            if( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }

        #endregion // INotifyPropertyChanged Members
    }
}