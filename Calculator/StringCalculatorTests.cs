using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NU.Calculator
{
    [TestClass]
    public class StringCalculatorTests
    {
        private IStringCalculator stringCalculator;

        [TestInitialize]
        public void Initialise()
        {
            stringCalculator = new StringCalculator();
        }

        [TestMethod]
        public void return_zero_if_input_is_empty()
        {
            int expectedResult = 0;

            int result = stringCalculator.Add("");

            Assert.AreEqual(expectedResult, result);
        }
    }
}