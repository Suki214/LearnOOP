namespace Calculator
{
    internal class OperateDelete:Operation
    {
        public override double GetResult()
        {
            return NumA - NumB;
        }
    }
}