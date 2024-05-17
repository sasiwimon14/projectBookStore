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
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : Window
    {
        public Transactions()
        {
            InitializeComponent();
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
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


        private void txtISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            string isbn = txtISBN.Text;
            List<Dictionary<string, string>> results = BooksData.SearchData(isbn);

            if (results.Count > 0)
            {
                var book = results[0];
                txtTitleBook.Text = book["Title"];
                txtPrice.Text = book["Price"];
            }
            else
            {
                MessageBox.Show("No books found with the given ISBN.", "Search Results");
            }
        }

        private void txtCustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchID = txtCustomerId.Text;
            List<Dictionary<string, string>> results = CustomersData.SearchData(searchID);

            if (results.Count > 0)
            {
                var Customer = results[0];
                txtCustomerName.Text = Customer["Customer_Name"];
            }
            else
            {
                MessageBox.Show("No books found with the given ID.", "Search Results");
            }
        }

        private void txtQuatity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price) && int.TryParse(txtQuatity.Text, out int quantity))
            {
                decimal total = price * quantity;
                txtTotal.Text = total.ToString();
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string ISBN = txtISBN.Text;
            string CustomerId = txtCustomerId.Text;
            string CustomerName = txtCustomerName.Text;
            string BookTitle = txtTitleBook.Text;
            string Quatity = txtQuatity.Text;
            string Total = txtTotal.Text;

            int inputISBN = int.Parse(ISBN);
            int inputCustomerId = int.Parse(CustomerId);
            int inputQuatity = int.Parse(Quatity);
            int inputTotal = int.Parse(Total);

            string message = $"สรุปรายการคำสั่งซื้อ\nคุณ {CustomerName}\n" +
                             $"ได้ทำการสั่งซื้อ หนังสือ {BookTitle}\n" +
                             $"จำนวน {Quatity} รายการ\n" +
                             $"เป็นจำนวนเงินทั้งหมด {Total} บาท";

            TransactionsData.AddData(inputISBN, inputCustomerId, inputQuatity, inputTotal);
            MessageBoxResult result = MessageBox.Show(message, "Success", MessageBoxButton.OK);

            if (result == MessageBoxResult.OK)
            {
                Menu menu = new Menu();
                menu.Show();
            }

        }
    }
}
