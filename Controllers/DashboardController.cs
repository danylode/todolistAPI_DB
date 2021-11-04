using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolistApiEF.Models;

namespace todolistApiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        TodoListService _service;
        public DashboardController(TodoListService service)
        {
            this._service = service;
        }


        [HttpGet("")]
        public ActionResult<DashboardDTO> GetDashboard(){
            var result = _service.GetDontDoneTaskAnsTaskLists();
            return new DashboardDTO() {TaskCount = result.Count, Lists = result};
        }
    }
}