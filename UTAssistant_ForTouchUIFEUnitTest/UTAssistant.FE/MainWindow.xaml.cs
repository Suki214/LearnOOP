using System.Windows;
using System.Windows.Input;

using UTAssistant.BE.ViewModel;

namespace UTAssistant.FE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchTextBoxKeyDown( object sender, KeyEventArgs e )
        {
            if( e.Key == Key.Enter )
            {
                var vm = DataContext as UtTreeViewModel;

                if( vm != null )
                {
                    vm.SearchCommand.Execute( null );
                }
            }
        }

        private void TreeView_OnSelectedItemChanged( object sender, RoutedPropertyChangedEventArgs<object> e )
        {
            var selectedUtItemVm = e.NewValue as UtItemViewModel;
            if( selectedUtItemVm != null )
            {
                FailedStackTraceTextBlock.DataContext = selectedUtItemVm;
            }
        }

        private void OnTreeViewItemSelected( object sender, RoutedEventArgs e )
        {
            e.Handled = true; //to prevent Parent item from being selected!

            FrameworkElement selectedItem = sender as FrameworkElement;
            if( selectedItem != null )
            {
                selectedItem.BringIntoView();
            }
        }
    }
}