using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scullery.Migrations
{
    /// <inheritdoc />
    public partial class AddedRunTimeInMins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "running_time_in_mins",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "running_time_in_mins",
                table: "Movies");
        }
    }
}
