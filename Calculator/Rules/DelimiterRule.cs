using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Rules
{
    public interface IDelimiterRule
    {
        List<int> SplitStringToNumbers(string input);
    }

    public class DelimiterRule : IDelimiterRule
    {

        private readonly List<string> seperators = new List<string>() { ",", "\n" };

        private readonly string[] otherSeperators = { "//", "[", "]" };

        public List<int> SplitStringToNumbers(string input)
        {
            if (input.StartsWith("//"))
            {
                var customSeperator = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

                input = input.Substring(customSeperator.Length, input.Length - customSeperator.Length);

                var allCustomSeperators = customSeperator.Split(otherSeperators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var sep in allCustomSeperators)
                {
                    seperators.Add(sep);
                }
            }

            var numbers = input.Split(seperators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            return numbers.Select(s => int.Parse(s)).ToList();
        }
    }
}
