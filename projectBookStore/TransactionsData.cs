using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectBookStore
{
    internal class TransactionsData
    {
        //------ Transactions TABLE ------
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=SqlTransactions.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT EXISTS Transac (" +
                    "OrderID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "ISBN INTEGER NULL, " +
                    "Customer_Id INTEGER NULL, " +
                    "Quatity INTEGER NULL, " +
                    "Total_Price INTEGER NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteNonQuery(); 
                db.Close();
            }
        }
        //------ End Transactions TABLE ------

        //------ ADD Transactions TABLE ------
        public static void AddData(int inputISBN, int inputCustomerId, int inputQuatity, int inputTotal)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=SqlTransactions.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO Transac (ISBN, Customer_Id, Quatity, Total_Price) VALUES (@ISBN, @Customer_Id, @Quatity, @Total_Price)";
                insertCommand.Parameters.AddWithValue("@ISBN", inputISBN);
                insertCommand.Parameters.AddWithValue("@Customer_Id", inputCustomerId);
                insertCommand.Parameters.AddWithValue("@Quatity", inputQuatity);
                insertCommand.Parameters.AddWithValue("@Total_Price", inputTotal);
                insertCommand.ExecuteNonQuery();
                db.Close();
            }
        }
        //------ End ADD Transactions TABLE ------

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Filename=SqlTransactions.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM Transac", db);
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
