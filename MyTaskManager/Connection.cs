using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager
{
    public class Connection
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public Connection(int taskId, int userId, int categoryId)
        {
            TaskId = taskId;
            UserId = userId;
            CategoryId = categoryId;
        }
    }
}
