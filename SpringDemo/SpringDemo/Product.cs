namespace SpringDemo
{
    public class Product
    {
        public enum ProductKind { A, B, C }

        public decimal Price { get; private set; }
        public ProductKind Kind { get; private set; }
        public Product(decimal price, ProductKind productKind)
        {
            Price = price;
            Kind = productKind;
        }
    }
}