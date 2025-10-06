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
        public void GetNumbersFromStringTest()
        {
            //char.GetNumericValue(input[0]);
            //var numbers = new List<int>(Enumerable.Range(1, 25));
            //var chunks = numbers.Chunk(10);

            var result = "a1b2c3".GetNumbersFromString();
            result.Should().Be("123");
        }
    }
}