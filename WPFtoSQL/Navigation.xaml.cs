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

namespace WPFtoSQL
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Window
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void data_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DataEntry dataEntryWindow = new DataEntry();
            dataEntryWindow.ShowDialog();
        }

        private void table_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Table tableWindow = new Table();
            tableWindow.ShowDialog();
        }

        private void admin_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin adminWindow = new Admin();
            adminWindow.ShowDialog();
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
