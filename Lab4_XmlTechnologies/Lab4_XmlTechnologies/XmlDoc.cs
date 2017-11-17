using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using System.Xml;
using System.IO;

namespace Lab4_XmlTechnologies
{
    class XmlDoc
    {

        public XPathDocument Document { get; }

        private XmlDoc(Stream xmlFile)
        {
            XmlReader reader = XmlReader.Create(xmlFile);
            Document = new XPathDocument(reader);
            

        }

        public static String GetValue(Stream xmlFile, String xPath)
        {
            XmlDoc xmlDoc = new XmlDoc(xmlFile);
            XPathNavigator navigator = xmlDoc.Document.CreateNavigator();
            navigator.MoveToFirstChild();
            IEnumerable<String> nodes = xPath.Split('/').Select(node => node.Split('@').ElementAtOrDefault(0)).Where(node => !String.IsNullOrEmpty(node));
            String attribute = xPath.Split('@').ElementAtOrDefault(1);

            if(nodes.Any(node => !navigator.MoveToChild(node, navigator.NamespaceURI)))
            {
                return String.Empty;
            }

            if(!String.IsNullOrEmpty(attribute) && !navigator.MoveToAttribute(attribute, String.Empty))
            {
                return String.Empty;
            }
            return navigator.Value;

        }
    }
}
