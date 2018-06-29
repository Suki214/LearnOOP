using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDemo
{
    class StrategyForMonday : IGetDiscountStrategy
    {
        public decimal GetDiscount(Product product)
        {
            if (product.Price > 200)
            {
                return 10;
            }
            else if(product.Price>100)
            {
                return 5;
            }
            else
            {
                return 1;
            }
        }
    }
}
