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
    /// Interaction logic for CombineView.xaml
    /// </summary>
    public partial class CombineView : UserControl
    {
        DatabaseConnection db = new DatabaseConnection();
        public CombineView()
        {
            InitializeComponent();
            db = new DatabaseConnection();
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            userComboBox.ItemsSource = db.GetUsers();
            userComboBox.DisplayMemberPath = "Username";

            taskComboBox.ItemsSource = db.GetTasks();
            taskComboBox.DisplayMemberPath = "TaskName";

            categoryComboBox.ItemsSource = db.GetCategories();
            categoryComboBox.DisplayMemberPath = "CategoryName";
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)userComboBox.SelectedItem;
            Task selectedTask = (Task)taskComboBox.SelectedItem;
            Category selectedCategory = (Category)categoryComboBox.SelectedItem;

            if(selectedUser != null && selectedTask != null && selectedCategory != null)
            {
                string taskDetails = db.RetriveTaskDetalis(selectedUser, selectedTask, selectedCategory);
                taskDetailsTextBlock.Text = taskDetails;
                db.AssignTaskToCategoryAndUser(selectedUser.Id, selectedTask.Id, selectedCategory.Id);
                MessageBox.Show("Connection created!");
            }
            else
            {
                MessageBox.Show("Please select a user, task and category!");
            }
        }
    }
}
