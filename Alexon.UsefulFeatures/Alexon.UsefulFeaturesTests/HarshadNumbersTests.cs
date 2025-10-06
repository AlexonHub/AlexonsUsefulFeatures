using Alexon.UsefulFeatures;
using FluentAssertions;
using NUnit.Framework;

namespace Alexon.UsefulFeaturesTests
{
    [TestFixture()]
    public class HarshadNumbersTests
    {
        [Test()]
        public void GetHarshadNumbersTest()
        {
            var result = HarshadNumbers.GetHarshadNumbers(1, 100);
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 18, 20, 21, 24, 27, 30, 36, 40, 42, 45, 48, 50, 54, 60, 63, 70, 72, 80, 81, 84, 90, 100 };
            
            result.Should().BeEquivalentTo(expected);

        }
    }
}