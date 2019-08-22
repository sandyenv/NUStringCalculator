namespace Calculator.Rules
{
    public interface IGreaterNumberRule
    {
        bool isIgnored(int number);
    }

    public class GreaterNumberRule : IGreaterNumberRule
    {
        private readonly int maxValue;

        public GreaterNumberRule(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public bool isIgnored(int number)
        {
            return number > maxValue;
        }
    }
}
