using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDemo
{
    class Casher
    {
        public Casher() : this(null) { }
        public Casher(IGetDiscountStrategy getDiscountStrategy)
        {
            DiscountStrategy = getDiscountStrategy;
        }

        public decimal CalculateProductDiscount(Product product)
        {
            return DiscountStrategy == null
                ? 0
                : DiscountStrategy.GetDiscount(product);               
        }
        public IGetDiscountStrategy DiscountStrategy { get; set; }
    }
}
