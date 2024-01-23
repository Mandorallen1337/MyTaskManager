using MySql.Data.MySqlClient;
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

namespace MyTaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseConnection db = new DatabaseConnection();
        public MainWindow()
        {
            InitializeComponent();
            db.GetUsers();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if(usernameBox.Text == "" || passwordBox.Password == "")
            {
                MessageBox.Show("Please enter a username and password");
                return;
            }

            DatabaseConnection db = new DatabaseConnection();
            bool isLoginSuccessful = db.LoginCheck(usernameBox.Text, passwordBox.Password);

            if (isLoginSuccessful)
            {
                MessageBox.Show("Login successful");
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }
    }
}
