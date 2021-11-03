using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolistApiEF.Models;

namespace todolistApiEF.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class TaskListController : ControllerBase
    {   
        TodoListService _service;
        public TaskListController(TodoListService service)
        {
            this._service = service;
        }

        [HttpGet("")]
        public ActionResult<List<TaskList>> GetAllLists()
        {
            return Ok(_service.GetAllTasksList());
        }

        [HttpGet("{listId}")]
        public ActionResult<TaskList> GetListById(int listId){
            return Ok(_service.GetTaskListById(listId));
        }

        [HttpPost("")]
        public ActionResult<List<TaskList>> CreateNewTaskList(TaskList newList){
            return Ok(_service.CreateTaskList(newList));
        }

        [HttpDelete("{listId}")]
        public ActionResult<List<TaskList>> DeleteTaskListById(int listId){
            return Ok(_service.DeleteTaskList(listId));
        }

    }
}