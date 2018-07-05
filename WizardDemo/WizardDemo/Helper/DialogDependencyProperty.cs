using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WizardDemo.Helper
{
    public static class DialogDependencyProperty
    {
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.Register("DialogResult", typeof(bool?), typeof(DialogDependencyProperty), new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window= d as Window;
            if(window!=null && window.IsVisible)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }
    }
}
