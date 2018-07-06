using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo
{
    public interface IGetDiscountStrategy
    {
        double GetDiscount(Product product);
    }
}
