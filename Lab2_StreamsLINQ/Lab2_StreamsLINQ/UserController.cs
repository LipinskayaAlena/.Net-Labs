﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_BinarySearchTree;
using System.Windows.Forms;

namespace Lab2_StreamsLINQ
{
    class UserController
    {
        private BinarySearchTree<Student> binaryTree = null;
        
        private String COMMANDS = "----------Lab2_streamLINQ-----------\n" +
            "1 - Choose binary file\n" +
            "2 - Create binary file\n" +
            "3 - Exit\n" +
            "Your choice is: ";
        
        private String SUB_COMMANDS = "----------Lab2_streamLINQ-----------\n" +
            "1 - Get students by date of passing tests\n" +
            "2 - Get students by name of test\n" +
            "3 - Get students by rating\n" +
            "4 - Get students by first name\n" +
            "5 - Get students by second name\n" +
            "6 - Get all students\n" +
            "7 - Cancel\n" +
            "Your choice is: ";

        private String PRE_SETTINGS = "----------PRE-SETTINGS-----------\n" +
            "1 - Set number of lines\n" +
            "2 - Set order\n" +
            "3 - Cancel\n" + 
            "Your choice is: ";

        private String ORDER_BY = "----------ORDER-----------\n" +
            "1 - Order by first name\n" +
            "2 - Order by second name\n" +
            "3 - Order by name of the test\n" +
            "4 - Order by date of pass test\n" + 
            "5 - Order by rating\n" +
            "6 - Cancel\n" +
            "Your choice is: ";

        private String ORDER_TYPE = "-------ORDER-TYPE------\n" +
            "1 - Uprising\n" +
            "2 - Descending\n" +
            "3 - Cancel\n" +
            "Your choice is: ";
        
        public uint? numberLines;
        private uint orderBy;
        private uint orderType;
        
        private IEnumerable<Student> students;
        private IEnumerable<Student> allStudents;

        public UserController() { }


        public void Start()
        {
            int choice = 0;
            do
            {
                Console.WriteLine(COMMANDS);
                String line = Console.ReadLine();
                if (int.TryParse(line, out choice))
                    choice = Convert.ToInt32(line);
                else
                {
                    Console.WriteLine("Incorrect command");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        binaryTree = BinaryFileUtil.Read();
                        if(binaryTree!= null)
                            ExecuteData();                        
                        break;
                    case 2:
                        BinaryFileUtil.Write(dataStudents);
                        
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                }
            } while (choice != 3);
        }

        public void ExecuteData()
        {
            int choice = 0;
            do
            {
                Console.WriteLine(SUB_COMMANDS);
                String line = Console.ReadLine();
                if (int.TryParse(line, out choice))
                    choice = Convert.ToInt32(line);
                else
                {
                    Console.WriteLine("Incorrect command");
                    continue;
                }
                numberLines = null;
                orderBy = 0;
                orderType = 0;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter date in format dd-mm-YYYY");
                        String lineDate = Console.ReadLine();
                        DateTime date;
                        if (DateTime.TryParse(lineDate, out date))
                        {
                            PreSettings();
                            allStudents = BinaryFileUtil.GetByDate(binaryTree, date);
                            students = BinaryFileUtil.GetByNumberLines(allStudents, numberLines);
                            CheckData(students);
                            foreach (Student student in BinaryFileUtil.OrderStudents(students, orderBy, orderType))
                                Console.WriteLine(student.ToString());
                        }
                        else
                            Console.WriteLine("Incorrect format date");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Enter name test or part of name: ");
                        String nameOfTest = Console.ReadLine();
                        PreSettings();
                        allStudents = BinaryFileUtil.GetByNameTest(binaryTree, nameOfTest);
                        students = BinaryFileUtil.GetByNumberLines(allStudents, numberLines);
                        CheckData(students);
                        foreach (Student student in BinaryFileUtil.OrderStudents(students, orderBy, orderType))
                            Console.WriteLine(student.ToString());
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Enter rating: ");
                        String lineRating = Console.ReadLine();
                        int rating;

                        if (Int32.TryParse(lineRating, out rating))
                        {
                            PreSettings();
                            allStudents = BinaryFileUtil.GetByRating(binaryTree, rating);
                            students = BinaryFileUtil.GetByNumberLines(allStudents, numberLines);
                            CheckData(students);
                            foreach (Student student in BinaryFileUtil.OrderStudents(students, orderBy, orderType))
                                Console.WriteLine(student.ToString());
                        }
                        else
                            Console.WriteLine("Incorrect rating");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Enter first name of student or part of first name: ");
                        String firstName = Console.ReadLine();
                        PreSettings();
                        allStudents = BinaryFileUtil.GetByFirstName(binaryTree, firstName);
                        students = BinaryFileUtil.GetByNumberLines(allStudents, numberLines);
                        CheckData(students);
                        foreach (Student student in BinaryFileUtil.OrderStudents(students, orderBy, orderType))
                            Console.WriteLine(student.ToString());
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Enter second name of student or part of second name: ");
                        String secondName = Console.ReadLine();
                        PreSettings();
                        allStudents = BinaryFileUtil.GetBySecondName(binaryTree, secondName);
                        students = BinaryFileUtil.GetByNumberLines(allStudents, numberLines);
                        CheckData(students);
                        foreach (Student student in BinaryFileUtil.OrderStudents(students, orderBy, orderType))
                            Console.WriteLine(student.ToString());
                        Console.ReadKey();
                        break;
                    case 6:
                        PreSettings();
                        students = BinaryFileUtil.OrderStudents(BinaryFileUtil.GetByNumberLines(binaryTree, numberLines), orderBy, orderType);
                        CheckData(students);
                        foreach (Student student in students)
                            Console.WriteLine(student.ToString());
                        Console.ReadKey();
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                }
                
            } while (choice != 7);
        }

        public void CheckData(IEnumerable<Student> students)
        {
            if (students.Count() == 0)
                Console.WriteLine("There are not students with such parameters or parameter of lines number are greater than number of students");
            
        }

        public void PreSettings()
        {
            int choice = 0;
            do
            {
                Console.WriteLine(PRE_SETTINGS);
                String line = Console.ReadLine();
                if (int.TryParse(line, out choice))
                    choice = Convert.ToInt32(line);
                else
                {
                    Console.WriteLine("Incorrect command");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter number of lines: ");
                        String lineNumber = Console.ReadLine();
                        uint numLines;
                        if (!UInt32.TryParse(lineNumber, out numLines))
                            Console.WriteLine("Incorrect format date");
                        else
                            numberLines = numLines;
                        break;
                    case 2:
                        OrderSettings();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;

                }
            } while (choice != 3);
        }

        public void OrderSettings()
        {
            Console.WriteLine(ORDER_BY);
            String line = Console.ReadLine();
            if (UInt32.TryParse(line, out orderBy) && orderBy < 7)
                orderBy = Convert.ToUInt32(line);
            else
                Console.WriteLine("Incorrect command");
            OrderTypeSettings();

        }

        public void OrderTypeSettings()
        {
            Console.WriteLine(ORDER_TYPE);
            String line = Console.ReadLine();
            if (UInt32.TryParse(line, out orderType) && orderType < 4)
                orderType = Convert.ToUInt32(line);
            else
                Console.WriteLine("Incorrect command");
        }

        static List<Student> dataStudents = new List<Student>
        {
            new Student("Svetlana", "Omelchenko", "Test2", new DateTime(2017, 4, 10), 8),
            new Student("Claire", "O'Donnell", "Test6", new DateTime(2017, 4, 12), 6),
            new Student("Sven", "Mortensen", "Test3", new DateTime(2017, 4, 29), 7),
            new Student("Cesar", "Garcia", "test3", new DateTime(2017, 5, 10), 4),
            new Student("Debra", "Garcia", "Test2", new DateTime(2017, 4, 5), 9),
            new Student("Fadi", "Fakhouri", "test3", new DateTime(2017, 4, 9), 8),
            new Student("Hanying", "Feng", "Test2", new DateTime(2017, 4, 20), 7),
            new Student("Hugo", "Garcia", "test6", new DateTime(2017, 4, 23), 7),
            new Student("Lance", "Tucker", "Test1", new DateTime(2017, 4, 27), 6),
            new Student("Terry", "Adams", "test2", new DateTime(2017, 4, 15), 8),
            new Student("Eugene", "Zabokritski", "test1", new DateTime(2017, 5, 4), 5),
            new Student("Michael", "Tucker", "test1", new DateTime(2017, 4, 13), 6)
       };


    }
}
