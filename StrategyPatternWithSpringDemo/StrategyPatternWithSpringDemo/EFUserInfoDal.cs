using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternWithSpringDemo
{
    public class EFUserInfoDal : IUserInfoDal
    {
        public void Show()
        {
            Console.WriteLine("我是EF Dal");
        }
    }
}
