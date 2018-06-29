using System;

namespace CalculatorDemo
{
    public class Delete
    {
        private double numberA;
        private double numberB;

        public Delete(double numberA, double numberB)
        {
            this.numberA = numberA;
            this.numberB = numberB;
        }

        public double Result()
        {
            return numberA - numberB;
        }
    }
}