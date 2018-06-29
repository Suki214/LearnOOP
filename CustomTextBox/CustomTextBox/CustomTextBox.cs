using System;
using System.Windows;
using System.Windows.Controls;


namespace CustomTextBox
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomTextBox"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomTextBox;assembly=CustomTextBox"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomTextBox/>
    ///
    /// </summary>
    public class CustomTextBox : TextBox
    {


        public string TextValue
        {
            get { return (string)GetValue(TextValuePropertyProperty); }
            set { SetValue(TextValuePropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextValueProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextValuePropertyProperty =
            DependencyProperty.Register("TextValue", typeof(string), typeof(CustomTextBox), new PropertyMetadata(""));


        static CustomTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(typeof(CustomTextBox)));
        }

        private CustomButton.CustomButton myButton = new CustomButton.CustomButton();

        public CustomButton.CustomButton MyButton { get => myButton; set => myButton = value; }

        public CustomTextBox()
        {
            //添加事件到myButton中，当myButton被单击的时候就会调用相应的处理函数
            //myButton.ClickEvent += new ClickEventHandler(OnClickEvent);
            myButton.ClickEvent += this.OnClickEvent;
        }
        //事件处理函数
        void OnClickEvent(object sender, EventArgs e)
        {
            TextValue = "Clicked";
        }
    //}
}
}
