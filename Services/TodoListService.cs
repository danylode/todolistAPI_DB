using System;
using System.Linq;
using System.Collections.Generic;
using todolistApiEF.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using todolistApiEF.Models.DTO;
using Npgsql;

namespace todolistApiEF
{
    public class TodoListService
    {

        private TodoListContext _context;

        public TodoListService(TodoListContext context)
        {
            this._context = context;
        }
        #region "TaskLists"
        public List<ReturnTaskListDTO> GetAllTasksList()
        {
            _context.TaskLists.Include(x => x.Tasks);
            return _context.TaskLists.Select(x => ConvertTaskListToDTO(x)).ToList();
        }

        public ReturnTaskListDTO GetTaskListById(int taskListId)
        {
            return ConvertTaskListToDTO(_context.TaskLists.Where(x => x.TaskListId == taskListId).Single());
        }

        public List<ReturnTaskListDTO> CreateTaskList(NewTaskListDTO newList)
        {
            _context.TaskLists.Add(new TaskList()
            {
                Title = newList.Title,
                Tasks = new List<TodoTask>()
            });
            _context.SaveChanges();
            return GetAllTasksList();
        }

        public List<ReturnTaskListDTO> DeleteTaskList(int taskListId)
        {
            _context.TaskLists.Remove(_context.TaskLists.Where(x => x.TaskListId == taskListId).Single());
            _context.SaveChanges();
            return GetAllTasksList();
        }

        public static ReturnTaskListDTO ConvertTaskListToDTO(TaskList taskList)
        {
            return new ReturnTaskListDTO()
            {
                ListId = taskList.TaskListId,
                Title = taskList.Title
            };
        }
        #endregion

        #region "Tasks"
        public List<ReturnTaskDTO> GetAllTasks()
        {
            return _context.Tasks.Include(x => x.TaskList).Select(x => ConvertTaskToDTO(x)).ToList();
        }

        public List<ReturnTaskDTO> GetTasksByTaskListId(int listId)
        {
            return _context.Tasks.Where(x => x.TaskListId == listId).Select(x => ConvertTaskToDTO(x)).ToList();
        }

        public ReturnTaskDTO GetTask(int taskId)
        {
            return ConvertTaskToDTO(_context.Tasks.Where(x => x.TodoTaskId == taskId).Single());
        }

        public List<ReturnTaskDTO> PostTask(int listId, NewTaskDTO task)
        {
            _context.Tasks.Add(new TodoTask
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Done = task.Done,
                TaskList = _context.TaskLists.Where(x => x.TaskListId == listId).Single()
            });
            _context.SaveChanges();
            return GetTasksByTaskListId(listId);
        }

        public TodoTask PutTask(int taskId, TodoTask newTask)
        {
            return new TodoTask();
        }

        public ReturnTaskDTO PatchTask(int taskId, JsonPatchDocument<TodoTask> newTask)
        {
            newTask.ApplyTo(_context.Tasks.Where(x => x.TodoTaskId == taskId).Single());
            _context.SaveChanges();
            return GetTask(taskId);
        }

        public List<ReturnTaskDTO> DeleteTaskByTaskId(int taskId)
        {
            var removeTask = _context.Tasks.Where(x => x.TodoTaskId == taskId).Single();
            _context.Tasks.Remove(removeTask);
            _context.SaveChanges();
            return GetTasksByTaskListId(removeTask.TaskListId);
        }

        public static ReturnTaskDTO ConvertTaskToDTO(TodoTask x)
        {
            return new ReturnTaskDTO()
            {
                TaskListId = x.TaskListId,
                TaskId = x.TodoTaskId,
                TaskName = x.Title,
                TaskDescription = x.Description,
                TaskDate = x.DueDate,
                TaskDone = x.Done
            };
        }
        #endregion

        #region "ef task methods"

        public List<TodayTaskDTO> GetTodayTask()
        {
            var tasks = _context.Tasks.Include(x => x.TaskList).Where(x => DateTime.Equals(DateTime.Today.Date, x.DueDate.Value.Date)).Select(x => new TodayTaskDTO
            {
                TaskList = ConvertTaskListToDTO(x.TaskList),
                TaskId = x.TodoTaskId,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                Done = x.Done

            }).ToList();
            return tasks;
        }

        public List<DashboardListDTO> GetDashboard()
        {
            var listInfo = _context.Tasks.Where(x => x.Done == false);
            
            /*var result = _context.TaskLists.Join(_context.Tasks.Where(x => x.Done == false), x => x.TaskListId, y => y.TaskListId, (x, y) => new DashboardTaskCountDTO
            {
                ListId = x.TaskListId,
                Title = y.Title,
                TaskCount = x.Tasks.Count()
            }).ToList();*/ 
            return null;
        }

        public List<DashboardListDTO> GetDashboardBySql()
        {
            string sqlRequest = "SELECT * FROM task_lists RIGHT JOIN (SELECT task_list_id, COUNT(done) FROM tasks WHERE done = false GROUP BY task_list_id) AS dons ON task_lists.task_list_id = dons.task_list_id";

            List<DashboardListDTO> result = new List<DashboardListDTO>();

            using (var connection = new NpgsqlConnection("Host=127.0.0.1;Username=todolist_api_app;Password=secret;Database=todolist_api"))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(sqlRequest, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(new DashboardListDTO()
                        {
                            ListId = reader.GetInt16(0),
                            Title = reader.GetString(1),

                        });
                    }
                }
            }
            return result;
        }

        #endregion
    }
}