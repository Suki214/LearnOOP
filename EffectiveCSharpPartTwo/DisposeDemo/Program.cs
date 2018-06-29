using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string yourConnectionString=null;
            string yourQueryString=null;

            SqlConnection sqlConn = new SqlConnection(yourConnectionString);
            SqlCommand sqlComm = new SqlCommand(yourQueryString,sqlConn);

            //point 2
            object sqlObj = sqlConn;
            //using (sqlObj)////'string': type used in a using statement must be implicitly convertible to 'System.IDisposable'
            using (sqlObj as IDisposable)//可以用as进行类型转化
            using (sqlComm as IDisposable)
            {
                try//point 1
                {
                    sqlConn.Open();
                    sqlComm.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine(err.Message);
                }
                catch(Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }

            //point3
            //using (string strMsg = "My Test")//'string': type used in a using statement must be implicitly convertible to 'System.IDisposable'
            //    Console.WriteLine(strMsg);


            //try
            //{
            //    sqlConn.Open();
            //}
            //finally
            //{
            //    if (sqlConn != null)
            //        sqlConn.Dispose();
            //}


            string strValue = "Hello";
            // strValue += " World!";//会产生两个string，用make object ID
            strValue =string.Format("{0} world!", strValue);//???也会产生新的对象

            StringBuilder strb = new StringBuilder ( "Hi");
            strb.Append(" world!");//只产生一个类型


            string str1 = "wang";
            string str2 = str1;
            str1 = "yang";
            Console.WriteLine(str2);//wang
            Console.WriteLine(str1);//yang

            Console.ReadKey();
        }
    }
}
