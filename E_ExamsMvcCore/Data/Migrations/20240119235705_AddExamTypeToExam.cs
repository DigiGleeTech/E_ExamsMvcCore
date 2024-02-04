using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ExamsMvcCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExamTypeToExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamType",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamType",
                table: "Exams");
        }
    }
}
