using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDemo
{
    class StrategyForTuesday : IGetDiscountStrategy
    {
        public decimal GetDiscount(Product product)
        {
            if (product.Kind == Product.ProductKind.A)
            {
                return 5;
            }
            return 1;
        }
    }
}
