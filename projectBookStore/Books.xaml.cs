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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Window
    {
        public Books()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            //List<String> entries = BooksData.GetData();
            //string msgList = string.Join(",\n", entries);
            //MessageBox.Show(msgList);
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
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string isbn = txtSearch.Text;
            List<Dictionary<string, string>> results = BooksData.SearchData(isbn);

            if (results.Count > 0)
            {
                var book = results[0];
                txtISBN.Text = book["ISBN"];
                txtTitle.Text = book["Title"];
                txtDescription.Text = book["Description"];
                txtPrice.Text = book["Price"];
            }
            else
            {
                MessageBox.Show("No books found with the given ISBN.", "Search Results");
                txtISBN.Text = string.Empty;
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtPrice.Text = string.Empty;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string inputISBN = txtISBN.Text;
            string inputTitle = txtTitle.Text;
            string inputDescription = txtDescription.Text;
            string inputPrice = txtPrice.Text;
            
            BooksData.AddData(inputISBN, inputTitle, inputDescription, inputPrice);
            MessageBox.Show("Added Successfully!", "Success");
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string inputISBN = txtISBN.Text;
            string inputTitle = txtTitle.Text;
            string inputDescription = txtDescription.Text;
            string inputPrice = txtPrice.Text;

            BooksData.UpdateData(inputISBN, inputTitle, inputDescription, inputPrice);
            MessageBox.Show("Updated Successfully!", "Success");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string inputISBN = txtISBN.Text;

            if (!string.IsNullOrEmpty(inputISBN))
            {
                BooksData.DeleteData(inputISBN);
                MessageBox.Show("Deleted Successfully!", "Success");

                txtISBN.Text = string.Empty;
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtPrice.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter a valid ISBN to delete.", "Error");
            }
        }

    }
}
