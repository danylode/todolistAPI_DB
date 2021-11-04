using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolistApiEF.Models;

namespace todolistApiEF.Controllers
{
    [Route("api/collection/today")]
    [ApiController]
    public class TodayTasksController : ControllerBase
    {
        private TodoListService _service;
        public TodayTasksController(TodoListService service)
        {
            this._service = service;
        }

        [HttpGet("")]
        public ActionResult<Dictionary<int, List<TodoTask>>> GetTodayTasks(){
            
            return Ok(_service.GetTodayTask());
        }
    }
}