using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_ExamsMvcCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidateNumberToCandidateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateNumber",
                table: "AspNetUsers");
        }
    }
}
