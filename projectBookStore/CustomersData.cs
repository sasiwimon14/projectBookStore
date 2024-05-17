using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectBookStore
{
    internal class CustomersData
    {
        //------ Customers TABLE ------
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteCustomers.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (Customer_Id INTEGER PRIMARY KEY, " +
                    "Customer_Name NVARCHAR(100) NULL, " +
                    "Address NVARCHAR(255) NULL, " +
                    "Email NVARCHAR(100) NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        //------ End Customers TABLE ------

        //------ ADD Customers TABLE ------
        public static void AddData(string inputCustomerID, string inputCustomerName, string inputAddress, string inputEmail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteCustomers.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO Customers (Customer_Id, Customer_Name, Address, Email) VALUES (@Customer_Id, @Customer_Name, @Address, @Email)";
                insertCommand.Parameters.AddWithValue("@Customer_Id", inputCustomerID);
                insertCommand.Parameters.AddWithValue("@Customer_Name", inputCustomerName);
                insertCommand.Parameters.AddWithValue("@Address", inputAddress);
                insertCommand.Parameters.AddWithValue("@Email", inputEmail);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        //------ End ADD Customers TABLE ------

        //------ Update Customers TABLE ------
        public static void UpdateData(string inputCustomerID, string inputCustomerName, string inputAddress, string inputEmail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteCustomers.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Customers SET Customer_Name = @Customer_Name, Address = @Address, Email = @Email WHERE Customer_Id = @Customer_Id";
                updateCommand.Parameters.AddWithValue("@Customer_Id", inputCustomerID);
                updateCommand.Parameters.AddWithValue("@Customer_Name", inputCustomerName);
                updateCommand.Parameters.AddWithValue("@Address", inputAddress);
                updateCommand.Parameters.AddWithValue("@Email", inputEmail);

                updateCommand.ExecuteNonQuery();

                db.Close();
            }
        }
        //------ End Update Customers TABLE ------

        //------ Delete Customers TABLE ------
        public static void DeleteData(string inputCustomerID)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteCustomers.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = "DELETE FROM Customers WHERE Customer_Id = @Customer_Id";
                deleteCommand.Parameters.AddWithValue("@Customer_Id", inputCustomerID);

                deleteCommand.ExecuteNonQuery();

                db.Close();
            }
        }
        //------ End Delete Customers TABLE ------

        //------ Search Customers TABLE ------
        public static List<Dictionary<string, string>> SearchData(string searchID)
        {
            List<Dictionary<string, string>> entries = new List<Dictionary<string, string>>();

            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteCustomers.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM Customers WHERE Customer_Id LIKE @SearchText", db);
                selectCommand.Parameters.AddWithValue("@SearchText", "%" + searchID + "%");

                using (SqliteDataReader query = selectCommand.ExecuteReader())
                {
                    while (query.Read())
                    {
                        Dictionary<string, string> entry = new Dictionary<string, string>
                {
                    { "Customer_Id", query.GetInt32(0).ToString() },
                    { "Customer_Name", query.GetString(1) },
                    { "Address", query.GetString(2) },
                    { "Email", query.GetString(3) }
                };
                        entries.Add(entry);
                    }
                }

                db.Close();
            }

            return entries;
        }
        //------ End Search Customers TABLE ------

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteCustomers.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }
    }


}
