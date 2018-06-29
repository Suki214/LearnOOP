using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayButtonDemo
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:PlayButtonDemo"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:PlayButtonDemo;assembly=PlayButtonDemo"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:PlayButton/>
    ///
    /// </summary>
    public class PlayButton : Button
    {
        static PlayButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlayButton), new FrameworkPropertyMetadata(typeof(PlayButton)));
        }

        public static readonly DependencyProperty IsPausedProperty = DependencyProperty.Register("IsPaused", typeof(bool), typeof(PlayButton), new PropertyMetadata(true));
        public static readonly DependencyProperty IconColorProperty = DependencyProperty.Register("IconColor", typeof(Brush), typeof(PlayButton), new PropertyMetadata(Brushes.Blue));

        public bool IsPaused
        {
            get
            {
                return (bool)GetValue(IsPausedProperty);
            }
            set
            {
                SetValue(IsPausedProperty, value);
            }
        }
        //public bool IsPaused
        //{
        //    get;
        //    set;
        //}

        public Brush IconColor
        {
            get
            {
                return GetValue(IconColorProperty) as Brush;
            }
            set
            {
                SetValue(IconColorProperty, value);
            }
        }

        public MediaElement theMedia;

        

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            theMedia = FindName("TheMedia") as MediaElement;
            this.Click += OnButtonClicked;

        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            IsPaused = !IsPaused;
            if (IsPaused)
            {
                theMedia.Pause();
            }
            else
            {
                theMedia.Play();
            }
            
            

        }


    }
}
