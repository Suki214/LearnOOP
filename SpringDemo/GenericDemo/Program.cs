using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    using IntList = List<int>;
    using CharList = List<Char>;
    class Program
    {
        static void Main(string[] args)
        {
            IntList list = new IntList();
            CharList clist = new CharList();
            clist.Add('B');
            int i = 100;
            list.Add(i);
            string value = list[0].ToString();//使用泛型，编译出错，提示类型转换不对
            string charValue = clist[0].ToString();//使用泛型，编译出错，提示类型转换不对
            Console.WriteLine("value {0} + charValue {1}", value, charValue);



            Console.ReadKey();
        }
    }


    //public interface ICar
    //{
    //    //是汽车就会跑
    //    void Run();
    //}
    //public interface IDriver
    //{
    //    //是司机就会开车
    //    void Drive(ICar car);   //在接口就注入依赖，注入的是接口之间的依赖
    //}
    //public class Driver : IDriver
    //{//司机主要职责就是开车
    //    public void Drive(ICar car)
    //    {
    //        car.Run();
    //    }
    //}

}