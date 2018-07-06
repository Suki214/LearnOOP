using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyWithSpringDemo
{
    public class Product
    {
        public enum ProductKind { A,B,C}

        public double Price { get; set; }

        public ProductKind Kind { get; set; }
        public Product(double price, ProductKind kind)
        {
            Price = price;
            Kind = kind;
        }
    }
}
