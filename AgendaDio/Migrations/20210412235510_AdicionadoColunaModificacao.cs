using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaDio.Migrations
{
    public partial class AdicionadoColunaModificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Contatos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Contatos");
        }
    }
}
