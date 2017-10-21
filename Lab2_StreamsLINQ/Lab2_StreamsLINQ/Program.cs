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
                                  "2 - Exit\n" +
                                  "Your choice is: ";
        [STAThread]
        static void Main(string[] args)
        {
            String fileName = "";
            int choice = 0;
            do
            {
                Console.WriteLine(COMMANDS);
                String line = Console.ReadLine();
                if(int.TryParse(line, out choice))
                    choice = Convert.ToInt32(line);
                else
                {
                    Console.WriteLine("Incorrect command");
                    continue;
                }              
                
                switch(choice)
                {
                    case 1:
                        OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                        if(dialog.ShowDialog() == DialogResult.OK)
                            fileName = dialog.FileName;
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;

                }


            } while (choice != 2);
      
            
        }
        
    }
}
