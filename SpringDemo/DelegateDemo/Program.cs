using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public  delegate void MakeGreeting(string name);
    class Program
    {
        static void Main(string[] args)
        {
            //GreetingPeople("Jim", EnglishGreeting);
            //GreetingPeople("张", ChineseGreeting);
            ////Hello, Jim!
            ////张 你好！

            //MakeGreeting makeGreeting;
            //makeGreeting = ChineseGreeting;
            //makeGreeting += EnglishGreeting;
            ////第一次加载委托必须=，第二次用+=，如果第一次用+=，必报编译错:Use of unassigned local variable 'makeGreeting'/使用了未赋值的局部变量
            //makeGreeting("Jim");
            //GreetingPeople("Jim", makeGreeting); //has the same result as previous code
            //Jim 你好！
            //Hello, Jim!


            MakeGreeting delegate1 = new MakeGreeting(EnglishGreeting);
            delegate1 += ChineseGreeting; // 给此委托变量再绑定一个方法
                                              // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            GreetingPeople("Jimmy Zhang", delegate1);
            
            delegate1 -= EnglishGreeting; // 取消对EnglishGreeting方法的绑定
                                              // 将仅调用 ChineseGreeting
            GreetingPeople("张子阳", delegate1);

            Console.ReadKey();
        }

        
        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("{0} 你好！",name);
        }

        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }

        public static void GreetingPeople(string name, MakeGreeting makeGreeting)
        {
            makeGreeting(name);
        }
    }
}
