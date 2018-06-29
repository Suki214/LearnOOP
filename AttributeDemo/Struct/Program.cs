using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public struct ErrorMsg
    {
        private string strMsg;
        public string Message
        {
            get
            {
                if (strMsg == null) return string.Empty;
                else
                    return strMsg;
            }
        }
    }

    public struct IntArray
    {
        private int[] nArray;
        public int[] Array
        {
            get
            {
                if (nArray == null) nArray = new int[10];
                return nArray;
            }
        }
    }
}
