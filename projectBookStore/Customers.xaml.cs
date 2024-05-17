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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        public Customers()
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
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchID = txtSearch.Text;
            List<Dictionary<string, string>> results = CustomersData.SearchData(searchID);

            if (results.Count > 0)
            {
                var Customer = results[0];
                txtCustomerID.Text = Customer["Customer_Id"];
                txtCustomerName.Text = Customer["Customer_Name"];
                txtAddress.Text = Customer["Address"];
                txtmail.Text = Customer["Email"]; 
            }
            else
            {
                MessageBox.Show("No books found with the given ID.", "Search Results");
                txtCustomerID.Text = string.Empty;
                txtCustomerName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtmail.Text = string.Empty;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string inputCustomerID = txtCustomerID.Text;
            string inputCustomerName = txtCustomerName.Text;
            string inputAddress = txtAddress.Text;
            string inputEmail = txtmail.Text;

            CustomersData.AddData(inputCustomerID, inputCustomerName, inputAddress, inputEmail);
            MessageBox.Show("Added Successfully!", "Success");

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string inputCustomerID = txtCustomerID.Text;
            string inputCustomerName = txtCustomerName.Text;
            string inputAddress = txtAddress.Text;
            string inputEmail = txtmail.Text;

            CustomersData.UpdateData(inputCustomerID, inputCustomerName, inputAddress, inputEmail);
            MessageBox.Show("Updated Successfully!", "Success");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string inputCustomerID = txtCustomerID.Text;

            if (!string.IsNullOrEmpty(inputCustomerID))
            {
                CustomersData.DeleteData(inputCustomerID);
                MessageBox.Show("Deleted Successfully!", "Success");

                txtCustomerID.Text = string.Empty;
                txtCustomerName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtmail.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter a valid ID to delete.", "Error");
            }
        }
    }
}
