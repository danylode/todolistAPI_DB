using System;

namespace todolistApiEF.Models
{
    public class TodoTask
    {
        public int TodoTaskId { get; set; }
        public int TaskListId { get; set; }
        public TaskList TaskList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
    }
}