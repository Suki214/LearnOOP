using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternDemo
{
    public enum ProductKind { A,B,C}
    internal class Product
    {
        public Product(decimal price, ProductKind productKind)
        {
            Price = price;
            ProductKind = productKind;
        }
        public decimal Price { get; private set; }

        public ProductKind ProductKind { get; private set; }
    }
}
