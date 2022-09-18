using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia_viajes_dse.Migrations
{
    public partial class reservacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Reservaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Reservaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Reservaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Reservaciones");
        }
    }
}
