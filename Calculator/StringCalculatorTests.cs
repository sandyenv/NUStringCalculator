using System;
using Calculator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NU.Calculator
{
    [TestClass]
    public class StringCalculatorTests
    {
        private IStringCalculator stringCalculator;
        private IDelimiterRule delimiterRule;
        private IGreaterNumberRule greaterNumberRule;
        private INegativeNumberRule negativeNumberRule;

        [TestInitialize]
        public void Initialise()
        {
            delimiterRule = new DelimiterRule();
            greaterNumberRule = new GreaterNumberRule(1000);
            negativeNumberRule = new NegativeNumberRule();
            stringCalculator = new StringCalculator(delimiterRule, greaterNumberRule, negativeNumberRule);
        }

        [TestMethod]
        public void return_zero_if_input_is_empty()
        {
            int expectedResult = 0;

            int result = stringCalculator.Add("");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void add_singlenumber_returnsSum()
        {
            var result = stringCalculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void add_twonumbers_retunssum()
        {
            var result = stringCalculator.Add("1, 2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void add_newline_asseperator()
        {
            var result = stringCalculator.Add("1\n2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void add_differentDelimiter_toParseTheSum()
        {
            var result = stringCalculator.Add("//*\n1*2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void add_negative_throwsexception()
        {
            var result = stringCalculator.Add("-1");
        }

        [TestMethod]
        public void add_biggerthan1000_ignored()
        {
            var result = stringCalculator.Add("2,1001");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void add_multiple_delimiters_forsum()
        {
            var result = stringCalculator.Add("//[**][%%]\n1**2%%3");

            Assert.AreEqual(6, result);
        }
    }
}