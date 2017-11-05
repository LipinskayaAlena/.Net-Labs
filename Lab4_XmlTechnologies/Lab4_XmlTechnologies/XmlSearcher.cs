using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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
                
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = countThreads;
            Parallel.For(0, xmlFiles.Length, parallelOptions, i => {
                String val = XmlDoc.GetValue(xmlFiles[i], path);
                lock (nodes)
                {
                    if (nodes.ContainsKey(val))
                    {
                        nodes[val]++;
                    }
                    else
                    {
                        nodes.Add(val, 1);
                    }
                }
            });
            
            return nodes;
        }
    }
}
