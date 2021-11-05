using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolistApiEF.Models;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using todolistApiEF.Models.DTO;

namespace todolistApiEF.Controllers
{
    [Route("api/lists/{listId}/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TodoListService _service;
        public TaskController(TodoListService service)
        {
            this._service = service;
        }

        [HttpGet("")]
        public ActionResult<List<ReturnTaskDTO>> GetTasksByTaskListId(int listId, bool all = false)
        {
            
            return Ok(all == false? _service.GetTasksByTaskListId(listId): _service.GetTasksByTaskListId(listId).Where(x => x.Done == true).ToList());
        }

        [HttpGet("{taskId}")]
        public ActionResult<ReturnTaskDTO> GetTaskById(int taskId)
        {
            return Ok(_service.GetTask(taskId));
        }

        [HttpPost("")]
        public ActionResult<List<ReturnTaskDTO>> PostTask(int listId,NewTaskDTO newTask)
        {
            return Ok(_service.PostTask(listId,newTask));
        }

        [HttpDelete("{taskId}")]
        public ActionResult<List<ReturnTaskDTO>> DeleteTask(int taskId)
        {
            return Ok(_service.DeleteTaskByTaskId(taskId));
        }

        [HttpPut("{taskId}")]
        public ActionResult<ReturnTaskDTO> PutTaskById(int taskId, TodoTask newTask){
            return Ok(_service.PutTask(taskId, newTask));
        }

        [HttpPatch("{taskId}")]
        public ActionResult<ReturnTaskDTO> PatchTaskById(int taskId, JsonPatchDocument<NewTaskDTO> task)
        {
            return Ok(_service.PatchTask(taskId, task));
        }

    }
}