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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public List<User> Users { get; set; } = new List<User>();
        DatabaseConnection db = new DatabaseConnection();
        public UserView()
        {
            InitializeComponent();
            Users = db.GetUsers();
            userDataGrid.ItemsSource = Users;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text != "" && emailBox.Text != "" && passwordBox.Text != "")
            {
                string username = usernameTextBox.Text;
                string password = passwordBox.Text;
                string email = emailBox.Text;
                db.AddUser(username, password, email);
                Users = db.GetUsers();
                userDataGrid.ItemsSource = Users;

            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (userDataGrid.SelectedItem != null)
            {
                User user = (User)userDataGrid.SelectedItem;
                db.DeleteUser(user.Id);
                Users = db.GetUsers();
                userDataGrid.ItemsSource = Users;
            }





        }

        private void userDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userDataGrid.SelectedItem != null)
            {
                User user = (User)userDataGrid.SelectedItem;
                usernameTextBox.Text = user.Username;
                passwordBox.Text = user.Password;
                emailBox.Text = user.Email;
            }
            else
            {
                usernameTextBox.Text = "";
                passwordBox.Text = "";
                emailBox.Text = "";
            }


        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

            User selectedUser = (User)userDataGrid.SelectedItem;
            if (selectedUser != null)
            {
                string username = usernameTextBox.Text;
                string password = passwordBox.Text;
                string email = emailBox.Text;
                db.UpdateUser(selectedUser.Id, username, password, email);

                userDataGrid.ItemsSource = db.GetUsers();
            }

        }
    }
}
