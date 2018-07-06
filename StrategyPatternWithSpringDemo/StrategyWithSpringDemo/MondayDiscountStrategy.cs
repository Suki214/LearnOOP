using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo
{
    public class MondayDiscountStrategy : IGetDiscountStrategy
    {
        public double GetDiscount(Product product)
        {
            double discount = 0.0;
            if (product.Price > 300)
            {
                discount = 0.2;
            }
            else if (product.Price > 200)
            {
                discount = 0.1;
            }
            else
            {
                discount = 0.05;
            }
            return discount;
        }
    }
}
