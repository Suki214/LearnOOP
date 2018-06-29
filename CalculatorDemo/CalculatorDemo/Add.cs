using System;

namespace CalculatorDemo
{
    public class Add
    {
        private double numberA;
        private double numberB;

        public Add(double numberA, double numberB)
        {
            this.numberA = numberA;
            this.numberB = numberB;
        }

        public double Result()
        {
            return numberA + numberB;
        }
    }
}