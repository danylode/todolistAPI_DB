using Microsoft.EntityFrameworkCore;

namespace todolistApiEF.Models
{
    public class TodoListContext : DbContext
    {
        public TodoListContext() { }
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }
    }
}