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
    }
}
