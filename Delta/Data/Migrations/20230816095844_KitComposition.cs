using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delta.Data.Migrations
{
    /// <inheritdoc />
    public partial class KitComposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KitComposition",
                table: "Reagents",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KitComposition",
                table: "Reagents");
        }
    }
}
