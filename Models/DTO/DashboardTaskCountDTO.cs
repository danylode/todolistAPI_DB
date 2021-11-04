using System;
using System.Collections.Generic;
using todolistApiEF.Models;

namespace todolistApiEF
{
    public class DashboardTaskCountDTO
    {
        public int ListId { get; set; }
        public string Title { get; set; }
        public int TaskCount { get; set; }
    }
}