using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows;


namespace WPFtoSQL
{
    class SqlQuery
    {
       
        public void passQuery(string Query, string message)
        {
            string dbConnectionString = "Data Source=database.sqlite;Version=3;";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqliteCon.Open();
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show(message);
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void dataQuery(string Query)
        {
            string dbConnectionString = "Data Source=database.sqlite;Version=3;";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            sqliteCon.Open();
            SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
            createCommand.ExecuteNonQuery();
        }

    }
}
