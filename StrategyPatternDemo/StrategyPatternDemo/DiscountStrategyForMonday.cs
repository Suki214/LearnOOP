namespace StrategyPatternDemo
{
    internal class DiscountStrategyForMonday : IDiscountStrategy
    {
        public decimal GetDiscount( Product product )
        {
            if( product.Price > 100 )
            {
                return 10;
            }
            if( product.Price > 200 )
            {
                return 30;
            }

            return 0;
        }
    }
}