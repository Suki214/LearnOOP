namespace CalculatorMachine.ViewModel
{
    public class Operation
    {
        private string myNumber1;
        private string myNumber2;
        private string result;

        public virtual string GetResult()
        {
            return result;
        }

    }
}