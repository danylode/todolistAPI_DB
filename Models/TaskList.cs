using System;
using System.Collections.Generic;

namespace todolistApiEF.Models
{
    public class TaskList
    {
        public int TaskListId { get; set; }
        public string Title { get; set; }
        public List<TodoTask> Tasks { get; set; }
    }
}