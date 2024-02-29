using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScarpaMondo.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToArticoli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articoli",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articoli");
        }
    }
}
