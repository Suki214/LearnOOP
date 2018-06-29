namespace StrategyPatternDemo
{
    internal class DiscountStrategyForTuesday : IDiscountStrategy
    {
        public decimal GetDiscount( Product p )
        {
            if( p.ProductKind == ProductKind.A )
            {
                return 15;
            }
            return 0;
        }
    }
}