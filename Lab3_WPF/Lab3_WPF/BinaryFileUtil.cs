using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_BinarySearchTree;
using System.IO;
using System.Windows.Forms;
namespace Lab3_WPF
{
    class BinaryFileUtil
    {
        public static String FILE_NAME;

        private BinaryFileUtil() { }

        public static void Write(List<Student> students)
        {
            String fName = GetFile();
            if (!fName.EndsWith(".bin"))
            {
                Console.WriteLine("File is not binary");
                return;
            }
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
                Console.WriteLine("File was written");
            }
        }

        public static String GetFile()
        {
            FILE_NAME = "";
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                FILE_NAME = dialog.FileName;
            return FILE_NAME;
        }

        public static BinarySearchTree<Student> Read()
        {
            String fName = GetFile();
            if (!fName.EndsWith(".bin"))
                return null;

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

        public static IEnumerable<Student> GetByNameTest(BinarySearchTree<Student> binaryTree, String nameTest)
        {
            return from student in binaryTree
                   where student.NameTest.ToLower().Equals(nameTest.ToLower()) || student.NameTest.ToLower().StartsWith(nameTest.ToLower())
                   select student;
        }

        public static IEnumerable<Student> GetByFirstName(BinarySearchTree<Student> binaryTree, String fName)
        {
            return from student in binaryTree
                   where student.FirstName.ToLower().Equals(fName.ToLower()) || student.FirstName.ToLower().StartsWith(fName.ToLower())
                   select student;
        }

        public static IEnumerable<Student> GetByNumberLines(IEnumerable<Student> students, uint numberLines)
        {
            if (numberLines != 0)
                return students.Take((int)numberLines);
            return students;
        }

        public static IEnumerable<Student> OrderStudents(IEnumerable<Student> notOrderedStudents, uint order, uint typeOrder)
        {
            switch (order)
            {
                case 1:
                    return (typeOrder == 2) ? notOrderedStudents.OrderByDescending(student => student.FirstName) : notOrderedStudents.OrderBy(student => student.FirstName);
                case 2:
                    return (typeOrder == 2) ? notOrderedStudents.OrderByDescending(student => student.SecondName) : notOrderedStudents.OrderBy(student => student.SecondName);
                case 3:
                    return (typeOrder == 2) ? notOrderedStudents.OrderByDescending(student => student.NameTest) : notOrderedStudents.OrderBy(student => student.NameTest);
                case 4:
                    return (typeOrder == 2) ? notOrderedStudents.OrderByDescending(student => student.Date) : notOrderedStudents.OrderBy(student => student.Date);
                case 5:
                    return (typeOrder == 2) ? notOrderedStudents.OrderByDescending(student => student.Rating) : notOrderedStudents.OrderBy(student => student.Rating);

            }
            return notOrderedStudents;
        }

        public static IEnumerable<Student> GetBySecondName(BinarySearchTree<Student> binaryTree, String sName)
        {
            return binaryTree.Where(student => student.SecondName.ToLower().Equals(sName.ToLower()) || student.SecondName.ToLower().StartsWith(sName.ToLower()));
        }

        public static IEnumerable<Student> GetByRating(BinarySearchTree<Student> binaryTree, int rating)
        {
            return binaryTree.Where(student => student.Rating == rating);
        }
    }
}
