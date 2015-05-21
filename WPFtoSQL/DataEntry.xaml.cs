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
    /// Interaction logic for second.xaml
    /// </summary>
    public partial class DataEntry : Window
    {
        Jumps nav = new Jumps();
        string dbConnectionString = "Data Source=database.sqlite;Version=3;";
        SqlQuery sqlQuery2 = new SqlQuery();

        public DataEntry()
        {
            InitializeComponent();
            Fill_ComboBox();
            Fill_ListBox();
           
        }

        private void button_submit_Click(object sender, RoutedEventArgs e)
        {
             sqlQuery2.passQuery("insert into employee(id, name, surname, age) values ('" + id.Text + "','" + name.Text + "','" + surname.Text + "', '" + age.Text + "' )", "Data Saved");
        }
        private void button_update_Click(object sender, RoutedEventArgs e)
        { 
            sqlQuery2.passQuery("update employee set id = '" + id.Text + "', name = '" + name.Text + "', surname = '" + surname.Text + "', age = '" + age.Text + "' where id = '" + id.Text + "' ", "Data Updated");      
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            sqlQuery2.passQuery("delete from employee where id = '"+id.Text+"'", "User Deleted");       
        }

        void Fill_ComboBox()
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqliteCon.Open();
                string Query = "select * from employee";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dataReader = dataReader = createCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    string name = dataReader.GetString(1);
                    comboBox1.Items.Add(name);

                }

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void Fill_ListBox()
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqliteCon.Open();
                string Query = "select * from employee";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dataReader = dataReader = createCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    string name = dataReader.GetString(1);
                    string surname = dataReader.GetString(2);
                    listBox1.Items.Add(name + " " + surname);

                }

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqliteCon.Open();
                string Query = "select * from employee where name = '" + comboBox1.Text + "'";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dataReader = dataReader = createCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    string sId = dataReader.GetInt32(0).ToString();
                    string sName = dataReader.GetString(1);
                    string sSurname = dataReader.GetString(2);
                    string sAge = dataReader.GetInt32(3).ToString();

                    id.Text = sId;
                    name.Text = sName;
                    surname.Text = sSurname;
                    age.Text = sAge;

                }

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
            nav.TableWindow();
        }

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            nav.AdminWindow();
        }

        private void previous_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            nav.NavigationWindow();
        }

        private void quit_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
