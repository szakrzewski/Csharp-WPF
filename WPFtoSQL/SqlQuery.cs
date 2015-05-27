using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.SqlClient;


namespace WPFtoSQL
{
    class SqlQuery
    {
       
        public void passQuery(string Query, string message)
        {
            string dbConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\psf\Home\Desktop\Csharp-WPF\WPFtoSQL\database.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection sqliteCon = new SqlConnection(dbConnectionString);
           
            try
            {
                sqliteCon.Open();
                SqlCommand createCommand = new SqlCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show(message);
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
