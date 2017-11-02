using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Lab4_XmlTechnologies;
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream[] xmlFiles = Directory.GetFiles(Lab4.Properties.Settings.Default.XmlFolderPath).Select(File.OpenRead).ToArray();

            XmlSearcher searcher = new XmlSearcher(Lab4.Properties.Settings.Default.NumThreads);
            Dictionary<String, Int32> result = searcher.Search(xmlFiles, Lab4.Properties.Settings.Default.XPathNode);

            result.ToList().ForEach(res =>
            {
                Console.WriteLine(String.IsNullOrEmpty(res.Key) ? "N/A" : res.Key + ", " + res.Value);
            });
            Console.ReadKey();
        }
    }
}
