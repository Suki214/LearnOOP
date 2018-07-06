using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo
{
    public class Casher
    {
        public IGetDiscountStrategy GetDiscountStrategy { get; set; }

        public Casher(IGetDiscountStrategy getDiscountStrategy)
        {
            GetDiscountStrategy = getDiscountStrategy;
        }

        public Casher() : this(null) { }

        public double CalculateProductDiscount(Product product)
        {
            if (GetDiscountStrategy == null)
            {
                return 0;
            }
            return GetDiscountStrategy.GetDiscount(product);
        }
    }
}
