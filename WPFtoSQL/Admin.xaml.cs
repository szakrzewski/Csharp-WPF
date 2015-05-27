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
using System.Data;
using System.Data.SqlClient;

namespace WPFtoSQL
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        SqlQuery sqlQuery1 = new SqlQuery();

        public Admin()
        {
            InitializeComponent();
            LoadTable();
        }

        void LoadTable()
        {
            string dbConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\psf\Home\Desktop\Csharp-WPF\WPFtoSQL\database.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection sqlCon = new SqlConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqlCon.Open();
                string Query = "select username, password from logins";
                SqlCommand createCommand = new SqlCommand(Query, sqlCon);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
                DataTable dataTable = new DataTable("logins");
                dataAdapter.Fill(dataTable);
                admin_dataGrid.ItemsSource = dataTable.DefaultView;
                dataAdapter.Update(dataTable);

                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quit_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void nav_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Navigation navWindow = new Navigation();
            navWindow.ShowDialog();
        }

        private void button_submit_Click(object sender, RoutedEventArgs e)
        {
            sqlQuery1.passQuery("insert into username(username, password) values ('" + username.Text + "','" + password.Text + "')", "Data Saved");
        }
        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            sqlQuery1.passQuery("update logins set id = '" + username.Text + "', name = '" + password.Text + "' ", "Data Updated");      
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            sqlQuery1.passQuery("delete from logins where username = '" + username.Text + "'", "User Deleted");
        }
    }

}
