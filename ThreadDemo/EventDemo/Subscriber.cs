using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    //定义事件订阅者
    class Subscriber
    {
        //订阅事件的方法的命名，通常为“On事件名”
        public void OnNumberChanged(int number)
        {
            Console.WriteLine("Count is {0}", number);
           
        }
    }
}
