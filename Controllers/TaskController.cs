using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolistApiEF.Models;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;

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
        public ActionResult<List<TodoTask>> GetTasksByTaskListId(int listId)
        {
            return Ok(_service.GetTasksByTaskListId(listId));
        }

        [HttpGet("{taskId}")]
        public ActionResult<TodoTask> GetTaskById(int taskId)
        {
            return Ok(_service.GetTask(taskId));
        }

        [HttpPost("")]
        public ActionResult<List<TodoTask>> PostTask(int listId,TodoTask newTask)
        {
            newTask.TaskListId = listId;
            return Ok(_service.PostTask(newTask));
        }

        [HttpDelete("{taskId}")]
        public ActionResult<List<TodoTask>> DeleteTask(int taskId)
        {
            return _service.DeleteTaskByTaskId(taskId);
        }

        [HttpPut("{taskId}")]
        public ActionResult<TodoTask> PutTaskById(int taskId, TodoTask newTask){
            return _service.PutTask(taskId, newTask);
        }

        [HttpPatch("{taskId}")]
        public ActionResult<TodoTask> PatchTaskById(int taskId, JsonPatchDocument<TodoTask> task)
        {
            return _service.PatchTask(taskId, task);
        }

    }
}