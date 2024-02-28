using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScarpaMondo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articoli",
                columns: table => new
                {
                    ArticoloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImmagineCopertinaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImmagineAggiuntiva1Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImmagineAggiuntiva2Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InVetrina = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articoli", x => x.ArticoloId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articoli");
        }
    }
}
