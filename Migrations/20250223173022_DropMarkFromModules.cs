using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnderservedCommunitiesLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class DropMarkFromModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Modules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Modules",
                type: "text",
                nullable: true);
        }
    }
}

