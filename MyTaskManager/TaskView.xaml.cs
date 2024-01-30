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
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {
        DatabaseConnection db = new DatabaseConnection();
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<User> Users { get; set; } = new List<User>();
        public TaskView()
        {
            InitializeComponent();
            Tasks = db.GetTasks();
            taskDataGrid.ItemsSource = Tasks;
            
            
        }

        

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskNameBox.Text != "" && descriptionBox.Text != "")
            {
                string taskName = taskNameBox.Text;
                string taskDescription = descriptionBox.Text;
                
                db.AddTask(taskName, taskDescription);
                Tasks = db.GetTasks();
                taskDataGrid.ItemsSource = Tasks;

            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskDataGrid.SelectedItem != null)
            {
                Task task = (Task)taskDataGrid.SelectedItem;
                db.UpdateTask(task.Id, taskNameBox.Text, descriptionBox.Text);
                Tasks = db.GetTasks();
                taskDataGrid.ItemsSource = Tasks;
            }

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskDataGrid.SelectedItem != null)
            {
                Task task = (Task)taskDataGrid.SelectedItem;
                db.DeleteTask(task.Id);
                Tasks = db.GetTasks();
                taskDataGrid.ItemsSource = Tasks;
            }
        }

        private void taskDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (taskDataGrid.SelectedItem != null)
            {
                Task task = (Task)taskDataGrid.SelectedItem;
                taskNameBox.Text = task.TaskName;
                descriptionBox.Text = task.TaskDescription;
            }
        }

        
        
    }
}
