using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delta.Data.Migrations
{
    /// <inheritdoc />
    public partial class InstructionPdfReagent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructionPdf",
                table: "Reagents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructionPdf",
                table: "Reagents");
        }
    }
}
