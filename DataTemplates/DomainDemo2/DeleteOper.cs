using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDemo2
{
     class DeleteOper
    {
        private int A = 10;
        protected virtual int Delete()
        {
            A = A - 1;
            return A;
        }
    }
}
