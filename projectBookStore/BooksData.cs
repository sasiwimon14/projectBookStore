using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectBookStore
{
    internal class BooksData
    {
        //------ Books TABLE ------
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteBooks.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Books (ISBN INTEGER PRIMARY KEY, " +
                    "Title NVARCHAR(255) NULL, " +
                    "Description NVARCHAR(2048) NULL, " +
                    "Price float NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        //------ End Books TABLE ------

        //------ ADD Books TABLE ------
        public static void AddData(string inputISBN, string inputTitle, string inputDescription, string inputPrice)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteBooks.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO Books (ISBN, Title, Description, Price) VALUES (@ISBN, @Title, @Description, @Price)";
                insertCommand.Parameters.AddWithValue("@ISBN", inputISBN);
                insertCommand.Parameters.AddWithValue("@Title", inputTitle);
                insertCommand.Parameters.AddWithValue("@Description", inputDescription);
                insertCommand.Parameters.AddWithValue("@Price", inputPrice);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        //------ End ADD Books TABLE ------

        //------ Update Books TABLE ------
        public static void UpdateData(string inputISBN, string inputTitle, string inputDescription, string inputPrice)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteBooks.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Books SET Title = @Title, Description = @Description, Price = @Price WHERE ISBN = @ISBN";
                updateCommand.Parameters.AddWithValue("@ISBN", inputISBN);
                updateCommand.Parameters.AddWithValue("@Title", inputTitle);
                updateCommand.Parameters.AddWithValue("@Description", inputDescription);
                updateCommand.Parameters.AddWithValue("@Price", inputPrice);

                updateCommand.ExecuteNonQuery();

                db.Close();
            }
        }
        //------ End Update Books TABLE ------

        //------ Delete Books TABLE ------
        public static void DeleteData(string inputISBN)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteBooks.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = "DELETE FROM Books WHERE ISBN = @ISBN";
                deleteCommand.Parameters.AddWithValue("@ISBN", inputISBN);

                deleteCommand.ExecuteNonQuery();

                db.Close();
            }
        }
        //------ End Delete Books TABLE ------

        //------ Search Books TABLE ------
        public static List<Dictionary<string, string>> SearchData(string searchISBN)
        {
            List<Dictionary<string, string>> entries = new List<Dictionary<string, string>>();

            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteBooks.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM Books WHERE ISBN LIKE @SearchText", db);
                selectCommand.Parameters.AddWithValue("@SearchText", "%" + searchISBN + "%");

                using (SqliteDataReader query = selectCommand.ExecuteReader())
                {
                    while (query.Read())
                    {
                        Dictionary<string, string> entry = new Dictionary<string, string>
                {
                    { "ISBN", query.GetInt32(0).ToString() },
                    { "Title", query.GetString(1) },
                    { "Description", query.GetString(2) },
                    { "Price", query.GetFloat(3).ToString() }
                };
                        entries.Add(entry);
                    }
                }

                db.Close();
            }

            return entries;
        }
        //------ End Search Books TABLE ------


        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteBooks.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books", db);
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
