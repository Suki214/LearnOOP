using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormDemo
{
    class MyForm:Form
    {
        //Method1, more effective, to ovverride the OnMouseDown, and catch the exception in try block
        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                HandledMouseDown(e);
            }
            catch
            { }
            base.OnMouseDown(e);
        }
        //Method2, new a event handler, but this method will not catch the exception
        public MyForm()
        {
            this.MouseDown += new MouseEventHandler(MyForm_MouseDown);
        }
        private void MyForm_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                HandledMouseDown(e);
            }
            catch
            { }
        }
        private void HandledMouseDown(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
