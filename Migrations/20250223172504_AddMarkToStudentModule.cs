using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnderservedCommunitiesLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddMarkToStudentModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "StudentModules",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "StudentModules");
        }
    }
}
