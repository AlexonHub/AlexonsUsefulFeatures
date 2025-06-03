using Alexon.UsefulFeatures;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.UsefulFeaturesTests
{
    [TestFixture()]
    public class StringHelperTests
    {
        [Test()]
        public void IsPalindromeTest()
        {
            "aba".IsPalindrome().Should().BeTrue();
            "abc".IsPalindrome().Should().BeFalse();
        }

        [Test()]
        public void ReverseTest()
        {
           ("cba".Reverse() == "abc").Should().BeTrue();
        }

        [Test()]
        public void ExpressionTest()
        {
            //var expression = "a + b - c * d / e".ToExpression();
            //expression.Left.Should().Be("a + b");
            //expression.Operator.Should().Be("-");
            //expression.Right.Should().Be("c * d / e");
        }


    }
}