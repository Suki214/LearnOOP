using ReflecteForUTDemo.ReflectionDemo.BE;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace ReflecteForUTDemo
{
    public class UtItemViewModel:INotifyPropertyChanged
    {
        private readonly ReadOnlyCollection<UtItemViewModel> myChildren;
        private readonly UtItemViewModel myParent;
        private readonly UtItem myItem;
        private bool myIsExpanded;
        private bool myIsSelected;
        private object myClassInstance;
        private ICommand myRunTestCommand;

        public ICommand RunTestCommand { get => myRunTestCommand; }

        public UtItemViewModel (UtItem root) : this(root, null) { }

        private UtItemViewModel(UtItem  item, UtItemViewModel parent)
        {
            myItem = item;
            myParent = parent;
            myChildren = new ReadOnlyCollection<UtItemViewModel>(
                (from child in myItem.Children
                 select new UtItemViewModel(child, this))
                 .ToList<UtItemViewModel>());
            myRunTestCommand = new RunTestCommand(this);

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

        public bool IsExpanded
        {
            get
            {
                return myIsExpanded;
            }

            set
            {
                if (myIsExpanded != value)
                {
                    myIsExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }
                if(myIsExpanded && myParent != null)
                {
                    myParent.IsExpanded = true;
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return myIsSelected;
            }
            set
            {
                if(myIsSelected != value)
                {
                    myIsSelected = value;
                    OnPropertyChanged("IsSelected");
                }

            }
        }

        public object ClassInstance
        {
            get
            {
                if (myClassInstance == null)
                {
                    myClassInstance = Activator.CreateInstance(TestClass);
                }
                return myClassInstance;
            }
        }

        public UtItem InnerItem
        {
            get
            {
                return myItem;
            }
        }

        private TestResult myTestPassed;
        public TestResult TestPassed { get => myTestPassed;
            set
            {
                if(value != myTestPassed)
                {
                    myTestPassed = value;
                    OnPropertyChanged("TestPassed");
                }
            }
        }

        private string myFailedStackTrace;
        public string FailedStackTrace { get=>myFailedStackTrace; set {
                if (value != myFailedStackTrace)
                {
                    myFailedStackTrace = value;
                    OnPropertyChanged("FailedStackTrace");
                }
            } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}