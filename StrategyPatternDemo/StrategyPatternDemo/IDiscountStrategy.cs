namespace StrategyPatternDemo
{
    internal interface IDiscountStrategy
    {
        decimal GetDiscount( Product p );
    }
}