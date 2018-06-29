using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReflecteForUTDemo;

namespace ReflectionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ////this.DataContext = this;

            //Program p = new Program();
            //var root = p.GetTree();
            //var projects = new UtTreeViewModel(root);
            //this.DataContext = projects;

            //this.ShowDialog();
        }
        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var vm = DataContext as UtTreeViewModel;
                if (vm != null)
                {
                    vm.SearchCommand.Execute(null);
                }
            }
        }
        private void UtsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedUtItemVm = e.NewValue as UtItemViewModel;
            if (selectedUtItemVm != null)
            {
                FailedStackTraceTextBlock.DataContext = selectedUtItemVm;
            }
        }        
    }
}
