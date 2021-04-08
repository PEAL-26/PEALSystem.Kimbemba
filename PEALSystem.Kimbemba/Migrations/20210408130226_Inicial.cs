using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PEALSystem.Kimbemba.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "codigo_barras",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    CodigoAEN = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codigo_barras", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_codigo_barras_CodigoAEN",
                table: "codigo_barras",
                column: "CodigoAEN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "codigo_barras");
        }
    }
}
