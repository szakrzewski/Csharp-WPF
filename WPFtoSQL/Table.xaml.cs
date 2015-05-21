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
using System.Data.SQLite;
using System.Data;

namespace WPFtoSQL
{
    /// <summary>
    /// Interaction logic for third.xaml
    /// </summary>
    public partial class Table : Window
    {
        string dbConnectionString = "Data Source=database.sqlite;Version=3;";
        Jumps nav = new Jumps();

        public Table()
        {
            InitializeComponent();
            LoadTable();
        }

        void LoadTable()
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqliteCon.Open();
                string Query = "select id,name,surname,age from employee";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(createCommand);
                DataTable dataTable = new DataTable("employee");
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
                dataAdapter.Update(dataTable);

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            nav.NavigationWindow();
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
