using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveDemo
{
    class MyClass : IMsg
    {
        public void Message()
        {
            ShowMessage();
        }
        public virtual void ShowMessage()
        {
            Console.WriteLine("MyClass");
        }
    }
}
