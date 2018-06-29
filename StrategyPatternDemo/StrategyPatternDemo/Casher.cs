namespace StrategyPatternDemo
{
    internal class Casher
    {
        public Casher() : this( null ) {}

        public Casher( IDiscountStrategy strategy )
        {
            DiscountStrategy = strategy;
        }

        /// <summary>
        /// Get discount
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public decimal CalculateProductDiscount( Product product )
        {
            return DiscountStrategy == null
                           ? 0
                           : DiscountStrategy.GetDiscount( product );
        }

        public IDiscountStrategy DiscountStrategy { get; set; }
    }
}