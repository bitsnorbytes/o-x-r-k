using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class TMDBSchemaSyncV02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "genre_names",
                table: "Movies",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "original_language_english_name",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genre_names",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "original_language_english_name",
                table: "Movies");
        }
    }
}
