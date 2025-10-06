using FluentAssertions;
using NUnit.Framework;

namespace Alexon.UsefulTools.Tests
{
    [TestFixture()]
    public class ToolsTests
    {
        [Test()]
        public void GetDotNetFrameworkVersionsTest()
        {
           var result = Tools.GetDotNetFrameworkVersions();
            result.Should().NotBeNullOrEmpty();
        }
    }
}