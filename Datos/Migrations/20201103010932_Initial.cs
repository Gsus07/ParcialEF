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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorApoyo = table.Column<decimal>(nullable: false),
                    ModalidadApoyo = table.Column<string>(maxLength: 17, nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoyo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Sexo = table.Column<string>(maxLength: 2, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Departamento = table.Column<string>(maxLength: 15, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 15, nullable: true),
                    ApoyoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Apoyo_ApoyoId",
                        column: x => x.ApoyoId,
                        principalTable: "Apoyo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ApoyoId",
                table: "Personas",
                column: "ApoyoId");
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
