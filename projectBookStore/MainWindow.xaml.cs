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

namespace projectBookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TransactionsData.InitializeDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            if (username == "admin" && password == "admin1111")
            {
            Menu menu = new Menu();
            menu.Show();
            }
            else
            {
                MessageBox.Show("Username หรือ Password ไม่ถูกต้อง", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            //List<String> entries = TransactionsData.GetData();
            //string msgList = string.Join(",\n", entries);
            //MessageBox.Show(msgList);
        }

    }
}
