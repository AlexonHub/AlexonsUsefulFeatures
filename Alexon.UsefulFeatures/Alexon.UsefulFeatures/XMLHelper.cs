using System.Xml;
using System.Xml.Linq;

namespace Alexon.UsefulFeatures
{
    public static class XMLHelper
    {
        public static XDocument ToXDocument(this XmlDocument doc)
        {
            using var nodeReader = new XmlNodeReader(doc);
            nodeReader.MoveToContent();
            return XDocument.Load(nodeReader);
        }
    }
}