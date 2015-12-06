using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleMathParser.AcceptanceTests
{
    public class AcceptanceTests
    {
        [Test]
        public void ItShouldCalculateTheExpressions()
        {
            var mathParser = new MathParser();
            Assert.AreEqual(mathParser.Calculate("3a2c4"), 20);
            Assert.AreEqual(mathParser.Calculate("32a2d2"), 17);
            Assert.AreEqual(mathParser.Calculate("500a10b66c32"), 14208);
            Assert.AreEqual(mathParser.Calculate("3ae4c66fb32"), 235);
            Assert.AreEqual(mathParser.Calculate("3c4d2aee2a4c41fc4f"), 990);
        }
    }
}
