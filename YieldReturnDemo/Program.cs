using System;
using System.Collections.Generic;

namespace YieldReturnDemo
{/// <summary>
/// 单步调试看yield return很直观
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //这个循环，第一次执行FilterWithoutYield结束就拿到了所有的结果
            foreach (var item in FilterWithoutYield)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //通过这个foreach循环，每次循环执行一次FilterWithYield，返回一个结果
            foreach (var item in FilterWithYield)
            {
                Console.WriteLine(item);
            }
            //这俩运行结果完全一致
        }

        public static List<int> Data
        {
            get
            {
                return new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8 };
            }
        }

        public static IEnumerable<int> FilterWithoutYield
        {
            get
            {
                var result = new List<int>();
                foreach (var i in Data)
                {
                    if (i > 4)
                    {
                        result.Add(i);
                    }
                }                    
                return result;                
            }
        }

        //当希望获取一个IEnumerable<T>类型的集合，而不想把数据一次性加载到内存，就可以考虑用Yield return
        //这个循环，每次那都第一个结果就退出
        public static IEnumerable<int> FilterWithYield
        {
            get
            {
                foreach(var i in Data)
                {
                    if (i > 4)
                    {
                        yield return i;
                    }
                }
            }
        }
    }
}
