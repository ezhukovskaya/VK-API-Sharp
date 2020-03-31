using System.Xml.Linq;

namespace VK.Framework.Utils
{
    public class XMLUtils
    {
        public static string GetNodeValue(string key, string xmlPath)
        {
            string xmlString = System.IO.File.ReadAllText(xmlPath);
            var xDoc = XDocument.Parse(xmlString);
            return xDoc.Root?.Element(key)?.Value;
        }
    }
}