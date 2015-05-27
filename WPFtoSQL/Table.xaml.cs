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
    /// Interaction logic for third.xaml
    /// </summary>
    public partial class Table : Window
    {
        string dbConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\psf\Home\Desktop\Csharp-WPF\WPFtoSQL\database.mdf;Integrated Security=True;Connect Timeout=30";
        Jumps nav = new Jumps();

        public Table()
        {
            InitializeComponent();
            LoadTable();
        }

        void LoadTable()
        {
            SqlConnection sqlCon = new SqlConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqlCon.Open();
                string Query = "select id,name,surname,age from employee";
                SqlCommand createCommand = new SqlCommand(Query, sqlCon);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
                DataTable dataTable = new DataTable("employee");
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
                dataAdapter.Update(dataTable);

                sqlCon.Close();
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
