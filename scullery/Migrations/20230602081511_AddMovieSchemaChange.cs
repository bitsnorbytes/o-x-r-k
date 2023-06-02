using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieSchemaChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movies",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "genre_id");

            migrationBuilder.AddColumn<string>(
                name: "backdrop_path",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_adult",
                table: "Movies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "original_language",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "original_title",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "overview",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "poster_path",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "release_date",
                table: "Movies",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    genre_id = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaTypes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaTypes_MovieId",
                table: "MediaTypes",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DropColumn(
                name: "backdrop_path",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "is_adult",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "original_language",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "original_title",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "overview",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "poster_path",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "release_date",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Movies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "Genres",
                newName: "GenreId");
        }
    }
}
