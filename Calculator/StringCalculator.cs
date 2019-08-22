namespace NU.Calculator
{
    public interface IStringCalculator
    {
        int Add(string input);
    }

    public class StringCalculator : IStringCalculator
    {
        private const int DefaultValue = 0;

        public StringCalculator()
        {

        }

        public int Add(string input)
        {
            var result = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                return DefaultValue;
            }

            foreach (string number in input.Split(','))
            {
                result = result + int.Parse(number);
            }

            return result;
        }
    }
}