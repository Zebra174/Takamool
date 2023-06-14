using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AfterTaskDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "task_template",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "courtCircle",
                table: "Isuues",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "courtCity",
                table: "Isuues",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    taskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    projected_start = table.Column<DateTime>(type: "date", nullable: true),
                    projected_end = table.Column<DateTime>(type: "date", nullable: true),
                    due_date = table.Column<DateTime>(type: "date", nullable: true),
                    actual_end = table.Column<DateTime>(type: "date", nullable: true),
                    taskStatus = table.Column<int>(type: "int", nullable: true),
                    empName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    projManger = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tasks__DD5D55A2A6DB912A", x => x.taskID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropColumn(
                name: "courtCircle",
                table: "Isuues");

            migrationBuilder.DropColumn(
                name: "courtCity",
                table: "Isuues");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "task_template",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
