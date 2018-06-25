using System.Collections.ObjectModel;
using System.Linq;

namespace ReflecteForUTDemo
{
    public class UtItemViewModel
    {
        private readonly ReadOnlyCollection<UtItemViewModel> myChildren;
        private readonly UtItemViewModel myParent;
        private readonly UtItem myItem;
        private bool myIsExpanded;

        public UtItemViewModel (UtItem root) : this(root, null) { }

        private UtItemViewModel(UtItem  item, UtItemViewModel parent)
        {
            myItem = item;
            myParent = parent;
            myChildren = new ReadOnlyCollection<UtItemViewModel>((from child in myItem.Children select new UtItemViewModel(child, this)).ToList<UtItemViewModel>());
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
                }
                if(myIsExpanded && myParent != null)
                {
                    myParent.IsExpanded = true;
                }
            }
        }
    }
}