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
            IEnumerable<Student> students = from student in binaryTree
                                            where student.Date.Equals(date)
                                            select student;
            return students;
        }

        public static IEnumerable<Student> GetByNameTest(BinarySearchTree<Student> binaryTree, String nameTest)
        {
            IEnumerable<Student> students = from student in binaryTree
                                            where student.NameTest.ToLower().Equals(nameTest.ToLower()) || student.NameTest.ToLower().StartsWith(nameTest.ToLower())
                                            select student;
            return students;
        }

        public static IEnumerable<Student> GetByFirstName(BinarySearchTree<Student> binaryTree, String fName)
        {
            IEnumerable<Student> students = from student in binaryTree
                                            where student.FirstName.ToLower().Equals(fName.ToLower()) || student.FirstName.ToLower().StartsWith(fName.ToLower())
                                            select student;
            return students;
        }

        public static IEnumerable<Student> GetByNumberLines(IEnumerable<Student> students, int numberLines)
        {
            if (numberLines != -1)
                return students.Take(numberLines);
            return students;
        }

        public static IEnumerable<Student> OrderStudents(IEnumerable<Student> notOrderedStudents, int order)
        {
            switch(order)
            {
                case 1:
                    return from student in notOrderedStudents
                           orderby student.FirstName
                           select student;
                case 2:
                    return from student in notOrderedStudents
                           orderby student.SecondName
                           select student;
                case 3:
                    return from student in notOrderedStudents
                           orderby student.NameTest
                           select student;
                case 4:
                    return from student in notOrderedStudents
                           orderby student.Date
                           select student;
                case 5:
                    return from student in notOrderedStudents
                           orderby student.Rating
                           select student;

            }
            return notOrderedStudents;
        }

        public static IEnumerable<Student> GetBySecondName(BinarySearchTree<Student> binaryTree, String sName)
        {
            IEnumerable<Student> students = from student in binaryTree
                                     where student.SecondName.ToLower().Equals(sName.ToLower()) || student.SecondName.ToLower().StartsWith(sName.ToLower())
                                     select student;
            return students;
        }

        public static IEnumerable<Student> GetByRating(BinarySearchTree<Student> binaryTree, int rating)
        {
            IEnumerable<Student> students = from student in binaryTree
                                            where student.Rating == rating
                                            select student;
            return students;
        }
    }
}