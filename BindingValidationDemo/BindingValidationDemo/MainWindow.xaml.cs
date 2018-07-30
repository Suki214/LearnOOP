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

namespace BindingValidationDemo
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

        private void UseCustomHandler(object sender, RoutedEventArgs e)
        {
            var myBIndingExpression =textBox3.GetBindingExpression(TextBox.TextProperty);
            var myBinding = myBIndingExpression.ParentBinding;
            myBinding.UpdateSourceExceptionFilter = ReturnExceptionHandler;
            myBIndingExpression.UpdateSource();
        }

        private object ReturnExceptionHandler(object bindExpression, Exception exception) => "This is from the UpdateSourceExceptionFilterCallBack.";

        private void DisableCustomHandler(object sender, RoutedEventArgs e)
        {
            var myBinding = BindingOperations.GetBinding(textBox3, TextBox.TextProperty);
            myBinding.UpdateSourceExceptionFilter -= ReturnExceptionHandler;
            BindingOperations.GetBindingExpression(textBox3, TextBox.TextProperty).UpdateSource();
        }
        
    }
}
