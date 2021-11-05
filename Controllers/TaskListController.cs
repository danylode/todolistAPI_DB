using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolistApiEF.Models;
using todolistApiEF.Models.DTO;

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
        public ActionResult<List<ReturnTaskListDTO>> GetAllLists()
        {
            return Ok(_service.GetAllTasksList());
        }

        [HttpGet("{listId}")]
        public ActionResult<ReturnTaskListDTO> GetListById(int listId){
            return Ok(_service.GetTaskListById(listId));
        }

        [HttpPost("")]
        public ActionResult<List<ReturnTaskListDTO>> CreateNewTaskList(NewTaskListDTO newList){
            return Ok(_service.CreateTaskList(newList));
        }

        [HttpDelete("{listId}")]
        public ActionResult<List<ReturnTaskListDTO>> DeleteTaskListById(int listId){
            return Ok(_service.DeleteTaskList(listId));
        }

    }
}