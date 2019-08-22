using System;

namespace Calculator.Rules
{
    public interface INegativeNumberRule
    {
        void validate(int number);
    }

    public class NegativeNumberRule : INegativeNumberRule
    {
        public void validate(int number)
        {
            if (number < 0)
                throw new Exception("“negatives not allowed”");
        }
    }
}