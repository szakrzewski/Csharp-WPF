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
    class Jumps
    {
        public void DataEntryWindow()
        {
            DataEntry dataEntryWindow = new DataEntry();
            dataEntryWindow.ShowDialog();
        }

        public void TableWindow()
        {
            Table tableWindow = new Table();
            tableWindow.ShowDialog();
        }

        public void AdminWindow()
        {
            Admin adminWindow = new Admin();
            adminWindow.ShowDialog();
        }

        public void NavigationWindow()
        {
            Navigation navWindow = new Navigation();
            navWindow.ShowDialog();
        }
    }
}
