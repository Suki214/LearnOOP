/******************************************************
 *                      NOTICE
 * 
 * THIS SOFTWARE IS THE PROPERTY OF AND CONTAINS
 * CONFIDENTIAL INFORMATION OF INFOR AND SHALL NOT
 * BE DISCLOSED WITHOUT PRIOR WRITTEN PERMISSION.
 * LICENSED CUSTOMERS MAY COPY AND ADAPT THIS
 * SOFTWARE FOR THEIR OWN USE IN ACCORDANCE WITH
 * THE TERMS OF THEIR SOFTWARE LICENSE AGREEMENT.
 * ALL OTHER RIGHTS RESERVED.
 * 
 * COPYRIGHT (c) 2011 - 2012 INFOR. ALL RIGHTS RESERVED.
 * THE WORD AND DESIGN MARKS SET FORTH HEREIN ARE
 * TRADEMARKS AND/OR REGISTERED TRADEMARKS OF INFOR
 * AND/OR RELATED AFFILIATES AND SUBSIDIARIES. ALL
 * RIGHTS RESERVED. ALL OTHER TRADEMARKS LISTED
 * HEREIN ARE THE PROPERTY OF THEIR RESPECTIVE
 * OWNERS. WWW.INFOR.COM.
 * 
 * *****************************************************
 */
using System.Windows;
using System.Windows.Input;

namespace Infor.QAA.Enterprise.Migration.Helper
{
    public static class DialogDependencyProperty
    {
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogDependencyProperty),
                new PropertyMetadata(DialogResultChanged));

        public static void DialogResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null && window.IsVisible)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }

        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }

        public static DependencyProperty LoadedCommandProperty = DependencyProperty.RegisterAttached(
             "LoadedCommand", typeof(ICommand), typeof(DialogDependencyProperty), new PropertyMetadata(null, OnLoadedCommandChanged));

        private static void OnLoadedCommandChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = depObj as FrameworkElement;
            if (frameworkElement != null && e.NewValue is ICommand)
            {
                frameworkElement.Loaded += (o, args) =>
                {
                    (e.NewValue as ICommand).Execute(null);
                };
            }
        }

        public static ICommand GetLoadedCommand(Window depObj)
        {
            return (ICommand)depObj.GetValue(LoadedCommandProperty);
        }

        public static void SetLoadedCommand(Window depObj, ICommand value)
        {
            depObj.SetValue(LoadedCommandProperty, value);
        }
    }
}
