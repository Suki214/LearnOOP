using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringDemo
{
    interface IGetDiscountStrategy
    {
        decimal GetDiscount(Product product);
    }
}
