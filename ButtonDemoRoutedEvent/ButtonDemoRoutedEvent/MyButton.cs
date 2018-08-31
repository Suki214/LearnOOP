using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ButtonDemoRoutedEvent
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ButtonDemoRoutedEvent"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ButtonDemoRoutedEvent;assembly=ButtonDemoRoutedEvent"
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
    ///     <MyNamespace:MyButton/>
    ///
    /// </summary>
    public class MyButton : Button
    {
        public static readonly RoutedEvent MyTextChangedEvent;
        static MyButton()
        {
            MyTextChangedEvent = TextBoxBase.TextChangedEvent.AddOwner(typeof(MyButton));
            RightDragEvent = EventManager.RegisterRoutedEvent("RightDrag", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyButton));
        }
        public event TextChangedEventHandler MyTextChanged
        {
            add { AddHandler(MyTextChangedEvent, value); }
            remove { RemoveHandler(MyTextChangedEvent, value); }
        }

        protected virtual void OnMyTextChanged()
        {
            TextChangedEventArgs textChangedEventArgs = new TextChangedEventArgs(MyTextChangedEvent, UndoAction.Undo);
            RaiseEvent(textChangedEventArgs);
        }

        public MyButton()
        {
            this.Click += new RoutedEventHandler(MyButton_Click);
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = this.Content + " Button";
            OnMyTextChanged();
        }


        public static readonly RoutedEvent RightDragEvent;

        public event RoutedEventHandler RightDrag
        {
            add { AddHandler(RightDragEvent,value); }
            remove { RemoveHandler(RightDragEvent, value); }
        }

        protected virtual void OnRightDrag()
        {
            RoutedEventArgs args = new RoutedEventArgs();
            this.RaiseEvent(args);
        }

        void MyButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                OnRightDrag();
            }
        }

    }
}
