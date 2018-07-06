using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo.SpringHelper
{
    interface ISpringContext:IDisposable
    {
        //where T : class 表示约束泛型参数 T 必须是引用类型，不能是值类型
        T GetObject<T>(string springObjectName) where T:class;
    }
}
