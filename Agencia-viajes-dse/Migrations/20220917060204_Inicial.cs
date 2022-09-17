using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia_viajes_dse.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo_Principal = table.Column<double>(type: "float", nullable: false),
                    TDestino = table.Column<int>(type: "int", nullable: false),
                    TLugar = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gastos_Extras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos_Extras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destino_ARs",
                columns: table => new
                {
                    Id_Destino = table.Column<int>(type: "int", nullable: false),
                    Id_AR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino_ARs", x => new { x.Id_AR, x.Id_Destino });
                    table.ForeignKey(
                        name: "FK_Destino_ARs_ARS_Id_AR",
                        column: x => x.Id_AR,
                        principalTable: "ARS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destino_ARs_Destinos_Id_Destino",
                        column: x => x.Id_Destino,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Destinos_Id_Destino",
                        column: x => x.Id_Destino,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destinos_Gastos",
                columns: table => new
                {
                    Id_Gastos = table.Column<int>(type: "int", nullable: false),
                    Id_Destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos_Gastos", x => new { x.Id_Gastos, x.Id_Destino });
                    table.ForeignKey(
                        name: "FK_Destinos_Gastos_Destinos_Id_Destino",
                        column: x => x.Id_Destino,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinos_Gastos_Gastos_Extras_Id_Gastos",
                        column: x => x.Id_Gastos,
                        principalTable: "Gastos_Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destino_ARs_Id_Destino",
                table: "Destino_ARs",
                column: "Id_Destino");

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_Gastos_Id_Destino",
                table: "Destinos_Gastos",
                column: "Id_Destino");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_Id_Destino",
                table: "Reservaciones",
                column: "Id_Destino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destino_ARs");

            migrationBuilder.DropTable(
                name: "Destinos_Gastos");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "ARS");

            migrationBuilder.DropTable(
                name: "Gastos_Extras");

            migrationBuilder.DropTable(
                name: "Destinos");
        }
    }
}
