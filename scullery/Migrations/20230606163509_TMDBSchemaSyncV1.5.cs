using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class TMDBSchemaSyncV15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "media_type",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "media_type",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
