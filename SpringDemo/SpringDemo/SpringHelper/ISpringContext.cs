using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDemo.SpringHelper
{
    interface ISpringContext:IDisposable
    {
        T GetObject<T>(string springObjectName) where T : class;
    }
}
