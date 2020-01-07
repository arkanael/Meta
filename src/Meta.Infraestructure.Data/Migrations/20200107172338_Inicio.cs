using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.Infraestructure.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(75)", nullable: false),
                    Canal = table.Column<string>(type: "varchar(7)", nullable: false),
                    Valor = table.Column<string>(type: "varchar(64)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");
        }
    }
}
