using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexDemo
{
    class Team
    {
        string[] name = new string[8];
        public string this[int index]
        {
            get { return name[index]; }
            set { name[index] = value; }
        }
    }
}
