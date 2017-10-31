using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_XmlTechnologies;
using System.IO;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream[] xmlFiles = Directory.GetFiles(Lab4.Properties.Settings.Default.XmlFolderPath).Select(File.OpenRead).ToArray();
            
        }
    }
}
