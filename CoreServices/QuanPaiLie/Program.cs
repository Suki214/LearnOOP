using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanPaiLie
{
    class Program
    {
        //public static void Swap<T>(ref T a, ref T b)
        //{
        //    T temp = a;
        //    a = b;
        //    b = a;
        //}

        //public static void Perm<T>(T[] list, int begin, int end)
        //{
        //    if (begin == end)
        //    {
        //        for (int i = 0; i <= begin; i++)
        //            Console.Write(list[i]);
        //        Console.WriteLine();
        //    }
        //    else
        //        for (int i = begin; i <= end; i++)
        //        {
        //            Swap<T>(ref list[i], ref list[begin]);
        //            Perm<T>(list, begin + 1, end);
        //            Swap<T>(ref list[i], ref list[begin]);
        //        }
        //}

        ////寻找不相邻的数最大和
        //static int MaxSum(int[] arr)
        //{
        //    int size = arr.Length;
        //    if (size <= 0)
        //        return 0;
        //    else if (size == 1)
        //        return arr[0];

        //    int excl = 0, incl = arr[0];
        //    int excl_new;
        //    for (int i = 1; i < size; i++)
        //    {
        //        excl_new = (excl > incl) ? excl : incl;
        //        incl = excl + arr[i];
        //        excl = excl_new;
        //    }
        //    return (incl > excl) ? incl : excl;
        //}

        ////寻找一数组中一个数，要求左边的都比他小，右边的都比他大
        //static int FindNum(int[] nArr, int nLen)
        //{
        //    //assert(nArr && nLen > 0);
        //    int nPos = 0;
        //    int nCandid = nArr[0];
        //    int nMax = nArr[0];
        //    bool bIsExist = true;
        //    for (int i = 1; i < nLen; i++)
        //    {
        //        if (bIsExist)//候选有效
        //        {
        //            if (nCandid > nArr[i])//候选失效
        //            {
        //                bIsExist = false;
        //            }
        //            else
        //            {
        //                nMax = nArr[i];
        //            }
        //        }
        //        else //候选失效
        //        {
        //            if (nArr[i] >= nMax)//重新找到候选
        //            {
        //                bIsExist = true;

        //                nCandid = nArr[i];
        //                nMax = nArr[i];
        //                nPos = i;
        //            }
        //        }
        //    }
        //    return bIsExist ? nPos : -1;
        //}

        //寻找一个数列排名前N位的数
        //static int FindMaxNums(int[] arr, int n)
        //{
        //    int len = arr.Length;
        //    if (n >= len)
        //    {
        //        for (int i=0;i<=len; i++)
        //        {
        //            Console.Write(arr[i] + " ");
        //        }
        //    }
        //    return arr[0];
        //}


        //static void FindMaxN(int[] a, int start, int end, int N)//从数组a里，找出前N个最大的。如果是a[100],则start = 0， end = 99.注意这个索引问题
        //{
        //    int mid = (start + end) / 2;
        //    int i = start, j = end;
        //    while (i < j)
        //    {
        //        while (i < j && a[i] <= a[mid])
        //            i++;
        //        while (i < j && a[j] >= a[mid])
        //            j--;
        //        swap(ref a[i], ref a[j]);
        //    }
        //    /*注意这个while出来之后，i一定是等于j的，且从i 到 end是较大的那一端*/

        //    if (end - i + 1 == N)
        //        return;
        //    if (end - i + 1 > N)
        //        FindMaxN(a, i, end, N);
        //    else
        //        FindMaxN(a, start, i, N - (end - i + 1));

        //    for (int k = end; k >= end - N + 1; k--)
        //    {
        //        Console.WriteLine(a[k]);
        //    }
        //}

        //private static void swap(ref int v1, ref int v2)
        //{
        //    int temp;
        //    temp = v1;
        //    v1 = v2;
        //    v2 = temp;
        //}

        ////Find 排名靠前的N个数
        //static void FindMaxN(int[] arr, int N)
        //{
        //    int len = arr.Length;
        //    if (N >= len)
        //    {
        //        for (int i = 0; i <= len; i++)
        //        {
        //            Console.Write(arr[i] + " ");
        //        }
        //    }

        //    for(int i = 0; i < len; i++)
        //    {
        //       for( int j = i + 1;j < len; j++)
        //        {
        //            if (arr[j] > arr[i])
        //            {
        //                int temp = arr[j];
        //                arr[j] = arr[i];
        //                arr[i] = temp;
        //            }
        //        }
        //    }

        //    for (int i = 0; i < N; i++)
        //    {
        //        Console.Write(arr[i] + " ");
        //    }
        //}



        static void Main(string[] args)
        {
            //int[] list = { 1, 2, 3, 5, 8, 4, 11 };
            //int result = MaxSum(list);
            //int[] nArr = { 1, 2, 3, 1, 2, 0, 5, 6,7 };
            //int nPos = FindNum(nArr, nArr.Length);
            //if (nPos == -1)
            //{
            //    Console.WriteLine("不存在!");
            //}
            //else
            //{
            //    Console.WriteLine(nArr[nPos]);
            //}

            //int[] list = { 1, 2, 3, 5, 8, 4, 11 };
            // FindMaxN(list,0,list.Length-1, 3 );
            int[] a = { 8, 2, 111, 32, 4, 1000};
            int n, i;
            Console.WriteLine("数组是:\n");
            int an = a.Length ;
            for (i = 0; i < an; ++i)
                Console.WriteLine( a[i]);
            Console.WriteLine("\n");

            Console.WriteLine("你想找最大的前面几个数:");
            // Console.ReadKey("%d", &n);
            n = int.Parse(Console.ReadLine());

             choose_max_n(a, 0, an - 1, n);

          
            Console.ReadKey();
        }

       
        
        /*找出第n大的数的下标*/
        //int choose_nth(int[] a, int startIndex, int endIndex, int n);

        ///*找出前n大的数*/
        //void choose_max_n(int[] a, int startIndex, int endIndex, int n);

        static void choose_max_n(int[] a, int startIndex, int endIndex, int n)
        {
            int i = choose_nth(a, startIndex, endIndex, n);

            Console.WriteLine("最大的前N个数是:\n");
            for (; i <= endIndex; ++i)
                Console.WriteLine( a[i]);
            Console.WriteLine("\n");
        }

        static int choose_nth(int[] a, int startIndex, int endIndex, int n)
        {
            int midOne = a[startIndex];
            int i = startIndex, j = endIndex;
            if (i == j)
                return i;

            if (i < j)
            {
                while (i < j)
                {
                    for (; i < j; j--)
                        if (a[j] < midOne)
                        {
                            a[i++] = a[j];
                            break;
                        }

                    for (; i < j; i++)
                        if (a[i] > midOne)
                        {
                            a[j--] = a[i];
                            break;
                        }
                }

                a[i] = midOne;
                int th = endIndex - i + 1;

                if (th == n)
                {
                    return i;
                }
                else
                {
                    if (th > n)
                    {
                        return choose_nth(a, i + 1, endIndex, n);
                    }
                    else
                    {
                        return choose_nth(a, startIndex, i - 1, n - th);
                    }
                }
            }
            return i;
        }
    }
}
