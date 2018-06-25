using ReflecteForUTDemo;
using System.Collections.ObjectModel;

namespace ReflectionDemo
{
    public class UtTreeViewModel
    {
        private readonly ReadOnlyCollection<UtItemViewModel> myUtProjects;
        private readonly UtItemViewModel myTreeRoot;

        public UtTreeViewModel(UtItem root)
        {
            myTreeRoot = new UtItemViewModel(root) {IsExpanded = true };
            myUtProjects = new ReadOnlyCollection<UtItemViewModel>(new[] { myTreeRoot });
        }

        public ReadOnlyCollection<UtItemViewModel> UtProjects
        {
            get
            {
                return myUtProjects;
            }
        }
    }
}