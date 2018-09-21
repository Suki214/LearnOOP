using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaddlePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("计算矩阵鞍点（行最大，列最小）");
            while (true)
            {
                Console.WriteLine("任意键继续，0退出");
                string select = Console.ReadLine();
                if (select == "0")
                {
                    Console.WriteLine("已退出！");
                    break;
                }
                else
                {
                    int[,] arr = new int[100, 100];//该数组
                    int m, n;
                    Console.Write("请输入二维数组的行数（小与100）：");
                    m = int.Parse(Console.ReadLine());//矩阵行数
                    Console.Write("请输入二维数组的列数（小与100）：");
                    n = int.Parse(Console.ReadLine());//矩阵列数
                    int i, j;
                    //输入该矩阵
                    Console.WriteLine("请输入" + m + "x" + n + "的矩阵");
                    for (i = 0; i < m; i++)
                    {
                        for (j = 0; j < n; j++)
                        {
                            arr[i, j] = int.Parse(Console.ReadLine());
                            //Convert.ToInt32(Console.Read());
                        }
                    }
                    //输出打印该矩阵

                    for (i = 0; i < m; i++)
                    {
                        if (i == m / 2)
                        {
                            Console.Write("A = ");
                        }
                        for (j = 0; j < n; j++)
                        {
                            if (i == m / 2)
                            {
                                Console.Write(arr[i, j] + "    ");
                            }
                            else
                            {
                                Console.Write("    " + arr[i, j]);
                            }
                        }
                        Console.WriteLine();
                    }

                    int row_max;//先找到该行的最大值
                    int[] an_point = new int[100];//存储矩阵中所有鞍点
                    int count = 0;//鞍点个数
                    int temp1 = 0, temp2 = 0;//暂时保存该行最大值的位置
                    int[] x = new int[100];//保存鞍点的横坐标
                    int[] y = new int[100];//保存鞍点的纵坐标
                    bool flag = false;//判断是否是鞍点

                    for (i = 0; i < m; i++)
                    {
                        row_max = arr[i, 0];//令某行最大的等于该行第一个数
                        for (j = 0; j < n; j++)
                        {
                            if (row_max < arr[i, j])
                            {
                                row_max = arr[i, j];//找到该行最大值  
                                //记录该数的位置
                                temp1 = i;
                                temp2 = j;
                            }
                        }
                        //找到最大值后判断该值在该列是否是最小值
                        for (int k = 0; k < m; k++)
                        {
                            if ((arr[k, temp2] < row_max) || (arr[k, temp2] == row_max && k != temp1))//不是最小值
                            {
                                flag = false;
                                break;
                            }
                            else//是最小值
                            {
                                flag = true;
                            }
                        }
                        //是鞍点
                        if (flag == true)
                        {
                            count++;//鞍点个数加一
                            an_point[count] = arr[temp1, temp2];//保存鞍点
                            //保存鞍点位置
                            x[count] = temp1 + 1;
                            y[count] = temp2 + 1;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("该矩阵无鞍点！");
                    }
                    else
                    {
                        Console.WriteLine("该矩阵有" + count + "个鞍点");
                        Console.WriteLine("分别是：");
                        for (int p = 1; p <= count; p++)
                        {
                            Console.Write("A[" + x[p] + "," + y[p] + "]=");
                            Console.WriteLine(an_point[p]);
                        }
                    }
                }
            }//结束
        }
    }
}
