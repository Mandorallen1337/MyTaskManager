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
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {
        DatabaseConnection db = new DatabaseConnection();
        
        
        public ProjectView()
        {
            InitializeComponent();
            
            List<Object> userTasks = db.GetUserTasksAndCategory();
            projectDataGrid.ItemsSource = userTasks;            
        }

       

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text != "")
            {
                string search = searchBox.Text;
                db.SearchDataBase(search);
                searchBox.Text = "";
                
            }

        }
        
    }
}
