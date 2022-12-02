using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorTest.Server.Migrations
{
    public partial class quickfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Veterinarios",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Propietarios",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Perros",
                newName: "PerroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Veterinarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Propietarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PerroId",
                table: "Perros",
                newName: "Id");
        }
    }
}
