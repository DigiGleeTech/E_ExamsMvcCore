using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ExamsMvcCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertLecturerIdToStringIncourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_LecturerId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LecturerId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LecturerId1",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "LecturerId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_LecturerId",
                table: "Courses",
                column: "LecturerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_LecturerId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerId",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "LecturerId1",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturerId1",
                table: "Courses",
                column: "LecturerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_LecturerId1",
                table: "Courses",
                column: "LecturerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
