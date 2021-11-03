using Microsoft.EntityFrameworkCore.Migrations;

namespace todolistApiEF.Migrations
{
    public partial class ContextUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_task_lists_task_list_id",
                table: "task");

            migrationBuilder.DropPrimaryKey(
                name: "pk_task",
                table: "task");

            migrationBuilder.RenameTable(
                name: "task",
                newName: "tasks");

            migrationBuilder.RenameIndex(
                name: "ix_task_task_list_id",
                table: "tasks",
                newName: "ix_tasks_task_list_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tasks",
                table: "tasks",
                column: "task_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_task_lists_task_list_id",
                table: "tasks",
                column: "task_list_id",
                principalTable: "task_lists",
                principalColumn: "task_list_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tasks_task_lists_task_list_id",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tasks",
                table: "tasks");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "task");

            migrationBuilder.RenameIndex(
                name: "ix_tasks_task_list_id",
                table: "task",
                newName: "ix_task_task_list_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_task",
                table: "task",
                column: "task_id");

            migrationBuilder.AddForeignKey(
                name: "fk_task_task_lists_task_list_id",
                table: "task",
                column: "task_list_id",
                principalTable: "task_lists",
                principalColumn: "task_list_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
