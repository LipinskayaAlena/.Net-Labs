using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab1_BinarySearchTree;
namespace Lab3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BinarySearchTree<Student> binaryTree;
        public MainWindow()
        {
            InitializeComponent();
            Clear();
        }

        private void Button_Select_File(object sender, RoutedEventArgs e)
        {
            Clear();
            binaryTree = BinaryFileUtil.Read();
            if (binaryTree == null || binaryTree.Count == 0)
                outputConsole.Text = "Error reading file. Check that this file have extension .bin and that this file is not empty";
            else
            {
                nameOfFile.Visibility = Visibility.Visible;
                nameOfFile.Content = BinaryFileUtil.FILE_NAME;
            }

        }

        private void Clear()
        {
            nameOfFile.Visibility = Visibility.Hidden;
            outputConsole.Text = "";
        }
    }
}
