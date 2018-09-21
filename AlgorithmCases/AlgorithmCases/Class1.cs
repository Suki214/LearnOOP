using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCases
{
    class Class1
    {
        private string strValue;
        public string StrValue
        {
            get { return strValue; }
            set { strValue = value; }
        }

        public Class1()
        {
            Console.WriteLine("constructor");
        }
    }
}
