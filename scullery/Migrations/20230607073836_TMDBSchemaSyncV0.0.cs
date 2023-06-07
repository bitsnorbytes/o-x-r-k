using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class TMDBSchemaSyncV00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    adult = table.Column<bool>(type: "boolean", nullable: false),
                    secure_base_image_URL = table.Column<string>(type: "text", nullable: false),
                    poster_sizes = table.Column<List<string>>(type: "text[]", nullable: false),
                    backdrop_sizes = table.Column<List<string>>(type: "text[]", nullable: false),
                    backdrop_path = table.Column<string>(type: "text", nullable: false),
                    poster_path = table.Column<string>(type: "text", nullable: false),
                    release_date = table.Column<DateOnly>(type: "date", nullable: false),
                    overview = table.Column<string>(type: "text", nullable: false),
                    original_title = table.Column<string>(type: "text", nullable: false),
                    original_language = table.Column<string>(type: "text", nullable: false),
                    runtime = table.Column<int>(type: "integer", nullable: false),
                    genre_ids = table.Column<int[]>(type: "integer[]", nullable: true),
                    media_type = table.Column<string>(type: "text", nullable: true),
                    imdb_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
