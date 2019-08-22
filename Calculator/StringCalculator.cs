using Calculator.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NU.Calculator
{
    public interface IStringCalculator
    {
        int Add(string input);
    }

    public class StringCalculator : IStringCalculator
    {
        private const int DefaultValue = 0;

        private readonly IDelimiterRule _delimiterRule;
        private readonly IGreaterNumberRule _greaterNumberRule;
        private readonly INegativeNumberRule _negativeNumberRule;

        public StringCalculator(IDelimiterRule delimiterRule, 
            IGreaterNumberRule greaterNumberRule, 
            INegativeNumberRule negativeNumberRule)
        {
            if(delimiterRule == null) throw new ArgumentNullException(nameof(delimiterRule));
            if(greaterNumberRule == null) throw new ArgumentNullException(nameof(greaterNumberRule));
            if(negativeNumberRule == null) throw new ArgumentNullException(nameof(negativeNumberRule));

            _delimiterRule = delimiterRule;
            _greaterNumberRule = greaterNumberRule;
            _negativeNumberRule = negativeNumberRule;
        }

        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return DefaultValue;
            }

            var numbers = _delimiterRule.SplitStringToNumbers(input);

            var numbersWithoutIgnored = numbers.Where(s => !_greaterNumberRule.isIgnored(s)).ToList();

            numbersWithoutIgnored.ForEach(s => _negativeNumberRule.validate(s));

            return numbersWithoutIgnored.Sum();
        }
    }
}