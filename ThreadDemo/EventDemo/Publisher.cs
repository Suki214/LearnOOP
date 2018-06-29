using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    //定义委托，指定function签名
    public delegate void NumberChangedEventHandler(int count);
    class Publisher
    {
        private int number;
        //public NumberChangedEventHandler NumberChanged; //声明委托变量
         public event NumberChangedEventHandler NumberChanged; //声明一个事件
        //public List<string> DoSomething()
        //{
        //    List<string> strList = new List<string>();
        //    if (NumberChanged == null) return strList;

        //    Delegate[] delArray = NumberChanged.GetInvocationList();

        //    foreach (Delegate del in delArray)
        //    {
        //        NumberChangedEventHandler method = (NumberChangedEventHandler)del;
        //        strList.Add(method(10));
        //        //strList.Add(NumberChanged(5));
        //    }
        //    return strList;
        //}

        //public void DoSomething()
        //{
        //    if (NumberChanged != null)
        //    {
        //        try
        //        {
        //            NumberChanged(100);
        //        }
        //        catch(Exception e)
        //        {
        //            Console.WriteLine("Exception:{0}", e.Message);
        //        }
        //    }
        //}


        public static object[] FireEvent(Delegate del, params object[] args)
        {
            List<object> objList = new List<object>();

            if(del != null)
            {
                Delegate[] delArray = del.GetInvocationList();
                foreach(Delegate method in delArray)
                {
                    try
                    {
                        object obj = method.DynamicInvoke(args);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("exception {0}", e.Message);
                    }

                }
            }
            return objList.ToArray();
        }

        public void DoSomething()
        {
            FireEvent(NumberChanged, 100);            
        }
    }
}
