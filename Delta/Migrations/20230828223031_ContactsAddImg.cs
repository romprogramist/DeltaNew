using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delta.Migrations
{
    /// <inheritdoc />
    public partial class ContactsAddImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgBg",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgBg",
                table: "Contacts");
        }
    }
}
