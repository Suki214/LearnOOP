using System;

namespace CalculatorDemo
{
    public class Multiply
    {
        private double numberA;
        private double numberB;

        public Multiply(double numberA, double numberB)
        {
            this.numberA = numberA;
            this.numberB = numberB;
        }

        public double Result()
        {
            return numberA * numberB;
        }
    }
}