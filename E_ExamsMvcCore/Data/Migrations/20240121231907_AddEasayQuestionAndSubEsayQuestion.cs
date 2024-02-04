using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ExamsMvcCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEasayQuestionAndSubEsayQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasayQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasayQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EasayQuestion_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubEasayQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EasayQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubEasayQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubEasayQuestion_EasayQuestion_EasayQuestionId",
                        column: x => x.EasayQuestionId,
                        principalTable: "EasayQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasayQuestion_ExamId",
                table: "EasayQuestion",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_SubEasayQuestion_EasayQuestionId",
                table: "SubEasayQuestion",
                column: "EasayQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubEasayQuestion");

            migrationBuilder.DropTable(
                name: "EasayQuestion");
        }
    }
}
