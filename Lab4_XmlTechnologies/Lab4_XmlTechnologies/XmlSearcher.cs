using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4_XmlTechnologies
{
    public class XmlSearcher
    {
        public int countThreads;

        public XmlSearcher(int countThreads)
        {
            this.countThreads = countThreads;
        }

        public Dictionary<String, Int32> Search(FileStream[] xmlFiles, String path)
        {
            Dictionary<String, Int32> nodes = new Dictionary<String, Int32>();
         
            foreach(FileStream xmlFile in xmlFiles) {
                String val = XmlDoc.GetValue(xmlFile, path);
                if (nodes.ContainsKey(val))
                {
                    nodes[val]++;
                }
                else
                {
                    nodes.Add(val, 1);
                }
            }
            return nodes;
        }
    }
}
