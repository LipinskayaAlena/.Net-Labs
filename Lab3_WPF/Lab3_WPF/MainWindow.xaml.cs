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

        int get_data_commands;
        int orderBy;
        int orderType;

        String info;
        DateTime datePassTest;

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
                listBoxCommands.Visibility = Visibility.Visible;
                nameOfFile.Content = BinaryFileUtil.FILE_NAME;
                showPreSettings();
            }

        }

        private void lineNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!UInt64.TryParse(tb.Text, out numberLines)) {
                tb.Text = "";
                NumberLines = 0;
            }
            if (NumberLines < Minimum) NumberLines = Minimum;
            if (NumberLines > Maximum) NumberLines = Maximum;
        }

        private void Button_Up(object sender, RoutedEventArgs e)
        {
            
            if (NumberLines < Maximum)
            {
                NumberLines++;
            }
            textBoxLineNumber.Text = NumberLines.ToString();
        }

        private void Button_Down(object sender, RoutedEventArgs e)
        {
            if (NumberLines > Minimum)
            {
                NumberLines--;
            }
            textBoxLineNumber.Text = NumberLines.ToString();
        }

        private void showPreSettings()
        {
            labelNumberLines.Visibility = Visibility.Visible;
            labelOrderBy.Visibility = Visibility.Visible;
            labelOrderType.Visibility = Visibility.Visible;
            comboBoxOrderBy.Visibility = Visibility.Visible;
            comboBoxOrderType.Visibility = Visibility.Visible;
            gridLineNumber.Visibility = Visibility.Visible;
            buttonGetData.Visibility = Visibility.Visible;

        }

        private void Clear()
        {
            nameOfFile.Visibility = Visibility.Hidden;
            outputConsole.Text = "";
            listBoxCommands.Visibility = Visibility.Hidden;
            labelNumberLines.Visibility = Visibility.Hidden;
            labelOrderBy.Visibility = Visibility.Hidden;
            labelOrderType.Visibility = Visibility.Hidden;
            comboBoxOrderBy.Visibility = Visibility.Hidden;
            comboBoxOrderType.Visibility = Visibility.Hidden;
            
            gridLineNumber.Visibility = Visibility.Hidden;
            listBoxCommands.SelectedIndex = 0;

            labelInfo.Visibility = Visibility.Hidden;
            textBoxInfo.Visibility = Visibility.Hidden;
            datePicker.Visibility = Visibility.Hidden;

            buttonGetData.Visibility = Visibility.Hidden;
        }

        public String Info
        {
            get { return info; }

            set
            {
                UInt16 rating = 0;
                if(get_data_commands == 5 && UInt16.TryParse(value.ToString(), out rating) && rating <= 10 && rating >= 1)
                {
                    info = value;
                } else if(get_data_commands == 5)
                {
                    info = "";
                } else
                {
                    info = value;
                }

                OnPropertyChanged("Info");
            }
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
                } else
                {
                    numberLines = 0;
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

        private void listBoxCommands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            String[] data = new String[] { "First Name", "Second Name", "Name of test", "Date of pass", "Rating"};
            get_data_commands = listBoxCommands.SelectedIndex;
            if(get_data_commands == 0 && labelInfo != null && textBoxInfo != null)
            {
                labelInfo.Visibility = Visibility.Hidden;
                textBoxInfo.Visibility = Visibility.Hidden;
                datePicker.Visibility = Visibility.Hidden;
                buttonGetData.Visibility = Visibility.Visible;
            } else if (get_data_commands != 0)
                ShowFieldEnterInfo(data[get_data_commands - 1]);
            
                
            

        }

        private void info_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            Info = tb.Text;
            tb.Text = Info;

            if (!"".Equals(tb.Text))
                buttonGetData.Visibility = Visibility.Visible;
            else
                buttonGetData.Visibility = Visibility.Hidden;
        }

        public void ShowFieldEnterInfo(String labelName)
        {
            textBoxInfo.Text = "";
            if (get_data_commands == 4)
            {
                datePicker.Visibility = Visibility.Visible;
                textBoxInfo.Visibility = Visibility.Hidden;
                buttonGetData.Visibility = Visibility.Visible;
            } else
            {
                datePicker.Visibility = Visibility.Hidden;
                textBoxInfo.Visibility = Visibility.Visible;
                buttonGetData.Visibility = Visibility.Hidden;
            }
            labelInfo.Visibility = Visibility.Visible;
            labelInfo.Content = labelName;
            
        }

        private void comboBoxOrderBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderBy = comboBoxOrderBy.SelectedIndex;
        }

        private void comboBoxOrderType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderType = comboBoxOrderType.SelectedIndex;
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            datePassTest = DateTime.Parse(datePicker.Text);
        }
    }
}
