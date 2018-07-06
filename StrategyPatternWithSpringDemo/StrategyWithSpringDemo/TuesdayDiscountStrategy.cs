using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo
{
    public class TuesdayDiscountStrategy : IGetDiscountStrategy
    {
        public double GetDiscount(Product product)
        {
            double discount = 0.0;
            switch (product.Kind)
            {
                case Product.ProductKind.A:
                    discount= 0.2;
                    break;
                case Product.ProductKind.B:
                    discount = 0.3;
                    break;
                case Product.ProductKind.C:
                    discount = 0.4;
                    break;
                default:
                    discount = 0.0;
                    break;
            }
            return discount;
        }
    }
}
