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

namespace WaterMarkDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ///
        ///Method 1, use LostFocus and GotFocus event to deal with watermark
        ///
        //    private void OnInputTextBoxGotFocus(object sender, RoutedEventArgs e)
        //{
        //    var tb = e.OriginalSource as TextBox;
        //    if (tb != null)
        //        ClearTextBox(tb);
        //}

        //private void ResetTextBox(TextBox tb)
        //{
        //    if (tb.Name == "tbWhat")
        //        if (string.IsNullOrEmpty(tb.Text))
        //            tb.Text = "What.";
        //    if (tb.Name == "tbWhere")
        //        if (string.IsNullOrEmpty(tb.Text))
        //            tb.Text = "Where.";
        //}

        //private void ClearTextBox(TextBox tb)
        //{
        //    if (tb.Name == "tbWhat")
        //        if (tb.Text == "What.")
        //            tb.Text = string.Empty;
        //    if (tb.Name == "tbWhere")
        //        if (tb.Text == "Where.")
        //            tb.Text = string.Empty;
        //}

        //private void OnInputTextBoxLostFocus(object sender, RoutedEventArgs e)
        //{
        //    var tb = e.OriginalSource as TextBox;
        //    if (tb != null)
        //        ResetTextBox(tb);
        //}
        }

        

    
}
