using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Reflector4DynamicInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly amb = Assembly.GetExecutingAssembly();
            ////this is Object type, if need to use it, need conversion to specific type
            //Object obj = amb.CreateInstance("Reflector4DynamicInstance.Calculator",true);
            //Console.WriteLine(obj);//Calculator() invoked without params

            //ObjectHandle oh = Activator.CreateInstance(null,"Reflector4DynamicInstance.Calculator");
            //object obj1 = oh.Unwrap();
            //Console.WriteLine(obj1);//Calculator() invoked without params

            //Assembly amb1 = Assembly.GetExecutingAssembly();
            //object[] parameters = new object[2];
            //parameters[1] = 3;
            //parameters[0]= 5;
            //object obj2 = amb1.CreateInstance("Reflector4DynamicInstance.Calculator", true, BindingFlags.Default, null,parameters, null, null);
            //Console.WriteLine(obj2);//Calculator invoked with params x & y

            //Type t = typeof(Calculator);
            //Calculator c = new Calculator(2, 5);
            //int result = (int)t.InvokeMember("Add", BindingFlags.InvokeMethod, null, c, null);
            //Console.WriteLine("The result is {0}", result);
            ////Calculator invoked with params x & y
            ////instance method: 2 plus 5 equals to 7
            ////The result is 7

            //object[] parameters = { 2, 3 };
            //Type t = typeof(Calculator);
            //t.InvokeMember("Add", BindingFlags.InvokeMethod, null, t, parameters);
            ////static method: 2 plus 3 equals to 5

            //Type t = typeof(Calculator);
            //Calculator c = new Calculator(3, 5);
            //MethodInfo info = t.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);//按位或运算
            //info.Invoke(c, null);
            ////Calculator invoked with params x & y
            ////instance method: 3 plus 5 equals to 8

            Type t = typeof(Calculator);
            object[] parameters = new object[] { 2, 4 };
            MethodInfo info = t.GetMethod("Add", BindingFlags.Static | BindingFlags.Public);//按位或运算
            info.Invoke(null, parameters);
            //static method: 2 plus 4 equals to 6
            Console.ReadKey();
        }
    }
}
