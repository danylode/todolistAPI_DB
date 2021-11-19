using System;

namespace todolistApiEF.Models.DTO
{
    public class NewTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
    }
}