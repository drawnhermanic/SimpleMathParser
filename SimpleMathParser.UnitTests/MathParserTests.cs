using System;
using NUnit.Framework;

namespace SimpleMathParser.UnitTests
{
    public class MathParserTests
    {
        [Test]
        public void ItShouldCalculateTheExpression()
        {
            var mathParser = new MathParser();
            var result = mathParser.Calculate("3ae4c66fb32");
            Assert.AreEqual(result, 235);
        }

        [Test]
        public void ItShouldCalculateTheComplexExpression()
        {
            var mathParser = new MathParser();
            var result = mathParser.Calculate("3c4d2aee2a4c41fc4f");
            Assert.AreEqual(result, 990);
        }

        [Test]
        public void ItShouldThrowIsTheExpressionIsInvalid()
        {
            var mathParser = new MathParser();
            try
            {
                var result = mathParser.Calculate("!3ae4c66fb32");                
            }
            catch (Exception e)
            {
                Assert.IsInstanceOf<ArgumentException>(e);
            }
        }
    }
}
