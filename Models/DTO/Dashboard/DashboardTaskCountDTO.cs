using System;
using System.Collections.Generic;
using todolistApiEF.Models;

namespace todolistApiEF
{
    public class DashboardListDTO
    {
        public int ListTaskCount { get; set; }
        public int ListId { get; set; }
        public string Title { get; set; }
    }
}
