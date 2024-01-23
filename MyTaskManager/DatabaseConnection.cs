using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using(MySqlConnection db = new MySqlConnection(connectionString))
            {
                try { 
                db.Open();
                using(MySqlCommand cmd = new MySqlCommand())
                {
                      cmd.Connection = db;
                      cmd.CommandText = "SELECT * FROM users WHERE username = @username AND password = @password";
                      cmd.Parameters.AddWithValue("@username", username);
                      cmd.Parameters.AddWithValue("@password", password);
                      
                      using(MySqlDataReader reader = cmd.ExecuteReader())
                      {
                          return reader.Read();
                      }
                }
            }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using(MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using(MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "SELECT * FROM users";
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                users.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return users;
        }
        public Dictionary<int,User> GetAll() 
        {
            Dictionary<int, User> userList = new Dictionary<int, User>();
            Dictionary<int, string> taskList = new Dictionary<int, string>();
            Dictionary<int, string> categoryList = new Dictionary<int, string>();
            connection.Open();
            
            MySqlDataReader reader = RunQuery("SELECT * FROM users", connection);
            while(reader.Read())
            {
                Users.Add(reader.GetInt32(0), reader.GetString(1));
            }
            reader.Close();
            reader = RunQuery("SELECT * FROM tasks", connection);
            while(reader.Read())
            {
                taskList.Add(reader.GetInt32(0), reader.GetString(1));
            }
            reader.Close();
            reader = RunQuery("SELECT * FROM category", connection);
            while(reader.Read())
            {
                categoryList.Add(reader.GetInt32(0), reader.GetString(1));
            }
            reader.Close();
            return userList;
            //Fix this method
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
            using(MySqlConnection db = new MySqlConnection(connectionString))
            {
                try
                {
                    db.Open();
                    using(MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = db;
                        cmd.CommandText = "SELECT * FROM tasks";
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                tasks.Add(new Task(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return tasks;
        }
    }
}
