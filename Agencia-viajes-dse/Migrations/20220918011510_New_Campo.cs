using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia_viajes_dse.Migrations
{
    public partial class New_Campo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Destinos");
        }
    }
}
