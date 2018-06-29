using ReflectionDemo;
using System;
using System.Windows.Input;

namespace ReflecteForUTDemo.ReflectionDemo.BE
{
    public class SearchTreeCommand : ICommand
    {
        private readonly UtTreeViewModel myTree;

        public SearchTreeCommand(UtTreeViewModel tree)
        {
            myTree = tree;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myTree.PerformSearch();
        }
    }
}
