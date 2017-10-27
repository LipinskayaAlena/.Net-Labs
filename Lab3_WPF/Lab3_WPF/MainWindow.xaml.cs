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
using System.ComponentModel;
namespace Lab3_WPF
{
    public partial class MainWindow : Window
    {
        BinarySearchTree<Student> binaryTree;
        UInt64 Maximum;
        UInt64 Minimum;
        UInt64 numberLines;
        public MainWindow()
        {
            InitializeComponent();
            Clear();
            Maximum = UInt64.MaxValue;
            Minimum = UInt64.MinValue;
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
                checkBoxCommands.Visibility = Visibility.Visible;
                nameOfFile.Content = BinaryFileUtil.FILE_NAME;
                showPreSettings();
            }

        }

        private void lineNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!UInt64.TryParse(tb.Text, out numberLines)) {
                tb.Text = "";
                numberLines = 0;
            }
            if (numberLines < Minimum) numberLines = Minimum;
            if (numberLines > Maximum) numberLines = Maximum;
        }

        private void Button_Up(object sender, RoutedEventArgs e)
        {
            
            if (numberLines < Maximum)
            {
                numberLines++;
            }
            textBoxLineNumber.Text = numberLines.ToString();
        }

        private void Button_Down(object sender, RoutedEventArgs e)
        {
            if (numberLines > Minimum)
            {
                numberLines--;
            }
            textBoxLineNumber.Text = numberLines.ToString();
        }

        private void showPreSettings()
        {
            labelNumberLines.Visibility = Visibility.Visible;
            labelOrderBy.Visibility = Visibility.Visible;
            labelOrderType.Visibility = Visibility.Visible;
            comboBoxOrderBy.Visibility = Visibility.Visible;
            comboBoxOrderType.Visibility = Visibility.Visible;
            gridLineNumber.Visibility = Visibility.Visible;
        }

        private void Clear()
        {
            nameOfFile.Visibility = Visibility.Hidden;
            outputConsole.Text = "";
            checkBoxCommands.Visibility = Visibility.Hidden;
            labelNumberLines.Visibility = Visibility.Hidden;
            labelOrderBy.Visibility = Visibility.Hidden;
            labelOrderType.Visibility = Visibility.Hidden;
            comboBoxOrderBy.Visibility = Visibility.Hidden;
            comboBoxOrderType.Visibility = Visibility.Hidden;
            textBoxLineNumber.Text = "0";
            gridLineNumber.Visibility = Visibility.Hidden;
        }

        public UInt64 NumberLines
        {
            get { return numberLines; }

            set
            {
                if (numberLines == value) return;

                if (UInt64.TryParse(value.ToString(), out numberLines))
                {
                    numberLines = value;
                }

                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
