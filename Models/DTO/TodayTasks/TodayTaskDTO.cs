using System;
using System.Collections.Generic;
using todolistApiEF.Models.DTO;

namespace todolistApiEF
{
    public class TodayTaskDTO
    {
        public ReturnTaskListDTO TaskList { get; set; }
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }

    }
}