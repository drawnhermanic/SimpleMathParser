using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SimpleMathParser.SpecFlow
{
    [Binding]
    public class MathParserFeatureSteps
    {
        private MathParser _mathParser;

        private string _expression;
        private double _result;

        public MathParserFeatureSteps(MathParser mathParser)
        {
            _mathParser = mathParser;
        }

        [Given(@"I have the expression (.*)")]
        public void GivenIHaveTheExpression(string expression)
        {
            _expression = expression;
        }
        
        [When(@"I execute the math parser")]
        public void WhenIExecuteTheMathParser()
        {
            _result = _mathParser.Calculate(_expression);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double result)
        {
            Assert.AreEqual(_result, result);
        }
    }
}
