using System;
using System.Linq;
using System.Collections.Generic;
using todolistApiEF.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

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
        public List<TaskList> GetAllTasksList()
        {
            return _context.TaskLists.Include(x => x.Tasks).ToList();
        }

        public TaskList GetTaskListById(int taskListId)
        {
            return _context.TaskLists.Where(x => x.TaskListId == taskListId).Single();
        }

        public List<TaskList> CreateTaskList(TaskList newList)
        {
            _context.TaskLists.Add(new TaskList() { Tasks = new List<TodoTask>() });
            _context.SaveChanges();
            return GetAllTasksList();
        }

        public List<TaskList> DeleteTaskList(int taskListId)
        {
            _context.TaskLists.Remove(_context.TaskLists.Where(x => x.TaskListId == taskListId).Single());
            _context.SaveChanges();
            return GetAllTasksList();
        }
        #endregion

        #region "Tasks"
        public List<TodoTask> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public List<TodoTask> GetTasksByTaskListId(int listId)
        {
            return _context.Tasks.Where(x => x.TaskListId == listId).ToList();
        }

        public TodoTask GetTask(int taskId)
        {
            return _context.Tasks.Where(x => x.TodoTaskId == taskId).Single();
        }

        public List<TodoTask> PostTask(TodoTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return GetTasksByTaskListId(task.TaskListId);
        }

        public TodoTask PutTask(int taskId, TodoTask newTask)
        {
            return new TodoTask();
        }

        public TodoTask PatchTask(int taskId, JsonPatchDocument<TodoTask> newTask)
        {
            newTask.ApplyTo(_context.Tasks.Where(x => x.TodoTaskId == taskId).Single());
            _context.SaveChanges();
            return GetTask(taskId);
        }

        public List<TodoTask> DeleteTaskByTaskId(int taskId)
        {
            var removeTask = _context.Tasks.Where(x => x.TodoTaskId == taskId).Single();
            _context.Tasks.Remove(removeTask);
            _context.SaveChanges();
            return GetTasksByTaskListId(removeTask.TaskListId);
        }
        #endregion

        #region "ef task methods"

        public Dictionary<string, List<TodoTask>> GetTodayTask()
        {
            _context.TaskLists.Include(x => x.Tasks).ToList();
            Dictionary<string, List<TodoTask>> result = new Dictionary<string, List<TodoTask>>();
            
            return result;
        }

        public List<DashboardTaskCountDTO> GetDontDoneTaskAnsTaskLists()
        {
            var result = _context.TaskLists.Join(_context.Tasks.Where(x => x.Done == false), x => x.TaskListId, y => y.TaskListId, (x, y) => new DashboardTaskCountDTO { ListId = x.TaskListId, Title = y.Title, TaskCount = x.Tasks.Count() }).ToList();
            return result;
        }


        #endregion
    }
}