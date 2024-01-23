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

namespace MyTaskManager
{
    /// <summary>
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {
        DatabaseConnection db = new DatabaseConnection();
        public List<Task> Tasks { get; set; } = new List<Task>();
        public TaskView()
        {
            InitializeComponent();
            Tasks = db.GetTasks();
            taskDataGrid.ItemsSource = Tasks;
        }
    }
}
