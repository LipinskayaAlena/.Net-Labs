using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using Lab1_BinarySearchTree;
namespace Lab2_StreamsLINQ
{
    class BinaryFileUtil
    {
        private BinarySearchTree<Student> binaryTree;

        private BinaryFileUtil() { }

        public static void Write(String fName, List<Student> students)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fName, FileMode.OpenOrCreate)))
            {
                foreach(Student student in students)
                {
                    writer.Write(student.FirstName);
                    writer.Write(student.SecondName);
                    writer.Write(student.Date.ToString());
                    writer.Write(student.Rating);
                }

            }
        }

        public void Read()
        {
            //BinaryReader reader = new BinaryReader(fs);
            //while (reader.BaseStream.Position < reader.BaseStream.Length)
            //{

            //}
        }

    }
}
