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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public Dictionary<int, User> Task_user = new Dictionary<int, User>();
        
        
        DatabaseConnection db = new DatabaseConnection();
        public MainView()
        {
            InitializeComponent();
            Task_user = db.GetAll();
            mainDataGrid.ItemsSource = Task_user;

        }
    }
}
