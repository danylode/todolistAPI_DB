using System;
using System.Collections.Generic;
using todolistApiEF.Models;

namespace todolistApiEF
{
    public class DashboardDTO
    {
        public int TaskCount { get; set; }
        public List<DashboardListDTO> Lists { get; set; }
    }
}