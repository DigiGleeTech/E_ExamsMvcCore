using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ExamsMvcCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuestionFromEsayQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasayQuestion_Questions_QuestionId",
                table: "EasayQuestion");

            migrationBuilder.DropIndex(
                name: "IX_EasayQuestion_QuestionId",
                table: "EasayQuestion");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "EasayQuestion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "EasayQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EasayQuestion_QuestionId",
                table: "EasayQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EasayQuestion_Questions_QuestionId",
                table: "EasayQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
