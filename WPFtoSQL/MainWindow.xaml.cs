﻿using System;
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
using System.Data.SqlClient;

namespace WPFtoSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\psf\Home\Desktop\Csharp-WPF\WPFtoSQL\database.mdf;Integrated Security=True;Connect Timeout=30"; 


        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(dbConnectionString);
            //Open connection to database
            try
            {
                sqlCon.Open();
                string Query = "select * from logins where username = '" + username.Text + "' and password ='" + password.Password + "' ";
                SqlCommand createCommand = new SqlCommand(Query, sqlCon);
                createCommand.ExecuteNonQuery();
                SqlDataReader dataReader = createCommand.ExecuteReader();

                int count = 0;
                while(dataReader.Read())
                {
                    count++;
                }
                
                if (count == 1)
                {
                    this.Hide();
                    sqlCon.Close();
                    Jumps nav = new Jumps(); 
                    nav.NavigationWindow();
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
