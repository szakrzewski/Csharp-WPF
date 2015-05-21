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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace WPFtoSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = "Data Source=database.sqlite;Version=3;"; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqliteCon.Open();
                string Query = "select * from logins where username = '" + username.Text + "' and password ='" + password.Password + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                SQLiteDataReader dataReader = createCommand.ExecuteReader();

                int count = 0;
                while(dataReader.Read())
                {
                    count++;
                }
                
                if (count == 1)
                {
                    this.Hide();
                    sqliteCon.Close();
                    Navigation navWindow = new Navigation();
                    navWindow.ShowDialog();
                }
       
                if (count < 1)
                {
                    MessageBox.Show("Username and password is incorrect");
                }


            }catch(Exception ex)
            
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
