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
using System.Windows.Shapes;

namespace projectBookStore
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            Books books = new Books();
            books.Show();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();  
            customers.Show();
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            Transactions transactions = new Transactions();
            transactions.Show();
        }
    }
}
