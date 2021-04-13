using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaDio.Migrations
{
    public partial class ColunaFavorito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorito",
                table: "Contatos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorito",
                table: "Contatos");
        }
    }
}
