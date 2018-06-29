using System;

namespace CalculatorDemo
{
    public class Devide
    {
        private double numberA;
        private double numberB;

        public Devide(double numberA, double numberB)
        {
            this.numberA = numberA;
            this.numberB = numberB;
        }

        public double Result()
        {
            return numberA / numberB;
        }
    }
}