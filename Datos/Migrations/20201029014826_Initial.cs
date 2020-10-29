using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apoyo",
                columns: table => new
                {
                    IdApoyo = table.Column<string>(type: "varchar(5)", nullable: false),
                    ValorApoyo = table.Column<decimal>(type: "decimal", nullable: false),
                    ModalidadApoyo = table.Column<string>(type: "varchar(17)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoyo", x => x.IdApoyo);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "varchar(12)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: true),
                    Sexo = table.Column<string>(type: "varchar(2)", nullable: true),
                    Edad = table.Column<decimal>(type: "decimal", nullable: false),
                    Departamento = table.Column<string>(type: "varchar(15)", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(15)", nullable: true),
                    ApoyoIdApoyo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Apoyo_ApoyoIdApoyo",
                        column: x => x.ApoyoIdApoyo,
                        principalTable: "Apoyo",
                        principalColumn: "IdApoyo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ApoyoIdApoyo",
                table: "Personas",
                column: "ApoyoIdApoyo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Apoyo");
        }
    }
}
