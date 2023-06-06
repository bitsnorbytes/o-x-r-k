using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class TMDBSchemaSyncV14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MoviesId",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MoviesId",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "Genres",
                newName: "genre_id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "genre_id",
                table: "Genres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CinemaCatalogueId",
                table: "Genres",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_CinemaCatalogueId",
                table: "Genres",
                column: "CinemaCatalogueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_CinemaCatalogueId",
                table: "Genres",
                column: "CinemaCatalogueId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_CinemaCatalogueId",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_CinemaCatalogueId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CinemaCatalogueId",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "Genres",
                newName: "MoviesId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "MoviesId",
                table: "Genres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

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
        }
    }
}
