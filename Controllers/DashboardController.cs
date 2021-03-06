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
        public ActionResult<List<DashboardListDTO>> GetDashboard()
        {
            return _service.GetDashboard();
        }

        [HttpGet("npgsql")]
        public ActionResult<List<DashboardListDTO>> GetDashboardBySql(){
            return _service.GetDashboardBySql();
        }

    }
}