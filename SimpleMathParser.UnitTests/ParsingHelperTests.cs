using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleMathParser.UnitTests
{
    public class ParsingHelperTests
    {
        [Test]
        public void IsOperatorTest()
        {
            foreach (var item in ParsingHelper.Operators)
            {                
                Assert.IsTrue(ParsingHelper.IsOperator(char.Parse(item)));
            }                        
        }

        [Test]
        public void IsLeftBracketTest()
        {
            Assert.IsFalse(ParsingHelper.IsLeftBracket(')'));
            Assert.IsTrue(ParsingHelper.IsLeftBracket('('));
        }

        [Test]
        public void IsRightBracketTest()
        {
            Assert.IsTrue(ParsingHelper.IsRightBracket(')'));
            Assert.IsFalse(ParsingHelper.IsRightBracket('('));
        }

        [Test]
        public void IsParenthesesTest()
        {
            Assert.IsTrue(ParsingHelper.IsParentheses(')'));
            Assert.IsTrue(ParsingHelper.IsParentheses('('));

            Assert.IsFalse(ParsingHelper.IsValid('^'));
        }

        [Test]
        public void IsNumberTest()
        {
            Assert.IsTrue(ParsingHelper.IsNumber('6'));
            Assert.False(ParsingHelper.IsNumber('a'));            
        }

        [Test]
        public void IsValidTest()
        {
            Assert.IsTrue(ParsingHelper.IsValid('+'));
            Assert.IsTrue(ParsingHelper.IsValid('6'));
            Assert.IsTrue(ParsingHelper.IsValid(')'));
            Assert.IsTrue(ParsingHelper.IsValid('('));

            Assert.IsFalse(ParsingHelper.IsValid('^'));
        }

        [Test]
        public void IsValidExpressionTest()
        {
            Assert.IsTrue(ParsingHelper.IsValidExpression("3+4*2"));
            Assert.False(ParsingHelper.IsValidExpression("£+4^2"));
        }
    }
}
