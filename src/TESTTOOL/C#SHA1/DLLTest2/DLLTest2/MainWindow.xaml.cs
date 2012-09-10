using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SHA1DLL;

namespace DLLTest2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string input = inputstr.Text;
            Class1 test1 = new Class1();
            string output = test1.SHA1Transform(input);
            outputstr.Text = output;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string name = inputName.Text;
            string high = inputHigh.Text;
            string low = inputLow.Text;
            string passWord = inputPassWord.Text;
            Class1 test2 = new Class1();
            string SHA1Message = test2.HashLoginInfo(name, high, low, passWord);
            outputMessage.Text = SHA1Message;
        }
    }
}
