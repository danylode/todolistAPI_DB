using Microsoft.EntityFrameworkCore.Migrations;

namespace todolistApiEF.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "task_id",
                table: "tasks",
                newName: "todo_task_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "todo_task_id",
                table: "tasks",
                newName: "task_id");
        }
    }
}
