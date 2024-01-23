using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public Dictionary<int, string> Tasks = new Dictionary<int, string>();

        public Category(int id, string categoryName)
        {
            Id = Id;
            CategoryName = categoryName;

        }
    }
}
