using System;

namespace todolistApiEF.Models.DTO
{
    public class ReturnTaskDTO
    {
        public int TaskListId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? TaskDate { get; set; }
        public bool TaskDone { get; set; }
    }
}