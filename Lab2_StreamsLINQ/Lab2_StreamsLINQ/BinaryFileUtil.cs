using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Lab1_BinarySearchTree;
namespace Lab2_StreamsLINQ
{
    class BinaryFileUtil
    {
        private BinaryFileUtil() { }

        public static void Write(String fName, List<Student> students)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fName, FileMode.OpenOrCreate)))
            {
                foreach (Student student in students)
                {
                    writer.Write(student.FirstName);
                    writer.Write(student.SecondName);
                    writer.Write(student.NameTest);
                    writer.Write(student.Date.ToString());
                    writer.Write(student.Rating);
                }

            }
        }

        public static BinarySearchTree<Student> Read(String fName)
        {
            BinarySearchTree<Student> binaryTree = new BinarySearchTree<Student>(new ComparatorFirstNameStudent());
            using (BinaryReader reader = new BinaryReader(File.Open(fName, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    String firstName = reader.ReadString();
                    String secondName = reader.ReadString();
                    String nameTest = reader.ReadString();
                    DateTime date = DateTime.Parse(reader.ReadString());
                    int rating = reader.ReadInt32();
                    Student student = new Student(firstName, secondName, nameTest, date, rating);
                    binaryTree.Add(student);
                }
            }
            return binaryTree;
        }

        public static IEnumerable<Student> GetByDate(BinarySearchTree<Student> binaryTree, DateTime date)
        {
            return from student in binaryTree
                   where student.Date.Equals(date)
                   select student;
        }


    }
}