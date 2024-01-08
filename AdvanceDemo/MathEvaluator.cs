using System;
using System.Data;

namespace AdvanceDemo
{
    public class MathEvaluator
    {
        public double EvaluateExpression(string expression)
        {
            try
            {
                var result = new DataTable().Compute(expression, null);
                return Convert.ToDouble(result);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid expression", ex);
            }
        }

        public void Dispose()
        {

        }
    }
}
