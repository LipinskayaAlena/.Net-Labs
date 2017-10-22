using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_BinarySearchTree;
using System.IO;
using System.Windows.Forms;

namespace Lab2_StreamsLINQ
{
    class Program
    {

        public static String COMMANDS = "----------Lab2_streamLINQ-----------\n" +
                                  "1 - Choose binary file\n" +
                                  "2 - Create binary file\n" +
                                  "3 - Exit\n" +
                                  "Your choice is: ";


        [STAThread]
        static void Main(string[] args)
        {
            String fileName = "";
            int choice = 0;
            BinarySearchTree<Student> binaryTree;
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
                        OpenFileDialog dialog = new OpenFileDialog();
                        if (dialog.ShowDialog() == DialogResult.OK)
                            fileName = dialog.FileName;
                        if (!fileName.EndsWith(".bin"))
                            Console.WriteLine("File is not binary");
                        else
                            binaryTree = BinaryFileUtil.Read(fileName);
                        break;
                    case 2:
                        OpenFileDialog dialogCreateFile = new OpenFileDialog();
                        if (dialogCreateFile.ShowDialog() == DialogResult.OK)
                            fileName = dialogCreateFile.FileName;
                        BinaryFileUtil.Write(fileName, students);
                        Console.WriteLine("File was written");
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;

                }


            } while (choice != 3);


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
