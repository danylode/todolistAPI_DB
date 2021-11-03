using Microsoft.EntityFrameworkCore.Migrations;

namespace todolistApiEF.Migrations
{
    public partial class AddedListIdSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_task_lists_task_list_id",
                table: "task");

            migrationBuilder.AlterColumn<int>(
                name: "task_list_id",
                table: "task",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_task_task_lists_task_list_id",
                table: "task",
                column: "task_list_id",
                principalTable: "task_lists",
                principalColumn: "task_list_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_task_lists_task_list_id",
                table: "task");

            migrationBuilder.AlterColumn<int>(
                name: "task_list_id",
                table: "task",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_task_task_lists_task_list_id",
                table: "task",
                column: "task_list_id",
                principalTable: "task_lists",
                principalColumn: "task_list_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
