using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyTaskManager
{
    public class DatabaseConnection
    {
        string server = "localhost";
        string database = "task_management";
        string uid = "root";
        string password = "ripper1337";

        public string connectionString;
        MySqlConnection connection;
        public Dictionary<int, string> Users = new Dictionary<int, string>();
        public DatabaseConnection()
        {
            connectionString =
                 "SERVER=" + server + ";" +
                 "DATABASE=" + database + ";" +
                 "UID=" + uid + ";" +
                 "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public bool LoginCheck(string username, string password)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "SELECT * FROM users WHERE username = @username AND password = @password";
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.Read();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "SELECT * FROM users";
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return users;
        }
        
        private MySqlDataReader RunQuery(string query, MySqlConnection connection)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "SELECT * FROM tasks";
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tasks.Add(new Task(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return tasks;
        }
        public void AddUser(string username, string password, string email)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "INSERT INTO users(username, password, email) VALUES(@username, @password, @email)";
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteUser(int id)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "DELETE FROM users WHERE user_id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateUser(int id, string username, string password, string email)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "UPDATE users SET username = @username, email = @email, password = @password WHERE user_id = @id";
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public void AddTask(string taskName, string taskDescription)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "INSERT INTO tasks(task_name, task_description) VALUES(@taskName, @taskDescription)";
                        cmd.Parameters.AddWithValue("@taskName", taskName);
                        cmd.Parameters.AddWithValue("@taskDescription", taskDescription);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteTask(int id)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "DELETE FROM tasks WHERE task_id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateTask(int id, string taskName, string taskDescription)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "UPDATE tasks SET task_name = @taskName, task_description = @taskDescription WHERE task_id = @id";
                        cmd.Parameters.AddWithValue("@taskName", taskName);
                        cmd.Parameters.AddWithValue("@taskDescription", taskDescription);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        public List<object> GetUserTasks()
        {
            List<object> userTasks = new List<object>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT " +
                             "tasks.task_id, " +
                             "tasks.task_name, " +
                             "tasks.task_description, " +
                             "users.user_id, " +
                             "users.username, " +
                             "users.email, " +
                             "category.category_name " +  
                             "FROM " +
                             "tasks " +
                             "JOIN " +
                             "task_user ON tasks.task_id = task_user.task_id " +
                             "JOIN " +
                             "users ON task_user.user_id = users.user_id " +
                             "JOIN " +
                             "category ON task_user.category_id = category.category_id;"; 
                
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userTasks.Add(new
                    {
                        TaskId = reader.GetInt32(0),
                        TaskName = reader.GetString(1),
                        TaskDescription = reader.GetString(2),
                        UserId = reader.GetInt32(3),
                        Username = reader.GetString(4),
                        Email = reader.GetString(5),
                        CategoryName = reader.GetString(6)  
                    });
                }
                reader.Close();
                return userTasks;
            }
        }

        public void AddCategory(string name)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "INSERT INTO category(category_name) VALUES(@name)";
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public void RemoveCategory(int id)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "DELETE FROM category WHERE category_id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void UpdateCategory(int id, string name)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "UPDATE category SET category_name = @name WHERE category_id = @id";
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteCategory(int id)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "DELETE FROM category WHERE category_id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "SELECT * FROM category";
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new Category(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return categories;

        }

       

        public void AssignTaskToCategoryAndUser(int userId, int taskId, int categoryId)
        {
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "INSERT INTO task_user(user_id, task_id, category_id) VALUES(@userId, @taskId, @categoryId)";
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@taskId", taskId);
                        cmd.Parameters.AddWithValue("@categoryId", categoryId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public void SearchDataBase(string search)
        {
            StringBuilder message = new StringBuilder();
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    string sql = @"SELECT tasks.task_id, tasks.task_name, tasks.task_description, 
                                  users.username, category.category_name
                          FROM tasks
                          JOIN task_user ON tasks.task_id = task_user.task_id
                          JOIN users ON task_user.user_id = users.user_id
                          LEFT JOIN category ON task_user.category_id = category.category_id
                          WHERE tasks.task_name LIKE @search
                             OR users.username LIKE @search";
                    using (MySqlCommand cmd = new MySqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                message.AppendLine($"Task ID: {reader.GetInt32(0)}");
                                message.AppendLine($"Task Name: {reader.GetString(1)}");
                                message.AppendLine($"Task Description: {reader.GetString(2)}");
                                message.AppendLine($"Assigned User: {reader.GetString(3)}");
                                message.AppendLine($"Category: {reader.GetString(4)}");
                                message.AppendLine(); // Add empty line for separation
                            }
                        }
                    }                    
                    MessageBox.Show(message.ToString(), "Search Results", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                    MessageBox.Show("An error occurred while searching the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public string RetriveTaskDetalis(User selectedUser, Task selectedTask, Category selectedCategory)
        {
            
            StringBuilder message = new StringBuilder();
            using (MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    string sql = @"SELECT tasks.task_id, tasks.task_name, tasks.task_description, 
                                 users.username, category.category_name
                                 FROM tasks
                                 JOIN task_user ON tasks.task_id = task_user.task_id
                                 JOIN users ON task_user.user_id = users.user_id
                                 LEFT JOIN category ON task_user.category_id = category.category_id
                                 WHERE tasks.task_name LIKE @search
                                 OR users.username LIKE @search";
                    using (MySqlCommand cmd = new MySqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + selectedUser + "%");
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                message.AppendLine($"Task ID: {reader.GetInt32(0)}");
                                message.AppendLine($"Task Name: {reader.GetString(1)}");
                                message.AppendLine($"Task Description: {reader.GetString(2)}");
                                message.AppendLine($"Assigned User: {reader.GetString(3)}");
                                message.AppendLine($"Category: {reader.GetString(4)}");
                                message.AppendLine(); 
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                    MessageBox.Show("An error occurred while searching the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return message.ToString();
        }
    }
}
