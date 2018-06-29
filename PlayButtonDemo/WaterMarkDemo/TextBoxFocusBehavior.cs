using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WaterMarkDemo
{
    public static class TextBoxFocusBehavior
    {

        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkPropertyProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for WatermarkProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkPropertyProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxFocusBehavior), new UIPropertyMetadata(string.Empty, OnWatermarkExchanged));

        private static void OnWatermarkExchanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = d as TextBox;
                if(tb!=null)
                {
                    tb.Text = e.NewValue as string;
                }
        }




        public static bool GetIsWatermarkEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsWatermarkEnabledProperty);
        }

        public static void SetIsWatermarkEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsWatermarkEnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsWatermarkEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWatermarkEnabledProperty =
            DependencyProperty.RegisterAttached("IsWatermarkEnabled", typeof(bool), typeof(TextBoxFocusBehavior), new UIPropertyMetadata(false, OnIsWatermarkEnabled));

        private static void OnIsWatermarkEnabled(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = d as TextBox;
            if(tb !=null)
            {
                bool isEnabled = (bool)e.NewValue;
                if (isEnabled)
                {
                    tb.GotFocus += tb_GotFocus;
                    tb.LostFocus += tb_LostFocus;
                }
                else
                {
                    tb.GotFocus -= tb_GotFocus;
                    tb.LostFocus -= tb_LostFocus;
                }
            }
        }

        static void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = e.OriginalSource as TextBox;
            if (tb != null)
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    tb.Text = GetWatermark(tb);
                }
            }
        }

        static void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = e.OriginalSource as TextBox;
            if (tb != null)
            {
                if (tb.Text == GetWatermark(tb))
                {
                    tb.Text = string.Empty;
                }
            }
        }


    }
}
