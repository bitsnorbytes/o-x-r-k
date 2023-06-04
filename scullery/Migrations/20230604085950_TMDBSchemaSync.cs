using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class TMDBSchemaSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MovieId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaTypes_Movies_MovieId",
                table: "MediaTypes");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MovieId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "is_adult",
                table: "Movies",
                newName: "adult");

            migrationBuilder.RenameColumn(
                name: "running_time_in_mins",
                table: "Movies",
                newName: "imdb_id");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "Movies",
                newName: "runtime");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "MediaTypes",
                newName: "mediatype_id");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MediaTypes",
                newName: "MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaTypes_MovieId",
                table: "MediaTypes",
                newName: "IX_MediaTypes_MoviesId");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "Genres",
                newName: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MoviesId",
                table: "Genres",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_MoviesId",
                table: "Genres",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaTypes_Movies_MoviesId",
                table: "MediaTypes",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MoviesId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaTypes_Movies_MoviesId",
                table: "MediaTypes");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MoviesId",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "adult",
                table: "Movies",
                newName: "is_adult");

            migrationBuilder.RenameColumn(
                name: "runtime",
                table: "Movies",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "imdb_id",
                table: "Movies",
                newName: "running_time_in_mins");

            migrationBuilder.RenameColumn(
                name: "mediatype_id",
                table: "MediaTypes",
                newName: "genre_id");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "MediaTypes",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaTypes_MoviesId",
                table: "MediaTypes",
                newName: "IX_MediaTypes_MovieId");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "Genres",
                newName: "genre_id");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Genres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MovieId",
                table: "Genres",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_MovieId",
                table: "Genres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaTypes_Movies_MovieId",
                table: "MediaTypes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
