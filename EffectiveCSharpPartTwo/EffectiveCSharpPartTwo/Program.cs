using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeachDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] nVisited = new int[2, 2];

            //nVisited[0, 0] = 1;
            //nVisited[0, 1] = 2;
            //nVisited[1, 0] = 3;
            //nVisited[1, 1] = 4;

            //foreach (int i in nVisited)
            //{
            //    Console.Write("{0}  ", i.ToString());
            //}

            //Console.WriteLine();

            //for (int i=0;i<nVisited.GetLength (0);i++)
            //    for(int j = 0; j < nVisited.GetLength(1); j++)
            //    {
            //        Console.Write("{0}   ", nVisited[i,j].ToString());
            //    }
            //Console.WriteLine();
            ///*1  2  3  4
            //  1   2   3   4*/


            int[] nArray = new int[100];
            ArrayList arrInt = new ArrayList();
            arrInt.AddRange(nArray);

            foreach (int i in arrInt)
            {
                Console.WriteLine(i.ToString());
            }

            //此foreach等价于以下code：
            IEnumerator it = arrInt.GetEnumerator() as IEnumerator;
            using (IDisposable disp = it as IDisposable)
            {
                while (it.MoveNext())
                {
                    int elem = (int)it.Current;
                    Console.WriteLine(elem.ToString());
                }
            }

            for (int i = 0; i < arrInt.Count; i++)
            {
                int n = (int)arrInt[i];
                Console.WriteLine(n.ToString());
            }

            

                Console.ReadKey();
                
        }
    }
}
