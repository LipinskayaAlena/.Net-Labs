using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab1_BinarySearchTree;
namespace Lab2_StreamsLINQ
{
    class BinaryFileUtil
    {
        private FileStream fs;
        private BinarySearchTree<Student> binaryTree;

        public BinaryFileUtil(String fName)
        {
            binaryTree = new BinarySearchTree<Student>();
            fs = new FileStream(fName, FileMode.Open);
            
            fs.Close();
        }

        public void write()
        {

        }

        public void read()
        {
            BinaryReader reader = new BinaryReader(fs);
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {

            }
        }

    }
}
