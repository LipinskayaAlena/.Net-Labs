﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_BinarySearchTree;
using System.Linq;
using System.Windows.Forms;

namespace Lab2_StreamsLINQ
{
    class UserController
    {
        private BinarySearchTree<Student> binaryTree = null;
        private String fileName;
        private String COMMANDS = "----------Lab2_streamLINQ-----------\n" +
            "1 - Choose binary file\n" +
            "2 - Create binary file\n" +
            "3 - Settings\n" +
            "4 - Exit\n" +
            "Your choice is: ";


        private String SUB_COMMANDS = "----------Lab2_streamLINQ-----------\n" +
            "1 - Get tests by date\n" +
            "2 - Get tests by name\n" +
            "3 - Get tests by rating\n" +
            "4 - Cancel\n" +
            "Your choice is: ";

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
                        fileName = GetFile();
                        if (!fileName.EndsWith(".bin"))
                            Console.WriteLine("File is not binary");
                        else
                        {
                            binaryTree = BinaryFileUtil.Read(fileName);                            
                        }
                        ExecuteData();
                        break;
                    case 2:
                        BinaryFileUtil.Write(GetFile(), students);
                        Console.WriteLine("File was written");
                        break;
                    case 3: //settings
                        break;
                    case 4: //exit
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;

                }


            } while (choice != 4);
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

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter date in format dd-mm-YYYY");
                        String lineDate = Console.ReadLine();
                        DateTime date;
                        if (DateTime.TryParse(lineDate, out date))
                        {
                            foreach (Student student in BinaryFileUtil.GetByDate(binaryTree, date))
                                Console.WriteLine(student.ToString());

                        }
                        else
                            Console.WriteLine("Incorrect format date");
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;

                }
            } while (choice != 4);
        }

        public static String GetFile()
        {
            String fileName = "";
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                fileName = dialog.FileName;
            return fileName;
        }

        static List<Student> students = new List<Student>
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
