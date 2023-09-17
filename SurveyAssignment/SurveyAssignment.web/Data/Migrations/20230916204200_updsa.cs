using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAssignment.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "Response");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Response",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
