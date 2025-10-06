using FluentAssertions;
using NUnit.Framework;
using System.Xml;

namespace Alexon.UsefulFeatures.Tests
{
    [TestFixture()]
    public class XMLHelperTests
    {
        [Test()]
        public void ToXDocumentTest()
        {
            XmlDocument xmlDocument = new XmlDocument();
            const string xml = @"<root>
  <a>1</a>
  <b>2</b>
</root>";
            xmlDocument.LoadXml(xml);
            var xdoc = XMLHelper.ToXDocument(xmlDocument);
            xdoc.ToString().Should().BeEquivalentTo(xml);    

        }
    }
}