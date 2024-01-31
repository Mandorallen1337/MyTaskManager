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
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        DatabaseConnection db = new DatabaseConnection();
        public List<Category> Categories { get; set; } = new List<Category>();
        public CategoryView()
        {
            InitializeComponent();
            Categories = db.GetCategories();
            CategoryDataGrid.ItemsSource = Categories;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if(categoryBox.Text != "")
            {
                DatabaseConnection db = new DatabaseConnection();
                db.AddCategory(categoryBox.Text);
                MessageBox.Show("Category added successfully!");
                //Refresh the datagrid
                Categories = db.GetCategories();
                CategoryDataGrid.ItemsSource = Categories;
                categoryBox.Text = "";
                
            }
            else
            {
                MessageBox.Show("Please enter a category name!");
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if(CategoryDataGrid.SelectedItem != null)
            {
                Category category = (Category)CategoryDataGrid.SelectedItem;
                db.UpdateCategory(category.Id, categoryBox.Text);
                MessageBox.Show("Category updated successfully!");
                Categories = db.GetCategories();
                CategoryDataGrid.ItemsSource = Categories;
                categoryBox.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a category to update!");
            }
        }

        private void CategoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoryDataGrid.SelectedItem != null)
            {
                Category category = (Category)CategoryDataGrid.SelectedItem;
                categoryBox.Text = category.CategoryName;
            }

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(CategoryDataGrid.SelectedItem != null)
            {
                Category category = (Category)CategoryDataGrid.SelectedItem;
                db.DeleteCategory(category.Id);
                MessageBox.Show("Category deleted successfully!");
                Categories = db.GetCategories();
                CategoryDataGrid.ItemsSource = Categories;
                categoryBox.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a category to delete!");
            }
        }
    }
}
