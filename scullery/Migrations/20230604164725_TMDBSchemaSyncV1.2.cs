using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class TMDBSchemaSyncV12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "genre_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "Genres",
                newName: "GenreId");
        }
    }
}
