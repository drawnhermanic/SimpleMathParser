using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleMathParser.UnitTests
{
    public class CalculatorTests
    {

        [Test]
        public void ItShouldAddTwoNumbers()
        {
            var expression = new List<string> { "3", "+", "4" };
            var result = Calculator.EvaluateSimpleExpression(expression);
            Assert.AreEqual(result, 7);
        }

        [Test]
        public void ItShouldPerformMulitpleCalculations()
        {
            var expression = new List<string> { "3", "+", "4", "*", "2" };
            var result = Calculator.EvaluateSimpleExpression(expression);
            Assert.AreEqual(result, 14);
        }

        [Test]
        public void ItShouldAddTwoNumbersWithRPNExpression()
        {
            var expression = new List<string> { "3", "4", "+" };
            var result = Calculator.Execute(expression);
            Assert.AreEqual(result, 7);
        }

        [Test]
        public void ItShouldCalculateTheExpression()
        {
            var expression = new List<string> { "3", "4", "*" };
            var result = Calculator.Execute(expression);
            Assert.AreEqual(result, 12);
        }
    }
}
