using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject
{
    public class Caculator
    {
        public Caculator() { }

        public int PlusTwoNumber(int a, int b) { return a + b; }
        public int MinusTwoNumber(int a, int b) { return a - b; }

        public int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArithmeticException("Attempted to divide by zero.");
            }

            return numerator / denominator;
        }

       
    }
}
